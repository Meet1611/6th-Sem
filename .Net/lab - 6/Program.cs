// See https://aka.ms/new-console-template for more information

using lab___6;
using System.Collections.Generic;

var students = new List<Student>
{
     new Student { Rno = 1, Name = "Amit", Branch = "CE", Sem = 3, CPI = 8 },
     new Student { Rno = 3, Name = "Rahul", Branch = "CE", Sem = 1, CPI = 7 },
    new Student { Rno = 4, Name = "Sneha", Branch = "ME", Sem = 7, CPI = 8 },
         new Student { Rno = 2, Name = "Priya", Branch = "IT", Sem = 5, CPI = 9 },
         new Student { Rno = 5, Name = "Karan", Branch = "IT", Sem = 3, CPI = 6 }
};

var courses = new List<Course>
{
 new Course { Rno = 1, CourseName = "DBMS", Credits = 4 },
 new Course { Rno = 1, CourseName = "C#", Credits = 3 },
 new Course { Rno = 2, CourseName = "Java", Credits = 4 },
 new Course { Rno = 3, CourseName = "Python", Credits = 3 },
 new Course { Rno = 5, CourseName = "AI", Credits = 5 }
};

// ------------------- SEction 1 -------------------------

//1.Get all CE branch students.
Console.WriteLine("----------------- 1.Get all CE branch students. -------------");
var CEStd = students.Where(s => s.Branch == "CE")
                    .Select(s => new { s.Rno, s.Name, s.Branch })
                    .ToList();
foreach (var student in CEStd)
{
    Console.WriteLine("Rno : " + student.Rno + ", Name : " + student.Name + ", Branch : " + student.Branch);
}

//2. Students having CPI > 8.
Console.WriteLine("----------------- 2. Students having CPI > 8. -------------");
var studentsCPI8 = students.Where(s => s.CPI > 8)
                            .Select(s => new { s.Rno, s.Name, s.CPI})
                            .ToList();
foreach (var student in studentsCPI8)
{
    Console.WriteLine("Rno : " + student.Rno + ", Name : " + student.Name + ", CPI : " + student.CPI);
}

//3. Students older than 20.
Console.WriteLine("----------------- 3. Students older than 20. -------------");
var ageAbove20 = students.Where(s => s.Age > 20)
                         .Select(s => new { s.Rno, s.Name, s.Age })
                         .ToList();
foreach (var student in ageAbove20)
{
    Console.WriteLine("Rno : " + student.Rno + ", Name : " + student.Name + ", Age : " + student.Age);
}


//4. Students in Semester 3.
Console.WriteLine("----------------- 4. Students in Semester 3. -------------");
var sem3 = students.Where(s => s.Sem == 3)
                   .Select(s => new { s.Rno, s.Name, s.Sem })
                   .ToList();
foreach (var student in sem3)
{
    Console.WriteLine("Rno : " + student.Rno + ", Name : " + student.Name + ", Sem : " + student.Sem);
}

//5. CPI between 7 and 9.
Console.WriteLine("----------------- 5. CPI between 7 and 9. -------------");
var cpi7to9 = students.Where(s => s.CPI >= 7 && s.CPI <= 9)
                      .Select(s => new { s.Rno, s.Name, s.CPI })
                      .ToList();
foreach (var student in cpi7to9)
{
    Console.WriteLine("Rno : " + student.Rno + ", Name : " + student.Name + ", CPI : " + student.CPI);
}

//6. Name starting with 'A'.
Console.WriteLine("----------------- 6. Name starting with 'A'. -------------");
var nameStartsA = students.Where(s => s.Name.StartsWith("A"))
                          .Select(s => new { s.Rno, s.Name })
                          .ToList();
foreach (var student in nameStartsA)
{
    Console.WriteLine("Rno : " + student.Rno + ", Name : " + student.Name);
}

//7. Branch = IT AND Sem = 3.
Console.WriteLine("----------------- 7. Branch = IT AND Sem = 3. -------------");
var itSem3 = students.Where(s => s.Branch == "IT" && s.Sem == 3)
                     .Select(s => new { s.Rno, s.Name, s.Branch, s.Sem })
                     .ToList();
foreach (var student in itSem3)
{
    Console.WriteLine("Rno : " + student.Rno + ", Name : " + student.Name + ", Branch : " + student.Branch + ", Sem : " + student.Sem);
}

//8. Age < 20 OR CPI > 8.
Console.WriteLine("----------------- 8. Age < 20 OR CPI > 8. -------------");
var ageOrCpi = students.Where(s => s.Age < 20 || s.CPI > 8)
                       .Select(s => new { s.Rno, s.Name, s.Age, s.CPI })
                       .ToList();
foreach (var student in ageOrCpi)
{
    Console.WriteLine("Rno : " + student.Rno + ", Name : " + student.Name + ", Age : " + student.Age + ", CPI : " + student.CPI);
}

//9. Names containing 'a'.
Console.WriteLine("----------------- 9. Names containing 'a'. -------------");
var containsA = students.Where(s => s.Name.ToLower().Contains("a"))
                        .Select(s => new { s.Rno, s.Name })
                        .ToList();
foreach (var student in containsA)
{
    Console.WriteLine("Rno : " + student.Rno + ", Name : " + student.Name);
}

//10. Students NOT in CE.
Console.WriteLine("----------------- 10. Students NOT in CE. -------------");
var notCE = students.Where(s => s.Branch != "CE")
                    .Select(s => new { s.Rno, s.Name, s.Branch })
                    .ToList();
foreach (var student in notCE)
{
    Console.WriteLine("Rno : " + student.Rno + ", Name : " + student.Name + ", Branch : " + student.Branch);
}

//11. Sem in {1,3,5}.
Console.WriteLine("----------------- 11. Sem in {1, 3, 5}. -------------");
var sem135 = students.Where(s => s.Sem == 1 || s.Sem == 3 || s.Sem == 5)
                     .Select(s => new { s.Rno, s.Name, s.Sem })
                     .ToList();
foreach (var student in sem135)
{
    Console.WriteLine("Rno : " + student.Rno + ", Name : " + student.Name + ", Sem : " + student.Sem);
}

//12.Students whose CPI is a whole number.
Console.WriteLine("----------------- 12. CPI is a whole number. -------------");
var wholeCpi = students.Where(s => s.CPI == Math.Floor(s.CPI))
                       .Select(s => new { s.Rno, s.Name, s.CPI })
                       .ToList();
foreach (var student in wholeCpi)
{
    Console.WriteLine("Rno : " + student.Rno + ", Name : " + student.Name + ", CPI : " + student.CPI);
}

//13. Students with even Roll No.
Console.WriteLine("----------------- 13. Students with even Roll No. -------------");
var evenRno = students.Where(s => s.Rno % 2 == 0)
                      .Select(s => new { s.Sem, s.Name, s.Rno })
                      .ToList();
foreach (var student in evenRno)
{
    Console.WriteLine("Rno : " + student.Rno + ", Name : " + student.Name + ", Sem : " + student.Sem);
}

//14. Students whose age is between 18 and 21.
Console.WriteLine("----------------- 14. Age between 18 and 21. -------------");
var age18to21 = students.Where(s => s.Age >= 18 && s.Age <= 21)
                        .Select(s => new { s.Rno, s.Name, s.Age })
                        .ToList();
foreach (var student in age18to21)
{
    Console.WriteLine("Rno : " + student.Rno + ", Name : " + student.Name + ", Age : " + student.Age);
}

//15. Students having name length > 4.
Console.WriteLine("----------------- 15. Students having name length > 4. -------------");
var longNames = students.Where(s => s.Name.Length > 4)
                        .Select(s => new { s.Rno, s.Name })
                        .ToList ();

foreach (var student in longNames)
{
    Console.WriteLine("Rno : " + student.Rno + ", Name : " + student.Name);
}

//16.Select only names.
Console.WriteLine("----------------- 16. Select only names. -------------");
var onlyNames = students.Select(s => new { s.Name }).ToList();
foreach (var student in onlyNames)
{
    Console.WriteLine("Name : " + student.Name);
}


//17.Select Name + CPI.
Console.WriteLine("----------------- 17. Select Name + CPI. -------------");
var nameCpi = students.Select(s => new { s.Name, s.CPI }).ToList();
foreach (var student in nameCpi)
{
    Console.WriteLine("Name : " + student.Name + ", CPI : " + student.CPI);
}

//18.Select Roll No + Branch.
Console.WriteLine("----------------- 18. Select Roll No + Branch. -------------");
var rnoBranch = students.Select(s => new { s.Rno, s.Branch }).ToList();
foreach (var student in rnoBranch)
{
    Console.WriteLine("Rno : " + student.Rno + ", Branch : " + student.Branch);
}

//19. Select anonymous type: Name, Sem, Age.
Console.WriteLine("----------------- 19. Anonymous type: Name, Sem, Age. -------------");
var nameSemAge = students.Select(s => new { s.Name, s.Sem, s.Age }).ToList();
foreach (var student in nameSemAge)
{
    Console.WriteLine("Name : " + student.Name + ", Sem : " + student.Sem + ", Age : " + student.Age);
}

//20. Create 'FullInfo' string (e.g., "Name (Branch)").
Console.WriteLine("----------------- 20. Create 'FullInfo' string. -------------");
var fullInfo = students.Select(s => new { FullInfo = s.Name + " (" + s.Branch + ")" }).ToList();
foreach (var student in fullInfo)
{
    Console.WriteLine("FullInfo : " + student.FullInfo);
}

//21. Project all to CPI only.
Console.WriteLine("----------------- 21. Project all to CPI only. -------------");
var onlyCpi = students.Select(s => new { s.CPI }).ToList();
foreach (var student in onlyCpi)
{
    Console.WriteLine("CPI : " + student.CPI);
}

//22. Select Name in lowercase.
Console.WriteLine("----------------- 22. Select Name in lowercase. -------------");
var lowerNames = students.Select(s => new { Name = s.Name.ToLower() }).ToList();
foreach (var student in lowerNames)
{
    Console.WriteLine("Name : " + student.Name);
}

//23. Select Name + Status based on CPI (Good/Average).
Console.WriteLine("----------------- 23. Select Name + Status. -------------");
var nameStatus = students.Select(s => new
{
    s.Name,
    Status = s.CPI >= 8 ? "Good" : "Average"
}).ToList();

foreach (var student in nameStatus)
{
    Console.WriteLine("Name : " + student.Name + ", Status : " + student.Status);
}

//24. Extract only distinct branches.
Console.WriteLine("----------------- 24. Extract distinct branches. -------------");
var distinctBranches = students.Select(s => s.Branch).Distinct().ToList();
foreach (var branch in distinctBranches)
{
    Console.WriteLine("Branch : " + branch);
}

//25. Convert student to “DTO” format (Rno, Name).
Console.WriteLine("----------------- 25. Convert to DTO format. -------------");
var dtoStudents = students.Select(s => new { s.Rno, s.Name }).ToList();
foreach (var student in dtoStudents)
{
    Console.WriteLine("Rno : " + student.Rno + ", Name : " + student.Name);
}

//26.Sort names alphabetically.
Console.WriteLine("----------------- 26.Sort names alphabetically. -------------");
var sortedNames = students.OrderByDescending(students => students.Name).ToList(); 
foreach (var student in sortedNames)
{
    Console.WriteLine("Name : " + student.Name);
}

//27.Sort by CPI descending.
Console.WriteLine("----------------- 27. Sort by CPI descending. -------------");
var sortCpiDesc = students.OrderByDescending(s => s.CPI)
                          .Select(s => new { s.Rno, s.Name, s.CPI })
                          .ToList();
foreach (var student in sortCpiDesc)
{
    Console.WriteLine("Rno : " + student.Rno + ", Name : " + student.Name + ", CPI : " + student.CPI);
}

//28. Sort by Sem, then Name.
Console.WriteLine("----------------- 28. Sort by Sem, then Name. -------------");
var sortSemName = students.OrderBy(s => s.Sem)
                          .ThenBy(s => s.Name)
                          .Select(s => new { s.Rno, s.Name, s.Sem })
                          .ToList();
foreach (var student in sortSemName)
{
    Console.WriteLine("Rno : " + student.Rno + ", Name : " + student.Name + ", Sem : " + student.Sem);
}

//29. Sort by Age, then CPI desc.
Console.WriteLine("----------------- 29. Sort by Age, then CPI desc. -------------");
var sortAgeCpi = students.OrderBy(s => s.Age)
                         .ThenByDescending(s => s.CPI)
                         .Select(s => new { s.Rno, s.Name, s.Age, s.CPI })
                         .ToList();
foreach (var student in sortAgeCpi)
{
    Console.WriteLine("Rno : " + student.Rno + ", Name : " + student.Name + ", Age : " + student.Age + ", CPI : " + student.CPI);
}

//30. Sort by Branch.
Console.WriteLine("----------------- 30. Sort by Branch. -------------");
var sortBranch = students.OrderBy(s => s.Branch)
                         .Select(s => new { s.Rno, s.Name, s.Branch })
                         .ToList();
foreach (var student in sortBranch)
{
    Console.WriteLine("Rno : " + student.Rno + ", Name : " + student.Name + ", Branch : " + student.Branch);
}

//31. Sort by Name length.
Console.WriteLine("----------------- 31. Sort by Name length. -------------");
var sortNameLength = students.OrderBy(s => s.Name.Length)
                             .Select(s => new { s.Rno, s.Name })
                             .ToList();
foreach (var student in sortNameLength)
{
    Console.WriteLine("Rno : " + student.Rno + ", Name : " + student.Name);
}

//32. Sort by Sem DESC.
Console.WriteLine("----------------- 32. Sort by Sem DESC. -------------");
var sortSemDesc = students.OrderByDescending(s => s.Sem)
                          .Select(s => new { s.Rno, s.Name, s.Sem })
                          .ToList();
foreach (var student in sortSemDesc)
{
    Console.WriteLine("Rno : " + student.Rno + ", Name : " + student.Name + ", Sem : " + student.Sem);
}

//33. Sort by CPI then Age.
Console.WriteLine("----------------- 33. Sort by CPI then Age. -------------");
var sortCpiAge = students.OrderBy(s => s.CPI)
                         .ThenBy(s => s.Age)
                         .Select(s => new { s.Rno, s.Name, s.CPI, s.Age })
                         .ToList();
foreach (var student in sortCpiAge)
{
    Console.WriteLine("Rno : " + student.Rno + ", Name : " + student.Name + ", CPI : " + student.CPI + ", Age : " + student.Age);
}

//34. Sort by Rno descending.
Console.WriteLine("----------------- 34. Sort by Rno descending. -------------");
var sortRnoDesc = students.OrderByDescending(s => s.Rno)
                          .Select(s => new { s.Rno, s.Name })
                          .ToList();
foreach (var student in sortRnoDesc)
{
    Console.WriteLine("Rno : " + student.Rno + ", Name : " + student.Name);
}

//35. Sort by Branch then Sem.
Console.WriteLine("----------------- 35. Sort by Branch then Sem. -------------");
var sortBranchSem = students.OrderBy(s => s.Branch)
                            .ThenBy(s => s.Sem)
                            .Select(s => new { s.Rno, s.Name, s.Branch, s.Sem })
                            .ToList();
foreach (var student in sortBranchSem)
{
    Console.WriteLine("Rno : " + student.Rno + ", Name : " + student.Name + ", Branch : " + student.Branch + ", Sem : " + student.Sem);
}

//36.Count total students.
Console.WriteLine("----------------- 36. Count total students. -------------");
var totalStudents = students.Count();
Console.WriteLine("Total Students : " + totalStudents);

//37.Count CE students.
Console.WriteLine("----------------- 37. Count CE students. -------------");
var ceCount = students.Count(s => s.Branch == "CE");
Console.WriteLine("CE Students : " + ceCount);

//38.Max CPI.
Console.WriteLine("----------------- 39. Min CPI. -------------");
var maxCpi = students.Min(s => s.CPI);
Console.WriteLine("Min CPI : " + maxCpi);

//39.Min CPI.
Console.WriteLine("----------------- 39. Min CPI. -------------");
var minCpi = students.Min(s => s.CPI);
Console.WriteLine("Min CPI : " + minCpi);

//40.Average CPI.
Console.WriteLine("----------------- 40. Average CPI. -------------");
var avgCpi = students.Average(s => s.CPI);
Console.WriteLine("Average CPI : " + avgCpi);

Console.WriteLine("---------------41. Total credits for Rno = 1-------------");

var totalCredits = courses
    .Where(c => c.Rno == 1)
    .Sum(c => c.Credits);

Console.WriteLine($"Total Credits : {totalCredits}");

//42. Oldest student's age.
Console.WriteLine("----------------- 42. Oldest student's age. -------------");
var oldestAge = students.Max(s => s.Age);
Console.WriteLine("Oldest Age : " + oldestAge);

//43. Youngest student's age.
Console.WriteLine("----------------- 43. Youngest student's age. -------------");
var youngestAge = students.Min(s => s.Age);
Console.WriteLine("Youngest Age : " + youngestAge);
}

//44. Highest Sem.
Console.WriteLine("----------------- 44. Highest Sem. -------------");
var highestSem = students.Max(s => s.Sem);
Console.WriteLine("Highest Semester : " + highestSem);

//45. Sum of all credits.
Console.WriteLine("----------------- 45. Sum of all credits. -------------");
var totalCredits = students.Sum(s => s.Credits);
Console.WriteLine("Total Credits : " + totalCredits);

//46.Get first student.
Console.WriteLine("----------------- 46. Get first student. -------------");
var firstStudent = students.First();
Console.WriteLine("Rno : " + firstStudent.Rno + ", Name : " + firstStudent.Name + ", Branch : " + firstStudent.Branch);

//47.First student with CPI > 9.
Console.WriteLine("----------------- 47. First student with CPI > 9. -------------");
var firstCpiAbove9 = students.First(s => s.CPI > 9);
Console.WriteLine("Rno : " + firstCpiAbove9.Rno + ", Name : " + firstCpiAbove9.Name + ", CPI : " + firstCpiAbove9.CPI);

//48. Last student.
Console.WriteLine("----------------- 48. Last student. -------------");
var lastStudent = students.Last();
Console.WriteLine("Rno : " + lastStudent.Rno + ", Name : " + lastStudent.Name + ", Branch : " + lastStudent.Branch);

//49. Get student at index 2.
Console.WriteLine("----------------- 49. Get student at index 2. -------------");
var studentIndex2 = students.ElementAt(2);
Console.WriteLine("Rno : " + studentIndex2.Rno + ", Name : " + studentIndex2.Name + ", Branch : " + studentIndex2.Branch);

//50. Single student with Rno = 3.
Console.WriteLine("----------------- 50. Single student with Rno = 3. -------------");
var singleRno3 = students.Single(s => s.Rno == 3);
Console.WriteLine("Rno : " + singleRno3.Rno + ", Name : " + singleRno3.Name + ", Branch : " + singleRno3.Branch);

//51. Safe single (e.g., Rno = 10).
Console.WriteLine("----------------- 51. Safe single (Rno = 10). -------------");
var safeSingle = students.SingleOrDefault(s => s.Rno == 10);
if (safeSingle != null)
{
    Console.WriteLine("Rno : " + safeSingle.Rno + ", Name : " + safeSingle.Name);
}
else
{
    Console.WriteLine("No student found with Rno = 10");
}

//52. First IT student.
Console.WriteLine("----------------- 52. First IT student. -------------");
var firstIT = students.First(s => s.Branch == "IT");
Console.WriteLine("Rno : " + firstIT.Rno + ", Name : " + firstIT.Name + ", Branch : " + firstIT.Branch);

//53. Last CE student.
Console.WriteLine("----------------- 53. Last CE student. -------------");
var lastCE = students.Last(s => s.Branch == "CE");
Console.WriteLine("Rno : " + lastCE.Rno + ", Name : " + lastCE.Name + ", Branch : " + lastCE.Branch);

//54. First student older than 18.
Console.WriteLine("----------------- 54. First student older than 18. -------------");
var firstOlder18 = students.First(s => s.Age > 18);
Console.WriteLine("Rno : " + firstOlder18.Rno + ", Name : " + firstOlder18.Name + ", Age : " + firstOlder18.Age);

//55. Element at index 0
Console.WriteLine("----------------- 55. Element at index 0. -------------");
var index0 = students.ElementAt(0);
Console.WriteLine("Rno : " + index0.Rno + ", Name : " + index0.Name + ", Branch : " + index0.Branch);

Console.WriteLine("---------------56. Any CE students?-------------");

var anyCE = students.Any(s => s.Branch == "CE");

Console.WriteLine($"Any CE Students : {anyCE}");

Console.WriteLine("---------------57. All students older than 17?-------------");

var allOlder17 = students.All(s => s.Age > 17);

Console.WriteLine($"All > 17 : {allOlder17}");

Console.WriteLine("---------------58. Any CPI > 9?-------------");

var anyCpiAbove9 = students.Any(s => s.CPI > 9);

Console.WriteLine($"Any CPI > 9 : {anyCpiAbove9}");


Console.WriteLine("---------------59. All semesters > 0?-------------");

var allSemPositive = students.All(s => s.Sem > 0);

Console.WriteLine($"All Sem > 0 : {allSemPositive}");


Console.WriteLine("---------------60. Any student with name length > 6?-------------");

var anyLongName = students.Any(s => s.Name.Length > 6);

Console.WriteLine($"Any Name > 6 letters : {anyLongName}");


Console.WriteLine("---------------61. All belong to CE?-------------");

var allCE = students.All(s => s.Branch == "CE");

Console.WriteLine($"All CE : {allCE}");

Console.WriteLine("---------------62. Any course with credits > 4?-------------");

var anyCreditMore4 = courses.Any(c => c.Credits > 4);

Console.WriteLine($"Any Credits > 4 : {anyCreditMore4}");

Console.WriteLine("---------------63. All credits > 2?-------------");

var allCreditsMore2 = courses.All(c => c.Credits > 2);

Console.WriteLine($"All Credits > 2 : {allCreditsMore2}");

Console.WriteLine("---------------64. Any course named 'Java'?-------------");

var anyJava = courses.Any(c => c.CourseName == "Java");

Console.WriteLine($"Any Java Course : {anyJava}");

Console.WriteLine("---------------65. Any student younger than 18?-------------");

var anyBelow18 = students.Any(s => s.Age < 18);

Console.WriteLine($"Any Age < 18 : {anyBelow18}");


Console.WriteLine("---------------66. Group students by Branch-------------");

var groupByBranch = students
    .GroupBy(s => s.Branch)
    .ToList();

foreach (var group in groupByBranch)
{
    Console.WriteLine($"Branch : {group.Key}");
    foreach (var s in group)
    {
        Console.WriteLine($"   Rno : {s.Rno}, Name : {s.Name}");
    }
}


Console.WriteLine("---------------67. Group students by Semester-------------");

var groupBySem = students
    .GroupBy(s => s.Sem)
    .ToList();

foreach (var group in groupBySem)
{
    Console.WriteLine($"Semester : {group.Key}");
    foreach (var s in group)
    {
        Console.WriteLine($"   Rno : {s.Rno}, Name : {s.Name}");
    }
}

Console.WriteLine("---------------68. Group students by Age-------------");

var groupByAge = students
    .GroupBy(s => s.Age)
    .ToList();

foreach (var group in groupByAge)
{
    Console.WriteLine($"Age : {group.Key}");
    foreach (var s in group)
    {
        Console.WriteLine($"   Rno : {s.Rno}, Name : {s.Name}");
    }
}

Console.WriteLine("---------------69. Group students by CPI Category-------------");

var groupByCpiCategory = students
    .GroupBy(s => s.CPI >= 8 ? "High" : "Low")
    .ToList();

foreach (var group in groupByCpiCategory)
{
    Console.WriteLine($"Category : {group.Key}");
    foreach (var s in group)
    {
        Console.WriteLine($"   Name : {s.Name}, CPI : {s.CPI}");
    }
}

Console.WriteLine("---------------70. Group courses by Rno-------------");

var groupCoursesByRno = courses
    .GroupBy(c => c.Rno)
    .ToList();

foreach (var group in groupCoursesByRno)
{
    Console.WriteLine($"Rno : {group.Key}");
    foreach (var c in group)
    {
        Console.WriteLine($"   Course : {c.CourseName}, Credits : {c.Credits}");
    }
}

Console.WriteLine("---------------71. Group students by first letter of Name-------------");

var groupByFirstLetter = students
    .GroupBy(s => s.Name[0])
    .ToList();

foreach (var group in groupByFirstLetter)
{
    Console.WriteLine($"Letter : {group.Key}");
    foreach (var s in group)
    {
        Console.WriteLine($"   Name : {s.Name}");
    }
}


Console.WriteLine("---------------72. Group students by Branch then Semester-------------");

var groupBranchSem = students
    .GroupBy(s => new { s.Branch, s.Sem })
    .ToList();

foreach (var group in groupBranchSem)
{
    Console.WriteLine($"Branch : {group.Key.Branch}, Sem : {group.Key.Sem}");
    foreach (var s in group)
    {
        Console.WriteLine($"   Rno : {s.Rno}, Name : {s.Name}");
    }
}

Console.WriteLine("---------------73. Group students by Age Range-------------");

var groupByAgeRange = students
    .GroupBy(s => s.Age < 20 ? "Teen" : "Adult")
    .ToList();

foreach (var group in groupByAgeRange)
{
    Console.WriteLine($"Range : {group.Key}");
    foreach (var s in group)
    {
        Console.WriteLine($"   Name : {s.Name}, Age : {s.Age}");
    }
}

Console.WriteLine("---------------74. Group courses by Credits-------------");

var groupByCredits = courses
    .GroupBy(c => c.Credits)
    .ToList();

foreach (var group in groupByCredits)
{
    Console.WriteLine($"Credits : {group.Key}");
    foreach (var c in group)
    {
        Console.WriteLine($"   Course : {c.CourseName}");
    }
}

Console.WriteLine("---------------75. Group students by Rounded CPI-------------");

var groupByRoundedCpi = students
    .GroupBy(s => Math.Round(s.CPI))
    .ToList();

foreach (var group in groupByRoundedCpi)
{
    Console.WriteLine($"Rounded CPI : {group.Key}");
    foreach (var s in group)
    {
        Console.WriteLine($"   Name : {s.Name}, CPI : {s.CPI}");
    }
}


Console.WriteLine("---------------76. Inner Join students + courses-------------");

var innerJoin = students
    .Join(courses,
          s => s.Rno,
          c => c.Rno,
          (s, c) => new { s.Rno, s.Name, c.CourseName, c.Credits })
    .ToList();

foreach (var item in innerJoin)
{
    Console.WriteLine($"Rno : {item.Rno}, Name : {item.Name}, Course : {item.CourseName}, Credits : {item.Credits}");
}


Console.WriteLine("---------------77. Total credits per student-------------");

var creditsPerStudent = students
    .GroupJoin(
        courses,
        s => s.Rno,
        c => c.Rno,
        (s, c) => new { s.Rno, s.Name, TotalCredits = c.Sum(x => x.Credits) }
    )
    .ToList();

foreach (var item in creditsPerStudent)
{
    Console.WriteLine($"Rno : {item.Rno}, Name : {item.Name}, Total Credits : {item.TotalCredits}");
}


Console.WriteLine("---------------78. Students with Courses-------------");

var studentCourses = students
    .Join(courses,
          s => s.Rno,
          c => c.Rno,
          (s, c) => new { s.Name, c.CourseName, c.Credits })
    .ToList();

foreach (var item in studentCourses)
{
    Console.WriteLine($"Name : {item.Name}, Course : {item.CourseName}, Credits : {item.Credits}");
}


Console.WriteLine("---------------79. Left Join Students + Courses-------------");

var leftJoin = students
    .GroupJoin(
        courses,
        s => s.Rno,
        c => c.Rno,
        (s, c) => new { s, c }
    )
    .SelectMany(
        x => x.c.DefaultIfEmpty(),
        (x, c) => new
        {
            x.s.Rno,
            x.s.Name,
            CourseName = c?.CourseName ?? "No Course",
            Credits = c?.Credits ?? 0
        }
    )
    .ToList();

foreach (var item in leftJoin)
{
    Console.WriteLine($"Rno : {item.Rno}, Name : {item.Name}, Course : {item.CourseName}, Credits : {item.Credits}");
}


Console.WriteLine("---------------80. Distinct Courses-------------");

var distinctCourses = courses
    .Select(c => c.CourseName)
    .Distinct()
    .ToList();

foreach (var courseName in distinctCourses)
{
    Console.WriteLine($"Course : {courseName}");
}


Console.WriteLine("---------------81. Students having more than 1 Course-------------");

var moreThanOneCourse = courses
    .GroupBy(c => c.Rno)
    .Where(g => g.Count() > 1)
    .Join(students,
          g => g.Key,
          s => s.Rno,
          (g, s) => new { s.Rno, s.Name, CourseCount = g.Count() })
    .ToList();

foreach (var item in moreThanOneCourse)
{
    Console.WriteLine($"Rno : {item.Rno}, Name : {item.Name}, Courses : {item.CourseCount}");
}


Console.WriteLine("---------------82. Join Students + Courses Ordered by Credits-------------");

var joinOrderedByCredits = students
    .Join(courses,
          s => s.Rno,
          c => c.Rno,
          (s, c) => new { s.Name, c.CourseName, c.Credits })
    .OrderByDescending(x => x.Credits)
    .ToList();

foreach (var item in joinOrderedByCredits)
{
    Console.WriteLine($"Name : {item.Name}, Course : {item.CourseName}, Credits : {item.Credits}");
}


Console.WriteLine("---------------83. IT Students with Courses-------------");

var itStudentsWithCourses = students
    .Where(s => s.Branch == "IT")
    .Join(courses,
          s => s.Rno,
          c => c.Rno,
          (s, c) => new { s.Name, s.Branch, c.CourseName, c.Credits })
    .ToList();

foreach (var item in itStudentsWithCourses)
{
    Console.WriteLine($"Name : {item.Name}, Branch : {item.Branch}, Course : {item.CourseName}, Credits : {item.Credits}");
}

Console.WriteLine("---------------84. Students Who Have No Course-------------");

var noCourseStudents = students
    .GroupJoin(
        courses,
        s => s.Rno,
        c => c.Rno,
        (s, c) => new { s, c }
    )
    .Where(x => !x.c.Any())
    .Select(x => new { x.s.Rno, x.s.Name })
    .ToList();

foreach (var item in noCourseStudents)
{
    Console.WriteLine($"Rno : {item.Rno}, Name : {item.Name}");
}


Console.WriteLine("---------------85. Students with Number of Courses-------------");

var courseCountPerStudent = students
    .GroupJoin(
        courses,
        s => s.Rno,
        c => c.Rno,
        (s, c) => new { s.Rno, s.Name, CourseCount = c.Count() }
    )
    .ToList();

foreach (var item in courseCountPerStudent)
{
    Console.WriteLine($"Rno : {item.Rno}, Name : {item.Name}, Course Count : {item.CourseCount}");
}


Console.WriteLine("---------------86. Distinct Branches-------------");

var distinctBranchs = students
    .Select(s => s.Branch)
    .Distinct()
    .ToList();

foreach (var b in distinctBranchs)
{
    Console.WriteLine($"Branch : {b}");
}

Console.WriteLine("---------------87. Students in CE or IT (Union)-------------");

var ceStudents = students.Where(s => s.Branch == "CE");
var itStudents = students.Where(s => s.Branch == "IT");

var unionResult = ceStudents
    .Union(itStudents)
    .Select(s => new { s.Rno, s.Name, s.Branch })
    .ToList();

foreach (var s in unionResult)
{
    Console.WriteLine($"Rno : {s.Rno}, Name : {s.Name}, Branch : {s.Branch}");
}


Console.WriteLine("---------------88. Students in CE but not IT (Except)-------------");

var ceOnly = ceStudents
    .Select(s => s)
    .Except(itStudents)
    .ToList();

foreach (var s in ceOnly)
{
    Console.WriteLine($"Rno : {s.Rno}, Name : {s.Name}, Branch : {s.Branch}");
}


Console.WriteLine("---------------89. Common Semesters (CE ∩ IT)-------------");

var ceSem = ceStudents.Select(s => s.Sem);
var itSem = itStudents.Select(s => s.Sem);

var semIntersect = ceSem.Intersect(itSem).ToList();

foreach (var sem in semIntersect)
{
    Console.WriteLine($"Common Sem : {sem}");
}

Console.WriteLine("---------------90. Courses with Credits != 3-------------");

var coursesNot3 = courses
    .Where(c => c.Credits != 3)
    .Select(c => new { c.CourseName, c.Credits })
    .ToList();

foreach (var c in coursesNot3)
{
    Console.WriteLine($"Course : {c.CourseName}, Credits : {c.Credits}");
}

Console.WriteLine("---------------91. Convert Students to List-------------");

var studentList = students.ToList();

foreach (var s in studentList)
{
    Console.WriteLine($"Rno : {s.Rno}, Name : {s.Name}");
}


Console.WriteLine("---------------92. Convert to Dictionary (Rno → Name)-------------");

var dict = students
    .ToDictionary(s => s.Rno, s => s.Name);

foreach (var item in dict)
{
    Console.WriteLine($"Rno : {item.Key}, Name : {item.Value}");
}


Console.WriteLine("---------------93. Convert Names to Array-------------");

var nameArray = students
    .Select(s => s.Name)
    .ToArray();

foreach (var name in nameArray)
{
    Console.WriteLine($"Name : {name}");
}


Console.WriteLine("---------------94. Create Lookup (Rno → Courses)-------------");

var courseLookup = courses
    .ToLookup(c => c.Rno);

foreach (var group in courseLookup)
{
    Console.WriteLine($"Rno : {group.Key}");
    foreach (var c in group)
    {
        Console.WriteLine($"   Course : {c.CourseName}, Credits : {c.Credits}");
    }
}


Console.WriteLine("---------------95. Branch HashSet-------------");

var branchSet = students
    .Select(s => s.Branch)
    .ToHashSet();

foreach (var b in branchSet)
{
    Console.WriteLine($"Branch : {b}");
}


Console.WriteLine("---------------96. Top 2 Highest CPI Students-------------");

var top2CPI = students
    .OrderByDescending(s => s.CPI)
    .Take(2)
    .Select(s => new { s.Rno, s.Name, s.CPI })
    .ToList();

foreach (var s in top2CPI)
{
    Console.WriteLine($"Rno : {s.Rno}, Name : {s.Name}, CPI : {s.CPI}");
}


Console.WriteLine("---------------97. Skip 2, Take 2-------------");

var skipTake = students
    .Skip(2)
    .Take(2)
    .ToList();

foreach (var s in skipTake)
{
    Console.WriteLine($"Rno : {s.Rno}, Name : {s.Name}");
}


Console.WriteLine("---------------98. Student with Max CPI-------------");

var maxCpiStudent = students
    .OrderByDescending(s => s.CPI)
    .First();

Console.WriteLine($"Rno : {maxCpiStudent.Rno}, Name : {maxCpiStudent.Name}, CPI : {maxCpiStudent.CPI}");


Console.WriteLine("---------------99. Students Sorted by Course Count-------------");

var studentsSortedByCourseCount = students
    .GroupJoin(
        courses,
        s => s.Rno,
        c => c.Rno,
        (s, c) => new { s.Rno, s.Name, CourseCount = c.Count() }
    )
    .OrderByDescending(x => x.CourseCount)
    .ToList();

foreach (var s in studentsSortedByCourseCount)
{
    Console.WriteLine($"Rno : {s.Rno}, Name : {s.Name}, Courses : {s.CourseCount}");
}


Console.WriteLine("---------------100. Students grouped by Branch and sorted by CPI-------------");

var groupBranchSortCpi = students
    .GroupBy(s => s.Branch)
    .ToList();

foreach (var group in groupBranchSortCpi)
{
    Console.WriteLine($"Branch : {group.Key}");

    foreach (var s in group.OrderByDescending(x => x.CPI))
    {
        Console.WriteLine($"   Name : {s.Name}, CPI : {s.CPI}");
    }
}