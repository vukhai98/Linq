Create procedure getinfo(@id int)
as
begin
	select e.EmployeeID,e.EmployeeName,s.Title from Employees e
	inner join Skills s on	s.SkillID = e.SkillID
	where e.EmployeeID = @id

end
drop procedure getinfo