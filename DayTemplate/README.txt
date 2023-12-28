To start a new day:
Copy DayTemplate Folder/Project and rename it with the day to complete (ranger oder sowas)
    Also rename the .csproj file
    In rider AdventOfCode (right click) -> Add -> existing Project -> neues .csproj auswählen
    Also add the new testinput and finalinput
    Change the namespace within Program.cs and Part1.cs
    Change DayTemplate day before the ProcessInput call in Part1.cs
Copy TestAllDays/TestTemplate.cs to TestAllDays/dayxy.cs and add your new tests here
    Right click on the TestAllDays project -> add -> Reference -> select new Project
    Replace the topmost using
    Rename class (public class Test)
    Add solution of the example to test
run dotnet restore
Push to git?
Write the new tests and start coding
