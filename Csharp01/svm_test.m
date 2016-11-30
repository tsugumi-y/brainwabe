%% サポートベクトルマシン（バイナリ）で、円と三角を classify してみる

teach_cir_feature = score_cir_tri(1:25,1:2);
teach_tri_feature = score_cir_tri(26:50,1:2); 

teach_feature = [teach_cir_feature;teach_tri_feature];
test_feature = [feature_test_vector_cir_only(:,1:2); feature_test_vector_tri_only(:,1:2)];

class_name_cir_tri = '';
for no = 1:25
    class_name_cir_tri = [class_name_cir_tri;'◯'];
end

for no = 26:50
    class_name_cir_tri = [class_name_cir_tri;'△'];
end

% サポートベクトルマシンによる学習
SVMModel = fitcsvm(teach_feature, class_name_cir_tri)
classOrder = SVMModel.ClassNames;

% サポートベクトルマシンによる分類
[label00, Classify_Score] = predict(SVMModel, test_feature);


%% マルチサポートベクトルマシンで、円/四角/三角を classify してみる(相関特徴量なし)
teach_cir_feature = score(1:25,1:3);
teach_squ_feature = score(26:50,1:3);
teach_tri_feature = score(51:75,1:3); 

teach_feature = [teach_cir_feature; teach_squ_feature; teach_tri_feature];
test_feature = [feature_test_vector_cir(:,1:3); feature_test_vector_squ(:,1:3); feature_test_vector_tri(:,1:3)];

class_name = '';
for no = 1:25
    class_name = [class_name;'◯'];
end

for no = 26:50
    class_name = [class_name;'□'];
end

for no = 51:75
    class_name = [class_name;'△'];
end

% マルチサポートベクトルマシンによる学習
Mdl = fitcecoc(teach_feature, class_name)
Mdl.ClassNames
CodingMat = Mdl.CodingMatrix

% マルチサポートベクトルマシンによる分類
[label01, Classify_Score] = predict(Mdl, test_feature);



%% マルチサポートベクトルマシンで、円/四角/三角を classify してみる(相関特徴量あり)
teach_cir_feature = score2(1:25,1:3);
teach_squ_feature = score2(26:50,1:3);
teach_tri_feature = score2(51:75,1:3); 

teach_feature = [teach_cir_feature; teach_squ_feature; teach_tri_feature];
test_feature = [feature_test_vector_cir_corr(:,1:3); feature_test_vector_squ_corr(:,1:3); feature_test_vector_tri_corr(:,1:3)];

class_name = '';
for no = 1:25
    class_name = [class_name;'◯'];
end

for no = 26:50
    class_name = [class_name;'□'];
end

for no = 51:75
    class_name = [class_name;'△'];
end

% マルチサポートベクトルマシンによる学習
Mdl = fitcecoc(teach_feature, class_name)
Mdl.ClassNames
CodingMat = Mdl.CodingMatrix

% マルチサポートベクトルマシンによる分類
[label02, Classify_Score] = predict(Mdl, test_feature);

%% 分類結果確認

% 円と三角のみ分類
label00

% 円/四角/三角分類(相関特徴量は使用せず)
label01

% 円/四角/三角分類(相関特徴量も使用)
label02
