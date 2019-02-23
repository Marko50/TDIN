all: run

Solution.exe: Solution.cs
	@csc -target:library lib/TaskEventArgs.cs
	@csc -target:library lib/Task.cs
	@csc -target:library -lib:lib/ -reference:TaskEventArgs.dll -reference:Task.dll lib/Tasks.cs
	@csc -target:library -reference:TaskEventArgs.dll -reference:Tasks.dll -reference:Task.dll lib/SubTasks.cs
	@csc -lib:lib/ -reference:TaskEventArgs.dll -reference:Task.dll -reference:Tasks.dll -reference:SubTasks.dll Solution.cs 

clean:
	@rm -f Solution.exe
	@rm -f *.dll

run: Solution.exe
	@mono Solution.exe