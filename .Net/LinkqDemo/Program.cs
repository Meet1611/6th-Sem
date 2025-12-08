// See https://aka.ms/new-console-template for more information
using LinkqDemo;

//List<Person> people = new List<Person>
//{
//    new Person
//    {
//        Name = "Arjun Patel",
//        Age = 28,
//        Department = "Software Development",
//        City = "Ahmedabad",
//        Salary = 60000
//    },
//    new Person
//    {
//        Name = "Neha Sharma",
//        Age = 25,
//        Department = "Human Resources",
//        City = "Delhi",
//        Salary = 70000
//    },
//    new Person
//    {
//        Name = "Diya Sharma",
//        Age = 23,
//        Department = "Human Resources",
//        City = "Ahemdabad",
//        Salary = 60000
//    },
//    new Person
//    {
//        Name = "Rohan Mehta",
//        Age = 32,
//        Department = "Finance",
//        City = "Mumbai",
//        Salary = 50000
//    },
//    new Person
//    {
//        Name = "Isha Verma",
//        Age = 29,
//        Department = "Marketing",
//        City = "Pune",
//        Salary = 80000
//    },
//    new Person
//    {
//        Name = "Karan Singh",
//        Age = 35,
//        Department = "Operations",
//        City = "Bangalore",
//        Salary = 90000
//    },
//    new Person
//    {
//        Name = "Ajeet Singh",
//        Age = 25,
//        Department = "Operations",
//        City = "Bangalore",
//        Salary = 90000
//    }
//};


//Console.WriteLine("----------- 1. person in marketing and operations -------------");
//people
//    .Where(p => p.Department == "Marketing" || p.Department == "Operations")
//    .ToList()
//    .ForEach(p => Console.WriteLine($"Name : {p.Name}, Age : {p.Age}, Department : {p.Department}, City : {p.City}, Salary : {p.Salary}"));

//Console.WriteLine();

//Console.WriteLine("----------- 2. person in age > 30 and city = Mumbai -------------");
//people
//    .Where(p => p.Age > 30 && p.City == "Mumbai")
//    .ToList()
//    .ForEach(p => Console.WriteLine($"Name : {p.Name}, Age : {p.Age}, Department : {p.Department}, City : {p.City}, Salary : {p.Salary}"));

//Console.WriteLine();


//Console.WriteLine("----------- 3. person having age > 28 -------------");
//people
//    .Where(p => p.Age > 28)
//    .ToList()
//    .ForEach(p => Console.WriteLine($"Name : {p.Name}, Age : {p.Age}, Department : {p.Department}, City : {p.City}, Salary : {p.Salary}"));

//Console.WriteLine();


//Console.WriteLine("----------- 4. person in city Delhi and Pune -------------");
//people
//    .Where(p => p.City == "Delhi" || p.City == "Pune")
//    .ToList()
//    .ForEach(p => Console.WriteLine($"Name : {p.Name}, Age : {p.Age}, Department : {p.Department}, City : {p.City}, Salary : {p.Salary}"));

//Console.WriteLine();


//Console.WriteLine("----------- 5. Sort by Age -------------");
//people
//    .OrderBy(p => p.Age)
//    .ToList()
//    .ForEach(p => Console.WriteLine($"Name : {p.Name}, Age : {p.Age}, Department : {p.Department}, City : {p.City}, Salary : {p.Salary}"));

//Console.WriteLine();


//Console.WriteLine("----------- 6. Name starts with 'A' -------------");
//people
//    .Where(p => p.Name.StartsWith('A'))
//    .ToList()
//    .ForEach(p => Console.WriteLine($"Name : {p.Name}, Age : {p.Age}, Department : {p.Department}, City : {p.City}, Salary : {p.Salary}"));

//Console.WriteLine();


//Console.WriteLine("----------- 7. Name contains 'Sh' -------------");
//people
//    .Where(p => p.Name.Contains("Sh"))
//    .ToList()
//    .ForEach(p => Console.WriteLine($"Name : {p.Name}, Age : {p.Age}, Department : {p.Department}, City : {p.City}, Salary : {p.Salary}"));

//Console.WriteLine();


//Console.WriteLine("----------- 8. Min Salary in HR Department  -------------");
//var temp = people
//    .Where(p => p.Department == "Human Resources")
//    .Min(p => p.Salary);

//people
//    .Where(p => p.Salary == temp && p.Department == "Human Resources")
//    .ToList()
//    .ForEach(p => Console.WriteLine($"Name : {p.Name}, Age : {p.Age}, Department : {p.Department}, City : {p.City}, Salary : {p.Salary}"));

//Console.WriteLine();

//Console.WriteLine("----------- 9. Highest Salary ----------");
//var maxSalary = people.Max(x => x.Salary);
//Console.WriteLine($"Max Salary : {maxSalary}");

//Console.WriteLine();

//Console.WriteLine("------ 10. Count by Department ------");
//var groupByDept = people.GroupBy(p => p.Department);

//foreach (var group in groupByDept)
//{
//    Console.WriteLine($"{group.Key}: {group.Count()} person(s)");
//}




var departments = new List<Department>
{
    new Department { DeptId = 1, DeptName = "HR" },
    new Department { DeptId = 2, DeptName = "IT" },
    new Department { DeptId = 3, DeptName = "Finance" },
    new Department { DeptId = 4, DeptName = "Marketing" }
};

var employees = new List<Employee>
{
    new Employee { Id = 101, Name = "Amit",   Age = 28, Salary = 75000, DeptId = 2, Skills = new List<string>{ "C#", "SQL", "Angular" } },
    new Employee { Id = 102, Name = "Neha",   Age = 34, Salary = 95000, DeptId = 2, Skills = new List<string>{ "Java", "C#", "React" } },
    new Employee { Id = 103, Name = "Raj",    Age = 45, Salary = 60000, DeptId = 1, Skills = new List<string>{ "Excel", "Communication" } },
    new Employee { Id = 104, Name = "Priya",  Age = 29, Salary = 82000, DeptId = 3, Skills = new List<string>{ "Accounting", "SQL" } },
    new Employee { Id = 105, Name = "Karan",  Age = 31, Salary = 88000, DeptId = 2, Skills = new List<string>{ "C#", "Azure", "Docker" } },
    new Employee { Id = 106, Name = "Simran", Age = 26, Salary = 72000, DeptId = 4, Skills = new List<string>{ "Design", "Photoshop" } }
};

Console.WriteLine("--------------- 1. Get a list containing only the names of all employees. ---------------------");
// 
var selectByName = employees.Select(employees => employees.Name).ToList();
Console.WriteLine("Employee by name : ");
foreach(var i in selectByName)
{
    Console.WriteLine(i);
}

Console.WriteLine("--------------- 2.Create a list of anonymous objects with each employee's Name and Annual Salary (Salary x 12). ---------------------");

//
var anonymousList = employees.Select(employee => new { employee.Name, AnnualSalary = employee.Salary * 12 }).ToList();
Console.WriteLine("Enonymous employee : ");
foreach(var i in  anonymousList)
{
    Console.WriteLine(i.Name + " " + i.AnnualSalary);
}

Console.WriteLine("--------------- 3. Name and Salary of all employees older than 30 years. ---------------------");
var olderThan30 = employees.Where(employee => employee.Age > 30).Select(employee => new { employee.Name, AnnualSalary = employee.Salary * 12 }).ToList();
foreach (var i in olderThan30)
{
    Console.WriteLine(i.Name, i.AnnualSalary);
}


Console.WriteLine("--------------- 4. Show complete details of all employees who belong to the IT department ---------------------");
var ItID = departments.First(d => d.DeptName == "IT").DeptId;
var ItDepartment = employees.Where(e => e.DeptId == ItID).ToList();
foreach (var i in ItDepartment)
{
    Console.WriteLine(i.Name + " " + i.Age + " " + i.Salary + " " + i.DeptId);
}

Console.WriteLine("--------------- 5. Produce a single fiat list of every skill known by any employee. ---------------------");
var skills = employees.SelectMany(e => e.Skills);
foreach (var sk in skills)
{
    Console.WriteLine(sk);
}

Console.WriteLine("--------------- 6. Get a list of all unique skills present in the company (no duplicates). ---------------------");
var skillsDistinct = employees.DistinctBy(e => e.Skills);
foreach (var sk in skillsDistinct)
{
    Console.WriteLine(sk);
}


//
//
//
//
//7. List all skills known by employees eaming more than 80,000.
//8. Given this mixed list
//nixed = new
//        { •hello - y e.loyees[l],
//            Extract only the actual Employee objects.
//9.From the mixed list above,
//            extract only the names of the Employee objects.
//IO.Retum the first three employees in the current order of the list.
//11.Display the names and salaries of the four highest - paid ernployees.
//999,
//            e.10yees[2]
//        };
//12.Show employees in positions 3 to 5 (pagination — third, fourth, and fifth employees).
//13. Assuming employees are sorted by increasing Age, retum employees until you reach the first one aged 32 or older (do not include that
//person).
//14. Skip all employees eaming 80,000 or more, then retum the remaining employees.
//15. Get the distinct department names that employees belong to.
//16. Find the first employee whose name starts with the lettg
//17. Find the first employee in the Finance department; retum null if none exists.
//18. Retrieve the employee with ld = 103 (ld is unique).
//19. Try to find an employee with ld = 999; retum null if not found.
//20. Check whether there is at least one employee younger than 28 years.
//21. Check whether any employee in the IT department knows the skill "React".
//22. Veri$' whether every employee in the IT department eams more than 70000.
//23. Veri$' whether every employee has at least one skill in their Skills list.
//24. Determine whether the skill "Docker" is known by at least one employee's skill list
//25. Get the names of the three youngest employees who know 'C#', sorted from youngest to oldest.