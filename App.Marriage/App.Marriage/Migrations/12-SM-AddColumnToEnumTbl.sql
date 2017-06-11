 if not exists(select * from sys.columns where object_id= object_id('Enums') and name='Entity_Order')
begin
alter table Enums add Entity_Order int null
end