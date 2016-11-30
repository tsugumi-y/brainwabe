
offset = alpha_att_med(1,:);

feature_source = [peak_data std_data];
feature_vector_tmp = feature_source * coeff_att_med - offset;
feature_vector = feature_vector_tmp(1:2);

[labe100, Classify_Score] = predict(SVMModel, feature_vector);

labe100

jd = strcmp('ü', labe100);

if jd == 1,
	Result = 1;
else,
	Result = 0;
end


