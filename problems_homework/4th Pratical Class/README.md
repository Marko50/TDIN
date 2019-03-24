# Instructions

Open the `NetBeans` project on the folder `PrimeNumberWebApplication` and run ir using `GlassFish` server.

## With Makefile

`cd Client`
`make`

## Without Makefile

Description of the commands listed in the c# Makefile and how to compile this solution without the makefile.

### Compile

1. Compile the target **library** for the main project with:
   - `csc -target:library PrimeNumberWebService.cs`
2. Compile the **main** file with:
   - `csc -reference:PrimeNumberWebService.dll Client.cs`

### Run

`mono Client.exe`