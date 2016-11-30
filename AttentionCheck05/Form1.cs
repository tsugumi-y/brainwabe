using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;
using ThinkGearNET;
using MLApp;

namespace AttentionCheck05
{
    public partial class Form1 : Form
    {
        #region Win32 Serial API Class Definition
        [StructLayout(LayoutKind.Sequential)]
        public struct COMMTIMEOUTS
        {
            public uint ReadIntervalTimeout;
            public uint ReadTotalTimeoutMultiplier;
            public uint ReadTotalTimeoutConstant;
            public uint WriteTotalTimeoutMultiplier;
            public uint WriteTotalTimeoutConstant;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct DCB
        {
            public uint DCBlength;
            public uint BaudRate;
            public uint fBinary;
            public uint fParity;
            public uint fOutxCtsFlow;
            public uint fOutxDsrFlow;
            public uint fDtrControl;
            public uint fDsrSensitivit;
            public uint fTXContinueOnXoff;
            public uint fOutX;
            public uint fInX;
            public uint fErrorChar;
            public uint fNull;
            public uint fRtsControl;
            public uint fAbortOnError;
            public uint fDummy2;
            public ushort wReserved;
            public ushort XonLim;
            public ushort XoffLim;
            public byte ByteSize;
            public byte Parity;
            public byte StopBits;
            public char XonChar;
            public char XoffChar;
            public char ErrorChar;
            public char EofChar;
            public char EvtChar;
            public ushort wReserved1;
        };

        public class Rs232
        {
            #region Native Methos and Declaration
            const uint GENERIC_READ = 0x80000000;
            const uint GENERIC_WRITE = 0x40000000;
            const uint GENERIC_EXECUTE = 0x20000000;
            const uint GENERIC_ALL = 0x10000000;
            const uint CREATE_NEW = 1;
            const uint CREATE_ALWAYS = 2;
            const uint OPEN_EXISTING = 3;
            const uint OPEN_ALWAYS = 4;
            const uint TRUNCATE_EXISTING = 5;

            [DllImport("kernel32", SetLastError = true)]
            static extern unsafe IntPtr CreateFile(
                string FileName, // file name
                uint DesiredAccess, // access mode
                uint ShareMode, // share mode
                uint SecurityAttributes, // Security Attributes
                uint CreationDisposition, // how to create
                uint FlagsAndAttributes, // file attributes
                int hTemplateFile // handle to template file
            );

            [DllImport("kernel32", SetLastError = true)]
            static extern unsafe bool ReadFile(
                IntPtr hFile, // handle to file
                void* pBuffer, // data buffer
                int NumberOfBytesToRead, // number of bytes to read
                int* pNumberOfBytesRead, // number of bytes read
                int Overlapped // overlapped buffer
            );

            [DllImport("kernel32", SetLastError = true)]
            static extern unsafe bool WriteFile(
            IntPtr hFile, // handle to file
            void* pBuffer, // data buffer
            int nNumberOfBytesToWrite, // number of bytes to be written to the file
            int* lpNumberOfBytesWritten, // number of bytes written
            int Overlapped // overlapped buffer
        );

            [DllImport("kernel32", SetLastError = true)]
            static extern unsafe bool CloseHandle(
                IntPtr hObject // handle to object
            );

            [DllImport("kernel32", SetLastError = true)]
            static extern unsafe bool GetCommState(
            IntPtr hFile,
            ref DCB lpDCB);

            [DllImport("kernel32", SetLastError = true)]
            static extern unsafe bool SetCommState(
            IntPtr hFile,
            ref DCB lpDCB);

            [DllImport("kernel32", SetLastError = true)]
            static extern unsafe bool SetCommTimeouts(
                IntPtr hFile,
                ref COMMTIMEOUTS lpCommTimeouts);

            [DllImport("kernel32", SetLastError = true)]
            static extern unsafe bool GetCommTimeouts(
                IntPtr hFile,
                ref COMMTIMEOUTS lpCommTimeouts);
            #endregion

            IntPtr handle;
            public Rs232()
            {

            }

            public bool Open(string comPort)
            {
                handle = CreateFile(
                comPort,
                GENERIC_READ | GENERIC_WRITE,
                0,
                0,
                OPEN_EXISTING,
                0,
                0);

                //				if (handle != IntPtr.Zero)
                if (handle.ToInt32() != -1)
                    return true;
                else
                    return false;
            }

            public unsafe int Read(byte[] buffer, int index, int count)
            {

                if (handle == IntPtr.Zero)
                    return 0;

                int n = 0;
                fixed (byte* p = buffer)
                {

                    if (!ReadFile(handle, p + index, count, &n, 0))
                        return 0;
                }

                return n;
            }

            public unsafe int Write(byte[] buffer, int index, int count)
            {
                if (handle == IntPtr.Zero)
                    return 0;

                int n = 0;
                fixed (byte* p = buffer)
                {
                    if (!WriteFile(handle, p + index, count, &n, 0))
                        return 0;
                }
                return n;
            }

            public unsafe bool Init(uint BaudRate, byte ByteSize, byte Parity, byte StopBits)
            {
                if (handle == IntPtr.Zero)
                    return false;

                // Init the com state
                DCB dcb = new DCB();
                if (!GetCommState(handle, ref dcb))
                    return false;

                dcb.BaudRate = BaudRate;
                dcb.ByteSize = ByteSize;
                dcb.Parity = Parity;
                dcb.StopBits = StopBits;

                if (!SetCommState(handle, ref dcb))
                    return false;

                // Init the com timeouts
                COMMTIMEOUTS Commtimeouts = new COMMTIMEOUTS();
                if (!GetCommTimeouts(handle, ref Commtimeouts))
                    return false;

                Commtimeouts.ReadIntervalTimeout = 600;
                if (!SetCommTimeouts(handle, ref Commtimeouts))
                    return false;

                return true;
            }

            public bool Close()
            {
                // close file handle
                return CloseHandle(handle);
            }
        }
        #endregion

        const int SIZE = 875;
        static public string UserProfile = Environment.GetEnvironmentVariable("USERPROFILE");
        static public string ImageDir = UserProfile + @"\Documents\BrainWave\Image\";
        static public string MfileDir = UserProfile + @"\Documents\BrainWave\Csharp01\";
        const int COM_PORT_NO = 3; // デフォルトのCOMポート番号
        private const string ARDUPORT = "COM6"; //arduinoシリアルポートの宣言

        bool cancel_flag = false;
        bool on_flag = false;
        int Counter = 0;
        int[] raw_array = new int[SIZE + 1];

		double[] double_raw_array = new double[SIZE + 1];

        int Result =-1;
        string ComPort = null;
        public const string FormTitle = "脳波   2016 HAL東京 先端ロボット開発学科";

        Rs232 SerialObj = new Rs232();

        Thread inputThread = null;  //スレッド
        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();   //ストップウォッチ

        private ThinkGearWrapper thinkGearWrapper = new ThinkGearWrapper(); //thinkgearオブジェクトの宣言
        public MLApp.MLApp matlab = new MLApp.MLApp(); // Create the MATLAB instance 

        double raw;
        float float_raw;
        int int_raw;

        private bool comando = false;

        /*******************************************************************
         * 
         * ロード
         * 
         *******************************************************************/
        public Form1()
        {
            InitializeComponent();

            matlab.MinimizeCommandWindow();
            matlab.Execute(@"cd " + MfileDir);
            //matlab.Execute("load param03");
            //matlab.Execute("load param200");
            matlab.Execute("load param06150");

            btnJudgment.Enabled = false;
			btnSave.Enabled = false;
            btnSave.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = FormTitle;
            pictureBox1.Image = Image.FromFile(ImageDir + "robot.png");
            comboBox1.SelectedIndex = COM_PORT_NO - 1;
            ComPort = comboBox1.Text;
        }

        /*******************************************************************
         * 
         * send_text
         * 
         *******************************************************************/
        delegate void myText(float raw, int Counter);
        
        private void setText(float raw, int Counter)
        {
            if (this.textBox2.InvokeRequired)
            {
                myText d = new myText(setText);
                this.Invoke(d, new object[] { raw, Counter });
            }
            else
            {
                this.textBox2.Text = raw.ToString();
                this.textBox4.Text = Counter.ToString();
            }
        }


        /*******************************************************************
         * 
         * start
         * 
         *******************************************************************/
        private void btnStart_Click(object sender, EventArgs e)
        {

            textBox2.Focus();
            textBox4.Focus();
            btnCancel.Focus();
            btnSave.Focus();

            on_flag = true;
            cancel_flag = false;

            btnStart.Enabled = false;
            btnCancel.Enabled = true;
            btnJudgment.Enabled = true;
            btnSave.Enabled = false;

            textBox3.Text = null;
            comboBox1.Enabled = false;

			pictureBox1.Image = Image.FromFile(ImageDir + "robot.png");

            int buf_count = 0;
            byte[] buf = new byte[1]; buf[0] = (byte)'s';
            buf_count = SerialObj.Write(buf, 0, 1);

            inputThread = new Thread(ReadInput);
            inputThread.Priority = ThreadPriority.Highest;
            inputThread.Start();


            for (int count = 0; count <= SIZE; count++)
            {
                raw_array[count] = 0;
                double_raw_array[count] = 0;
            }

            Counter = 0;
            sw.Reset();
            sw.Start();

        }

        /*******************************************************************
         * 
         * cancel
         * 
         *******************************************************************/
        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancel_flag = true;
            on_flag = false;

            btnStart.Enabled = true;
            btnCancel.Enabled = false;
            btnSave.Enabled = false;

            comboBox1.Enabled = true;
            textBox3.Text = sw.ElapsedMilliseconds.ToString();
        }

        /*******************************************************************
         * 
         * btnJudgment
         * 
         *******************************************************************/
        private void btnJudgment_Click(object sender, EventArgs e)
        {
            string ImageFile;

            if (Result == 0)
            {
                ImageFile = ImageDir + "sankaku.png";
                comando = false; //switch the led's state
                serialArduino.Write(new byte[] { Convert.ToByte(comando) }, 0, 1); //send the commando to arduino serial port

            }
            else if (Result == 1)
            {
                ImageFile = ImageDir + "maru.png";
                comando = true; //switch the led's state
                serialArduino.Write(new byte[] { Convert.ToByte(comando) }, 0, 1); //send the commando to arduino serial port

            }
            else
            {
                ImageFile = ImageDir + "robot.png";
            }

            pictureBox1.Image = Image.FromFile(ImageFile);
            System.Media.SystemSounds.Asterisk.Play();

            btnStart.Enabled = true;
            btnJudgment.Enabled = false;
            btnSave.Enabled = true;

            comboBox1.Enabled = true;
        }


        /*******************************************************************
         * 
         * save
         * 
         *******************************************************************/
        private void btnSave_Click(object sender, EventArgs e)
        {
            string file_name = null;
            int cnt;

            DialogResult dr = saveFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                file_name = saveFileDialog1.FileName;

                StreamWriter writer = new StreamWriter(file_name, false, Encoding.GetEncoding("Shift_JIS"));

                for (cnt = 0; cnt <= SIZE; cnt++)
                {
                    writer.Write(raw_array[cnt].ToString());
                    writer.WriteLine();
                }
                writer.Close();
            }
            else if (dr == System.Windows.Forms.DialogResult.Cancel)
            {
                MessageBox.Show("キャンセルされました");
            }
            btnSave.Enabled = false;
        }

        /*******************************************************************
         * 
         * ヘッドセット接続
         * 
         *******************************************************************/
        private void btnHeadsetConnect_Click(object sender, EventArgs e)
        {
            if (thinkGearWrapper.Connect("COM" + COM_PORT_NO, 57600, true)) //Mindwaveの接続チェック open
            {
                btnHeadsetConnect.Enabled = false; //Mindwaveの接続ボタンを使用不可
                btnHeadsetDisconnect.Enabled = true; //Mindwaveの接続切断ボタンを使用可
                //MessageBox.Show("接続完了", "成功", MessageBoxButtons.OK, MessageBoxIcon.None);

                thinkGearWrapper.EnableBlinkDetection(true); //enable the eye blink on the eSense protocol
                thinkGearWrapper.ThinkGearChanged += new EventHandler<ThinkGearChangedEventArgs>(
                thinkGearWrapper_ThinkGearChanged); //capture the event when a new data is incoming
            }
            else
            {
                MessageBox.Show("Could not connect to headset", "中止", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            try
            {
                serialArduino.PortName = ARDUPORT;//Arduino ポート名設定
                serialArduino.Open(); //Arduino open
            }
            catch (IOException) //繋げなかった場合
            {
                MessageBox.Show("Could not connect to Studuino", "中止", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /*******************************************************************
         * 
         * ヘッドセット切断
         * 
         *******************************************************************/
        private void btnHeadsetDisconnect_Click(object sender, EventArgs e)
        {
            thinkGearWrapper.Disconnect(); //headset  close
            btnHeadsetConnect.Enabled = true; //headset 通信ボタンをON
            btnHeadsetDisconnect.Enabled = false; //headset 切断ボタンをOFF

            serialArduino.Close(); //Arduino close

            cancel_flag = false;
            on_flag = false;

            btnStart.Enabled = true;
            btnCancel.Enabled = true;
            btnSave.Enabled = true;
            textBox2.Text = null;

            Counter = 0;
            sw.Reset();
        }

        /*******************************************************************
         * 
         * 処理(blain_log)
         * 
         *******************************************************************/
        void thinkGearWrapper_ThinkGearChanged(object sender, ThinkGearChangedEventArgs e)
        {
            BeginInvoke(new MethodInvoker(delegate //use the AsyncTask to update the UI
            {

                textBox3.Text = sw.ElapsedMilliseconds.ToString();
                debag.AppendText("Raw: " + thinkGearWrapper.ThinkGearState.Raw + Environment.NewLine);
                string val = thinkGearWrapper.ThinkGearState.Raw + "\n"; //ログの内容

                lblAttention.Text = "Attention: " + thinkGearWrapper.ThinkGearState.Attention;
                lblMeditation.Text = "Meditation: " + thinkGearWrapper.ThinkGearState.Meditation;
                lblAlpha1.Text = "Alpha1: " + thinkGearWrapper.ThinkGearState.Alpha1;
                lblAlpha2.Text = "Alpha2: " + thinkGearWrapper.ThinkGearState.Alpha2;
                lblBeta1.Text = "Beta1: " + thinkGearWrapper.ThinkGearState.Beta1;
                lblBeta2.Text = "Beta2: " + thinkGearWrapper.ThinkGearState.Beta2;
                lblGamma1.Text = "Gamma1: " + thinkGearWrapper.ThinkGearState.Gamma1;
                lblGamma2.Text = "Gamma2: " + thinkGearWrapper.ThinkGearState.Gamma2;
                lblDelta.Text = "Delta: " + thinkGearWrapper.ThinkGearState.Delta;
                lblTheta.Text = "Theta: " + thinkGearWrapper.ThinkGearState.Theta;

            }
            ));
            Thread.Sleep(10); //wait ten milliseconds
 
        }

        /*******************************************************************
         * 
         * 処理(hand)
         * 
         *******************************************************************/
        void ReadInput()
        {
            while (inputThread.IsAlive)
            {
                if (Counter <= SIZE && !cancel_flag && on_flag)
                {
                    float_raw = thinkGearWrapper.ThinkGearState.Raw;
                    raw = (double)float_raw;

                    raw_array[Counter] = (int)raw;

                }
                else
                {
                    sw.Stop();

                    Counter = 0;

                    for (int count = 0; count <= SIZE; count++)
                    {
                        double_raw_array[count] = (double)raw_array[count];
                    }

                    Cursor cursorOrg = Cursor.Current;
                    Cursor.Current = Cursors.WaitCursor;
                    matlab.PutWorkspaceData("data", "base", double_raw_array);

                    matlab.Execute("brain_wave");

                    System.Array prresult = new double[1, 1];
                    System.Array piresult = new double[1, 1];

                    matlab.GetFullMatrix("Result", "base", ref prresult, ref piresult);
                    Result = (int)((double)prresult.GetValue(0, 0));
                    Cursor.Current = cursorOrg;

                    if (cancel_flag)
                    {
                        btnCancel.Enabled = false;
                        btnSave.Enabled = false;
                        textBox2.Text = sw.ElapsedMilliseconds.ToString();
                    }
                    else
                    {

                    }
                    on_flag = false;

                    inputThread.Abort();

                }
                Counter++;
                Thread.Sleep(10); //wait ten milliseconds
            }
        }

        /*******************************************************************
         * 
         * 処理
         * 
         *******************************************************************/
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComPort = comboBox1.Text;
        }


    }
}
