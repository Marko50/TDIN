# Instructions

## With Makefile

`make`

## Without Makefile

Description of the commands listed in the c# Makefile and how to compile this solution without the makefile.

### Compile

1. Compile the target **libraries** for the main project with:
   - `csc -target:library lib/ImaginaryNumber.cs`
   - `csc -target:library lib/TaskEventArgs.cs`
   - `csc -target:library lib/Task.cs`
   - `csc -target:library -lib:lib/ -reference:TaskEventArgs.dll -reference:Task.dll lib/Tasks.cs`
   - `csc -target:library -reference:TaskEventArgs.dll -reference:Tasks.dll -reference:Task.dll lib/SubTasks.cs`

2. Compile the **main** file with:
   - `csc -lib:lib/ -reference:TaskEventArgs.dll -reference:Task.dll -reference:Tasks.dll -reference:SubTasks.dll Solution.cs`

### Run

`mono Solution.exe`