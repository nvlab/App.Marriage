---- Artical_Image ����� ��� 
---- �� ���� Article
--- ����� ��� ��� ������ URL ��� �� ���� ������
begin Transaction
alter table Articles drop column Artical_Image
alter table Articles add Artical_Image nvarchar(max) 
commit