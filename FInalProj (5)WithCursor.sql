IF OBJECT_ID('FN_CreateDropSP') is not null
Drop Function FN_CreateDropSP
go
Create Function FN_CreateDropSP
(
	@shemaName as nvarchar(100),
	@tableName as nvarchar(100),
	@procType as nvarchar(10)
)
returns nvarchar(max)
as
begin

declare @procName as nvarchar(100) = QuoteName(@shemaName)+'.'+QuoteName(@tablename+'_'+@procType)

declare @SQL as nvarchar(4000) ='IF OBJECT_ID (N'''+@procName+''') IS NOT NULL'+ char(13)
								+'DROP PROCEDURE '+@procName+''+ char(13)
return @SQL
end


GO
IF OBJECT_ID('FN_CreateSelectSP') is not null
Drop Function FN_CreateSelectSP
go
Create Function FN_CreateSelectSP
(
	@shemaName as nvarchar(100),
	@tableName as nvarchar(100)
)
returns nvarchar(max)
as
begin

declare @procName as nvarchar(100) = QuoteName(@shemaName)+'.'+QuoteName(@tablename+'_Select')
			
declare @SPParameterList as nvarchar(max)=''

				
(select		
	@SPParameterList += QuoteName(vw.COLUMN_NAME)+','+char(13)		
from	
INFORMATION_SCHEMA.COLUMNS as vw
where		
	vw.TABLE_SCHEMA =@shemaName
and vw.TABLE_NAME=@tableName
) 


set @SPParameterList=left(@SPParameterList,len(@SPParameterList)-2)


declare @sqlQuery as nvarchar(max)= N'CREATE PROCEDURE '+@procName+char(13)+
				'AS'+char(13)+
				'BEGIN'+char(13)+
				'SELECT '+@SPParameterList +char(13)+
				' FROM '+ @shemaName+'.'+@tablename +char(13)+
				'END'

--EXEC (@sqlQuery)
--print @sqlquery
return @sqlQuery
end

GO
IF OBJECT_ID('FN_CreateInsertSP') is not null
Drop Function FN_CreateInsertSP
go
Create function [dbo].[FN_CreateInsertSP] 
(
	@shemaName as nvarchar(100),
	@tableName as nvarchar(100)
)
returns nvarchar(max)
as
begin

declare @procName as nvarchar(100) = QuoteName(@shemaName)+'.'+QuoteName(@tablename+'_Insert')

declare @SPVariables as nvarchar(max)=''
declare @SPColumnList as nvarchar(max)=''
declare @SPParameterList as nvarchar(max)=''							  

(select		
	@SPParameterList +='@'+Replace(vw.COLUMN_NAME,' ','_')+ ' as ' 
			+ (case DATA_TYPE
			   when 'numeric' 
			   then DATA_TYPE + '(' + convert(varchar(10), NUMERIC_PRECISION) + ',' + convert(varchar(10), NUMERIC_SCALE) + ')' 
			   else DATA_TYPE end)
			+ (case when DATA_TYPE like'%char' and CHARACTER_MAXIMUM_LENGTH is not null 
			   then '(' 
			+ case when CONVERT(varchar(10), CHARACTER_MAXIMUM_LENGTH) = '-1' 
			  then 'max' else CONVERT(varchar(10), CHARACTER_MAXIMUM_LENGTH) end + ')' else '' end)
			+',' + char(13)
from	
INFORMATION_SCHEMA.COLUMNS as vw
where		
	vw.TABLE_SCHEMA =@shemaName
and vw.TABLE_NAME=@tableName
and not exists (SELECT 
					[name] 
				FROM 
					sys.computed_columns		as cc
				WHERE 
					object_id = OBJECT_ID(vw.TABLE_SCHEMA+'.'+vw.TABLE_NAME)
					and cc.[name]=vw.COLUMN_NAME)
and (SELECT COLUMNPROPERTY( OBJECT_ID(vw.TABLE_SCHEMA+'.'+vw.TABLE_NAME),vw.COLUMN_NAME,'GeneratedAlwaysType')) =0
) 


(select		
	@SPColumnList+=QuoteName(vw.COLUMN_NAME)+','+char(13)		
from	
INFORMATION_SCHEMA.COLUMNS as vw
where		
	vw.TABLE_SCHEMA =@shemaName
and vw.TABLE_NAME=@tableName
and not exists (SELECT 
					[name] 
				FROM 
					sys.computed_columns		as cc
				WHERE 
					object_id = OBJECT_ID(vw.TABLE_SCHEMA+'.'+vw.TABLE_NAME)
					and cc.[name]=vw.COLUMN_NAME)
and (SELECT COLUMNPROPERTY( OBJECT_ID(vw.TABLE_SCHEMA+'.'+vw.TABLE_NAME),vw.COLUMN_NAME,'GeneratedAlwaysType')) =0
) 
(select		
	@SPVariables +='@'+Replace(vw.COLUMN_NAME,' ','_')+','+char(13)		
from	
INFORMATION_SCHEMA.COLUMNS as vw
where		
	vw.TABLE_SCHEMA =@shemaName
and vw.TABLE_NAME=@tableName
and not exists (SELECT 
					[name] 
				FROM 
					sys.computed_columns		as cc
				WHERE 
					object_id = OBJECT_ID(vw.TABLE_SCHEMA+'.'+vw.TABLE_NAME)
					and cc.[name]=vw.COLUMN_NAME)
and (SELECT COLUMNPROPERTY( OBJECT_ID(vw.TABLE_SCHEMA+'.'+vw.TABLE_NAME),vw.COLUMN_NAME,'GeneratedAlwaysType')) =0
) 

set @SPColumnList=left(@SPColumnList,len(@SPColumnList)-2)
set @SPParameterList =left(@SPParameterList,len(@SPParameterList)-2)
set @SPVariables =  left(@SPVariables,len(@SPVariables)-2)
declare @sqlQuery as nvarchar(max)= N'CREATE PROCEDURE'+@procName+char(13)+
					 @SPParameterList+char(13)+
					'AS'+char(13)+
					'BEGIN'+char(13)+
					'INSERT INTO ' +Quotename(@shemaName)+'.'+Quotename(@tablename)+char(13)+
					+'('+@SPColumnList+')'+char(13)+
					'VALUES '+char(13)+
					'('+@SPVariables+char(13)
					+') END'


return @sqlQuery
end

Go
IF OBJECT_ID('FN_CreateUpdateSP') is not null
Drop Function FN_CreateUpdateSP
go
Create function [dbo].[FN_CreateUpdateSP] 
(
	@shemaName as nvarchar(100),
	@tableName as nvarchar(100)
)
returns nvarchar(max)
as
begin

declare @procName as nvarchar(100) = QuoteName(@shemaName)+'.'+QuoteName(@tablename+'_Update')
								
declare @SPParameterList as nvarchar(max)=''
declare @PKColumnWhere nvarchar(200)=''
declare @SPVariables nvarchar(max)=''

							  

(select		
	@SPParameterList +='@'+Replace(vw.COLUMN_NAME,' ','_')+ ' as ' 
			+ (case DATA_TYPE
			   when 'numeric' 
			   then DATA_TYPE + '(' + convert(varchar(10), NUMERIC_PRECISION) + ',' + convert(varchar(10), NUMERIC_SCALE) + ')' 
			   else DATA_TYPE end)
			+ (case when DATA_TYPE like'%char' and CHARACTER_MAXIMUM_LENGTH is not null 
			   then '(' 
			+ case when CONVERT(varchar(10), CHARACTER_MAXIMUM_LENGTH) = '-1' 
			  then 'max' else CONVERT(varchar(10), CHARACTER_MAXIMUM_LENGTH) end + ')' else '' end)
			+',' + char(13)	
from	
INFORMATION_SCHEMA.COLUMNS as vw
where		
	vw.TABLE_SCHEMA =@shemaName
and vw.TABLE_NAME=@tableName
and not exists (SELECT 
					[name] 
				FROM 
					sys.computed_columns		as cc
				WHERE 
					object_id = OBJECT_ID(vw.TABLE_SCHEMA+'.'+vw.TABLE_NAME)
					and cc.[name]=vw.COLUMN_NAME)
and (SELECT COLUMNPROPERTY( OBJECT_ID(vw.TABLE_SCHEMA+'.'+vw.TABLE_NAME),vw.COLUMN_NAME,'GeneratedAlwaysType')) =0
) 

(select		
	@PKColumnWhere += Replace(vw.COLUMN_NAME,' ','_') +'= @'+Replace(vw.COLUMN_NAME,' ','_') + ' and '
	--@PKColumn +' = @'+@PKColumn
from 
    INFORMATION_SCHEMA.TABLE_CONSTRAINTS		as	Tab
join
    INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE	as	vw
on
	vw.Constraint_Name		= Tab.Constraint_Name
    and vw.Table_Name		= Tab.Table_Name
	and Tab.Constraint_Type = 'PRIMARY KEY'    
WHERE 
	vw.Table_Name = @tableName
and	vw.TABLE_SCHEMA =@shemaName
and not exists (SELECT 
					[name] 
				FROM 
					sys.computed_columns		as cc
				WHERE 
					object_id = OBJECT_ID(vw.TABLE_SCHEMA+'.'+vw.TABLE_NAME)
					and cc.[name]=vw.COLUMN_NAME)
and (SELECT COLUMNPROPERTY( OBJECT_ID(vw.TABLE_SCHEMA+'.'+vw.TABLE_NAME),vw.COLUMN_NAME,'GeneratedAlwaysType')) =0
) 


(select		
	@SPVariables +=Quotename(vw.COLUMN_NAME) +'='+'@'+Replace(vw.COLUMN_NAME,' ','_')+','+char(13)		
from	
	INFORMATION_SCHEMA.COLUMNS as vw

where		
	vw.TABLE_SCHEMA =@shemaName
and vw.TABLE_NAME=@tableName
and vw.COLUMN_NAME not in (
							select		
								vw.Column_Name 
							from 
							    INFORMATION_SCHEMA.TABLE_CONSTRAINTS		as	Tab
							join
							    INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE	as	vw
							on
								vw.Constraint_Name		= Tab.Constraint_Name
							    and vw.Table_Name		= Tab.Table_Name
								and Tab.Constraint_Type = 'PRIMARY KEY'    
							WHERE 
								vw.Table_Name = @tableName
							and	vw.TABLE_SCHEMA =@shemaName

							)
and not exists (SELECT 
					[name] 
				FROM 
					sys.computed_columns		as cc
				WHERE 
					object_id = OBJECT_ID(vw.TABLE_SCHEMA+'.'+vw.TABLE_NAME)
					and cc.[name]=vw.COLUMN_NAME)		
and (SELECT COLUMNPROPERTY( OBJECT_ID(vw.TABLE_SCHEMA+'.'+vw.TABLE_NAME),vw.COLUMN_NAME,'GeneratedAlwaysType')) =0					
) 



set @SPParameterList=left(@SPParameterList,len(@SPParameterList)-2)
set @SPVariables=left(@SPVariables,len(@SPVariables)-2)

if( @PKColumnWhere is not null and LEN(@PKColumnWhere) > 0)
begin
	set @PKColumnWhere = left(@PKColumnWhere,LEN(@PKColumnWhere)-3)
end

declare @sqlQuery as nvarchar(max)= N'CREATE PROCEDURE '+@procName+char(13)+
				  @SPParameterList+char(13)+
				'AS'+char(13)+
				'BEGIN'+char(13)+
				'UPDATE '+@tableName+char(13)+
				'SET '+@SPVariables+char(13)+
				'WHERE '+ @PKColumnwhere+char(13)+
				'END'

--EXEC (@sqlQuery)
--print @sqlquery
return @sqlQuery
end

GO
IF OBJECT_ID('FN_CreateDeleteSP') is not null
Drop Function FN_CreateDeleteSP
go
Create function [dbo].[FN_CreateDeleteSP] 
(
	@shemaName as nvarchar(100),
	@tableName as nvarchar(100)
)
returns nvarchar(max)
as
begin

declare @procName as nvarchar(100) = QuoteName(@shemaName)+'.'+QuoteName(@tablename+'_Delete')

declare @PKColumnWhere nvarchar(200)=''
declare @SPParameterList as nvarchar(max)=''
declare @SPVariables nvarchar(max)=''
						  

(select		
	@SPParameterList +='@'+Replace(vw.COLUMN_NAME,' ','_')+ ' as ' 
			+ (case DATA_TYPE
			   when 'numeric' 
			   then DATA_TYPE + '(' + convert(varchar(10), NUMERIC_PRECISION) + ',' + convert(varchar(10), NUMERIC_SCALE) + ')' 
			   else DATA_TYPE end)
			+ (case when DATA_TYPE like'%char' and CHARACTER_MAXIMUM_LENGTH is not null 
			   then '(' 
			+ case when CONVERT(varchar(10), CHARACTER_MAXIMUM_LENGTH) = '-1' 
			  then 'max' else CONVERT(varchar(10), CHARACTER_MAXIMUM_LENGTH) end + ')' else '' end)
			+',' + char(13)		
from	
INFORMATION_SCHEMA.COLUMNS as vw
where		
	vw.TABLE_SCHEMA =@shemaName
and vw.TABLE_NAME=@tableName
) 

(select		
	@PKColumnWhere += Replace(vw.COLUMN_NAME,' ','_') +'= @'+Replace(vw.COLUMN_NAME,' ','_') + ' and '
from 
    INFORMATION_SCHEMA.TABLE_CONSTRAINTS		as	Tab
join
    INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE	as	vw
on
	vw.Constraint_Name		= Tab.Constraint_Name
    and vw.Table_Name		= Tab.Table_Name
	and Tab.Constraint_Type = 'PRIMARY KEY'    
WHERE 
	vw.Table_Name = @tableName
and	vw.TABLE_SCHEMA =@shemaName
) 

set @SPParameterList=left(@SPParameterList,len(@SPParameterList)-2)

if( @PKColumnWhere is not null and LEN(@PKColumnWhere) > 0)
begin
	set @PKColumnWhere = left(@PKColumnWhere,LEN(@PKColumnWhere)-3)
end

declare @sqlQuery as nvarchar(max)= N'CREATE PROCEDURE '+@procName+char(13)+
				 @SPParameterList+char(13)+
				'AS'+char(13)+
				'BEGIN'+char(13)+
				'DELETE FROM '+@tableName+char(13)+
				'WHERE '+ @PKColumnwhere+char(13)+
				'END'

return @sqlQuery
end
 
GO




declare @spSchema nvarchar(200)
declare @spTable nvarchar(200)
declare @spId int
declare @spInsertSQL nvarchar(max)
declare @spUpdateSQL nvarchar(max)
declare @spDeleteSQL nvarchar(max) 
declare @spSelectSQL varchar(max)
declare @spDropSQL   nvarchar(max) 
declare @spsToWrite table(spId int identity(1,1), spSchema varchar(200), spTable varchar(200))
 
-- populate the list of tables to process
--insert into 
--	@spsToWrite(spSchema, spTable)
--select 
--	ist.TABLE_SCHEMA, 
--	ist.TABLE_NAME
--from 
--	INFORMATION_SCHEMA.TABLES												as ist
--where exists (
--				 select 
--					1
--				 from 
--					INFORMATION_SCHEMA.TABLE_CONSTRAINTS tc
--				 where 
--				  tc.TABLE_SCHEMA=ist.TABLE_SCHEMA
--				 And tc.TABLE_NAME=ist.TABLE_NAME
--				 And tc.CONSTRAINT_TYPE='Primary Key'
--			 )
--select * from @spsToWrite
---- get the first table to process
--select @spId = (select top 1 spId from @spsToWrite order by spId)

--begin try
-- loop through each table and create the desired stored procedures
--while (@spId <> 0)
--begin
	--select	@spSchema = spSchema,
	--		@spTable = spTable
	--from @spsToWrite
	--where spId = @spId
	set @spInsertSQL=''
	set @spUpdateSQL=''
	set @spDeleteSQL=''
	set @spSelectSQL=''
	set @spDropSQL=''



declare Tcursor cursor 
for 
select TABLE_SCHEMA,TABLE_NAME
from INFORMATION_SCHEMA.TABLES
where TABLE_TYPE='Base Table'

open Tcursor

fetch next from Tcursor
into @spSchema,@spTable

while @@FETCH_STATUS=0
begin


	set @spInsertSQL=''
	set @spUpdateSQL=''
	set @spDeleteSQL=''
	set @spSelectSQL=''
	set @spDropSQL=''


	set @spDropSQL = dbo.FN_CreateDropSP(@spSchema, @spTable,'Insert')		
	set @spInsertSQL = dbo.FN_createInsertSP(@spSchema, @spTable)
	print @spInsertSQL
	print '=========='
	execute(@spDropSQL)
	execute(@spInsertSQL)


	set @spInsertSQL=''
	set @spUpdateSQL=''
	set @spDeleteSQL=''
	set @spSelectSQL=''
	set @spDropSQL=''
	 
	set @spDropSQL = dbo.FN_CreateDropSP(@spSchema, @spTable,'Update')		
	set @spUpdateSQL = dbo.[FN_CreateUpdateSP](@spSchema, @spTable)
	print @spUpdateSQL
	print '=========='
	execute(@spDropSQL)
	execute(@spUpdateSQL)

	set @spInsertSQL=''
	set @spUpdateSQL=''
	set @spDeleteSQL=''
	set @spSelectSQL=''
	set @spDropSQL=''

	set @spDropSQL = dbo.FN_CreateDropSP(@spSchema, @spTable,'Delete')		
	set @spDeleteSQL = dbo.[FN_CreateDeleteSP](@spSchema, @spTable)
	print @spDeleteSQL
	print '=========='
	execute(@spDropSQL)
	execute(@spDeleteSQL)

	set @spInsertSQL=''
	set @spUpdateSQL=''
	set @spDeleteSQL=''
	set @spSelectSQL=''
	set @spDropSQL=''

	set @spDropSQL = dbo.FN_CreateDropSP(@spSchema, @spTable,'Select')		
	set @spSelectSQL = dbo.[FN_CreateSelectSP](@spSchema, @spTable)
	print @spSelectSQL
	print '=========='
	execute(@spDropSQL)
	execute(@spSelectSQL)

	--delete from @spsToWrite where spId = @spId
 		
	---- get the next one
	--set @spId = 0
	--select @spId = (select top 1 spId from @spsToWrite order by spId)
 		
--end

	--end try
 
	--begin catch
 
	--		select	ERROR_NUMBER() AS ErrorNumber,
	--				ERROR_SEVERITY() AS ErrorSeverity,
	--				ERROR_STATE() AS ErrorState,
	--				ERROR_PROCEDURE() AS ErrorProcedure,
	--				ERROR_LINE() AS ErrorLine,
	--				ERROR_MESSAGE() AS ErrorMessage;
 
	--end catch


	fetch next from Tcursor
	into @spSchema,@spTable
end

close Tcursor
deallocate Tcursor