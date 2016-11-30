Test___Mode = 0;

if Test___Mode,
	cd 'C:\matlab\sample01\raw_data\log_all03'
	cd attention
	load att001.log
	cd ../meditation
	load med001.log
	
    test_dat = att001

	data = test_dat(:,1);
	
	data = data';

    cd 'C:\Users\yamasawa.tsugumi\Documents\BrainWave\Csharp'
end


data = data';

%data = data - 512;

peak_data = peak2peak(data);

std_data = std(data);



classify_att_med;

