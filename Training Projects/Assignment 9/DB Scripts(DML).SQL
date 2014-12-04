INSERT INTO Departments (DepartmentName)
     VALUES ('HR')
INSERT INTO Departments (DepartmentName)
     VALUES ('Administration')
INSERT INTO Departments (DepartmentName)
     VALUES ('Finance')
INSERT INTO Departments (DepartmentName)
     VALUES ('IT')
INSERT INTO Departments (DepartmentName)
     VALUES ('Engineering')
INSERT INTO Departments (DepartmentName)
     VALUES ('Marketing')


INSERT INTO [Employees]
           ([EmployeeCode]
           ,[FirstName]
           ,[LastName]
           ,[DOB]
           ,[Email]
           ,[DepartmentId])
     VALUES
           ('001'
           ,'System'
           ,'Admin'
           ,'1/1/2001 12:00:00 AM'
           ,'admin@nagarro.com'
           ,1)

DECLARE @newEmployeeId int

SELECT @newEmployeeId = @@IDENTITY

INSERT INTO [Logins]
           ([LoginName]
           ,[Password]
           ,[Role]
           ,[EmployeeId])
     VALUES
           ('admin'
           ,'admin'
           ,'A'
           ,@newEmployeeId)