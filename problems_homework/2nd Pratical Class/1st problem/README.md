# Instructions

## With Makefile

`make`

## Without Makefile

Description of the commands listed in the c# Makefile and how to compile this solution without the makefile.

### Compile

1. Compile the target **libraries** for the main project with:
   - `csc -target:library lib/module_a/A.cs`
   - `csc -target:library lib/module_b/B.cs`
2. Compile the **main** file with:
   - `csc -lib:lib/ -reference:A.dll -reference:B.dll Solution.cs`

### Run

`mono Solution.exe`