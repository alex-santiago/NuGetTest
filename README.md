# NuGet Project
This project was created to illustrate the creation and publishing of a NuGet Package. It has two .NET projects:

* CalcBasic - a .NET class library created to illustrate the use of Nuget Packages. It implements the four basic math operations on integers
* CalcTest - a .NET console application that consumes the CalcBasic Package after it has been published on the nuget.org website
* CalcVSTSTest - the same project as CalcTest, but referencing a package feed in VSTS

Documentation:

1. [Basic NuGet publishing to a NuGet.org repository](basic-nuget.md)
2. [Private host a NuGet package](host-nuget.md) 
