-- ========================================================
-- Author...........  : Ing. Aneudy Abreu
-- Create date........: 15/10/2012
-- Last Date Modified.: 29/Oct/2012
-- Description........: Parse un string y lo retorna como una tabla.
--
-- Versión..........: 1.0
-- ========================================================

CREATE FUNCTION dbo.Split(@String varchar(8000), @Delimiter char(1))       
    returns @temptable TABLE (items varchar(8000))       
    as       
    begin       
        declare @idx int       
        declare @slice varchar(8000)       
          
        select @idx = 1       
            if len(@String)<1 or @String is null  return       
          
        while @idx!= 0       
        begin       
            set @idx = charindex(@Delimiter,@String)       
            if @idx!=0       
                set @slice = left(@String,@idx - 1)       
            else       
                set @slice = @String       
              
            if(len(@slice)>0)  
                insert into @temptable(Items) values(@slice)       
      
            set @String = right(@String,len(@String) - @idx)       
            if len(@String) = 0 break       
        end   
    return       
    end  