---- ����� ��� ��� Category ��� Categoryname 
-- �� ���� Category
-- ���� �� ����� �� EF  ���� ��� ��� ������
if exists(select * from sys.columns where object_id=object_id('Category') and name='Category')
begin
	EXECUTE sp_rename N'dbo.Category.Category', N'CategoryName', 'COLUMN' 
end
