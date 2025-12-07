create table Department (
	DepID INT IDENTITY(1,1) PRIMARY KEY,
	DepartmentName VARCHAR(100) NOT NULL
)

create table Employee (
	EmpID INT IDENTITY(1,1) PRIMARY KEY,
	EmpName VARCHAR(100) NOT NULL,
	Salary DECIMAL(10, 2) NOT NULL,
	JoiningDate DATETIME NOT NULL,
	City VARCHAR(100) NOT NULL,
	DeptID INT NOT NULL,
	FOREIGN KEY (DeptID) REFERENCES Department(DepID)
)

CREATE PROC PR_Department_SelectAll 
AS 
BEGIN
	SELECT DepID, DepartmentName
	FROM Department
END;

CREATE PROC PR_Department_Delete
@DepID INT
AS 
BEGIN
	DELETE FROM Department
	WHERE DepID = @DepID
END;

ALTER PROCEDURE PR_Employee_SelectAll
AS
BEGIN
    SELECT 
        e.EmpID,
        e.EmpName,
        e.Salary,
        e.DeptID,
        d.DepartmentName      
    FROM Employee e
    INNER JOIN Department d
        ON e.DeptID = d.DepID
END


CREATE PROC PR_Employee_Delete
@EmpID INT
AS 
BEGIN
	DELETE FROM Employee
	WHERE EmpID = @EmpID
END;

CREATE PROC PR_Employee_SelectByID
	@EmpID int
AS
BEGIN
	SELECT
		E.EmpID,
		E.EmpName,
		E.Salary,
		E.City,
		E.JoiningDate
	FROM Employee E
	WHERE E.EmpID = @EmpID
END

CREATE PROCEDURE PR_Employee_Insert
	@EmpName VARCHAR(100),
	@Salary VARCHAR(100),
	@City VARCHAR(100),
	@JoiningDate DATETIME,
	@DeptID INT
AS
BEGIN
    INSERT INTO Employee(EmpName, Salary, JoiningDate, City, DeptID)
    VALUES (@EmpName, @Salary, @JoiningDate, @City, @DeptID);
END

CREATE PROCEDURE PR_Employee_Update
    @EmpID INT,
    @EmpName VARCHAR(100),
	@Salary VARCHAR(100),
	@City VARCHAR(100),
	@JoiningDate DATETIME,
	@DeptID INT
AS
BEGIN
    UPDATE Employee
    SET 
		EmpName = @EmpName,
        Salary = @Salary,
        City = @City,
		JoiningDate = @JoiningDate,
		DeptID = @DeptID
    WHERE EmpID = @EmpID;
END

CREATE OR ALTER PROC PR_Department_SelectByID
	@DepID int
AS
BEGIN
	SELECT
		D.DepID,
		D.DepartmentName
	FROM Department D
	WHERE D.DepID = @DepID
END

CREATE PROCEDURE PR_Department_Insert
	@DepartmentName VARCHAR(100)
AS
BEGIN
    INSERT INTO Department(DepartmentName)
    VALUES (@DepartmentName);
END

CREATE OR ALTER PROCEDURE PR_Department_Update
    @DepID INT,
    @DepartmentName VARCHAR(100)
AS
BEGIN
    UPDATE Department
    SET 
		DepartmentName = @DepartmentName
    WHERE DepID = @DepID;
END

ALTER PROC PR_Employee_Search
	@EmpName VARCHAR(100) = '',
	@Salary DECIMAL(10,2) = 0,
	@JoiningDate DATETIME = NULL,
	@City VARCHAR(100) = '',
	@DepID INT = 0
AS
BEGIN
	SELECT 
		E.EmpID,
		E.EmpName,
		E.Salary,
		E.JoiningDate,
		E.City,
		D.DepartmentName
	FROM Employee E
	INNER JOIN Department D ON E.DeptID = d.DepID
	WHERE 
		(@EmpName = '' OR E.EmpName LIKE '%' + @EmpName + '%')
		AND (@Salary = 0 OR E.Salary >= @Salary)
		AND (@JoiningDate IS NULL OR CAST(E.JoiningDate AS DATE) >= CAST(@JoiningDate AS DATE))
		AND (@City = '' OR E.City LIKE '%' + @City + '%')
		AND (@DepID = 0 OR D.DepID = @DepID)
	ORDER BY E.EmpName
END

