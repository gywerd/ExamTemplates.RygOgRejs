/*  Author: Mads Mikkel Rasmussen. NOTE: @ means variable in SQL'sk.
 *
 * Imagine we have three tables: Employee, ContactInfos and Addresses. An employee has a contact
 * info and an address. But we can't insert into all three tables simultaniously, when we have 
 * auto incremented primary keys on each table. The solution is to use a stored procedure.
 * This stored procedure can do only one thing: Insert three new rows; 
 *	- one in the Employees table,
 *  - and one in the ContactInfos table with the correct foreign key to the row that was inserted 
 *	  in the Employees table, 
 *  - and one in the Addresses table with the correct foreign key to the row that was inserted in 
 *    the Employees table. 
 * The procedure gets 10 arguments that are saved in the parameters. In the following 'the first
 * table' is the table in your business logic that is the Employee table here. In your business 
 * it could perhaps be Journey or something... Here is each part explained:
 *
 *
 * Part A: Creating the procedure, and declaring what parameters it has. Each parameter has an 
 * identifier and a datatype. You should change the parameter list to accomodate your needs.
 *
 * Part B: Two variables are declared. The first is a so-called 'table' variable. It is declared
 * with a single column called Id with datatype INT. The other variable is an INT variable, just 
 * like in ordinary programming languages. You should rename the employeeId to reflect the name
 * of your primary key in the first table.
 * 
 * Part C: The INSERT statement also outputs the new value for the primary key, and stores it in
 * the temporary table variable's first row.
 * 
 * Part D: Simplye get the value for the primary key for the newly insterted employee row, and
 * save it to a variable.
 *
 * Part E: Use the value of the variable as the value for the foreign keys.                      */

-- Part A:
CREATE PROCEDURE CascadeInsert	-- Name of the procedure. 
	@Firstname VARCHAR(30),		-- a parameter to be inserted in Employees table.
	@Lastname VARCHAR(30),		-- a parameter to be inserted in Employees table.
	@Title VARCHAR(30),			-- a parameter to be inserted in Employees table.
	@Initials VARCHAR(10),		-- a parameter to be inserted in Employees table.
	@Email VARCHAR(30),			-- a parameter to be inserted in ContactInfos table.
	@PhoneNumber VARCHAR(11),	-- a parameter to be inserted in ContactInfos table.
	@StreetName VARCHAR(50),	-- a parameter to be inserted in Addresses table.
	@HouseNumber VARCHAR(10),	-- a parameter to be inserted in Addresses table.
	@City VARCHAR(50),			-- a parameter to be inserted in Addresses table.
	@Zip INT					-- a parameter to be inserted in Addresses table.
AS								-- just leave this

-- Part B:
DECLARE @tempIdTable TABLE (Id INT)		-- just leave this.
DECLARE @employeeId INT	-- just rename @employeeId to the name of your first table id column.

-- Part C:
INSERT INTO Employees (FirstName, LastName,Title,Initials)	-- change this accordingly.
	OUTPUT inserted.EmployeeID INTO @tempIdTable(Id)	-- change to inserted.whateverId
	VALUES(@Firstname, @Lastname, @Title, @Initials)

-- Part D:
SELECT @employeeid = FIRST_VALUE(Id) OVER(PARTITION BY Id ORDER BY Id) FROM @tempIdTable --nochange

-- Part E:
INSERT INTO ContactInfos (Email, PhoneNumber, EmployeeID)
	VALUES(@Email, @PhoneNumber, @employeeId)
INSERT INTO Addresses (StreetName, HouseNumber, City, Zip, EmployeeID)
	VALUES(@StreetName, @HouseNumber,@City, @Zip, @employeeId)