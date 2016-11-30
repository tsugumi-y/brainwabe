%% �T�|�[�g�x�N�g���}�V���i�o�C�i���j�ŁA�~�ƎO�p�� classify ���Ă݂�

teach_cir_feature = score_cir_tri(1:25,1:2);
teach_tri_feature = score_cir_tri(26:50,1:2); 

teach_feature = [teach_cir_feature;teach_tri_feature];
test_feature = [feature_test_vector_cir_only(:,1:2); feature_test_vector_tri_only(:,1:2)];

class_name_cir_tri = '';
for no = 1:25
    class_name_cir_tri = [class_name_cir_tri;'��'];
end

for no = 26:50
    class_name_cir_tri = [class_name_cir_tri;'��'];
end

% �T�|�[�g�x�N�g���}�V���ɂ��w�K
SVMModel = fitcsvm(teach_feature, class_name_cir_tri)
classOrder = SVMModel.ClassNames;

% �T�|�[�g�x�N�g���}�V���ɂ�镪��
[label00, Classify_Score] = predict(SVMModel, test_feature);


%% �}���`�T�|�[�g�x�N�g���}�V���ŁA�~/�l�p/�O�p�� classify ���Ă݂�(���֓����ʂȂ�)
teach_cir_feature = score(1:25,1:3);
teach_squ_feature = score(26:50,1:3);
teach_tri_feature = score(51:75,1:3); 

teach_feature = [teach_cir_feature; teach_squ_feature; teach_tri_feature];
test_feature = [feature_test_vector_cir(:,1:3); feature_test_vector_squ(:,1:3); feature_test_vector_tri(:,1:3)];

class_name = '';
for no = 1:25
    class_name = [class_name;'��'];
end

for no = 26:50
    class_name = [class_name;'��'];
end

for no = 51:75
    class_name = [class_name;'��'];
end

% �}���`�T�|�[�g�x�N�g���}�V���ɂ��w�K
Mdl = fitcecoc(teach_feature, class_name)
Mdl.ClassNames
CodingMat = Mdl.CodingMatrix

% �}���`�T�|�[�g�x�N�g���}�V���ɂ�镪��
[label01, Classify_Score] = predict(Mdl, test_feature);



%% �}���`�T�|�[�g�x�N�g���}�V���ŁA�~/�l�p/�O�p�� classify ���Ă݂�(���֓����ʂ���)
teach_cir_feature = score2(1:25,1:3);
teach_squ_feature = score2(26:50,1:3);
teach_tri_feature = score2(51:75,1:3); 

teach_feature = [teach_cir_feature; teach_squ_feature; teach_tri_feature];
test_feature = [feature_test_vector_cir_corr(:,1:3); feature_test_vector_squ_corr(:,1:3); feature_test_vector_tri_corr(:,1:3)];

class_name = '';
for no = 1:25
    class_name = [class_name;'��'];
end

for no = 26:50
    class_name = [class_name;'��'];
end

for no = 51:75
    class_name = [class_name;'��'];
end

% �}���`�T�|�[�g�x�N�g���}�V���ɂ��w�K
Mdl = fitcecoc(teach_feature, class_name)
Mdl.ClassNames
CodingMat = Mdl.CodingMatrix

% �}���`�T�|�[�g�x�N�g���}�V���ɂ�镪��
[label02, Classify_Score] = predict(Mdl, test_feature);

%% ���ތ��ʊm�F

% �~�ƎO�p�̂ݕ���
label00

% �~/�l�p/�O�p����(���֓����ʂ͎g�p����)
label01

% �~/�l�p/�O�p����(���֓����ʂ��g�p)
label02
