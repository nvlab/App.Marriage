---- Artical_Image  Џѕнб Ќёб 
---- Ён ћѕжб Article
--- бняжд Ќёб д’н б«ѕќ«б URL »ѕб гд ’ж—… »«нд—н
begin Transaction
alter table Articles drop column Artical_Image
alter table Articles add Artical_Image nvarchar(max) 
commit