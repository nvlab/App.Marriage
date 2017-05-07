---- ÊÚÏíá ÇÓã ÍŞá Category Çáì Categoryname 
-- İí ÌÏæá Category
-- ÈÓÈÈ áã íŞÈáå İí EF  áÃäå äİÓ ÇÓã ÇáÌÏæá
if exists(select * from sys.columns where object_id=object_id('Category') and name='Category')
begin
	EXECUTE sp_rename N'dbo.Category.Category', N'CategoryName', 'COLUMN' 
end
