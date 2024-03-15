Create procedure usp_SearchJobApplication
@search varchar(50)
As
Begin
Select * from JobApplicationData  WHERE name LIKE '%' + @search + '%' 
    OR email LIKE '%' + @search + '%';
End