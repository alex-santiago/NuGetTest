# What is Nuget?

According with [nuget.org](http://nuget.org/), NuGet is the package manager for .NET. The NuGet client tools provide the ability to produce and consume packages. Packages means compiled code provided as DLLs files along with other content needed in the projects that consume these packages.

Microsoft summarized the definition as "NuGet package is a single ZIP file with the .nupkg extension that contains compiled code (DLLs), other files related to that code, and a descriptive manifest that includes information like the package's version number".

They can be published either in a private or in a public host.

# NuGet Package Use

The host serves as the point of connection between package creators and package consumers.
Creators build the NuGet packages and publish them to a host.
Consumers then search for useful and compatible packages on accessible hosts, downloading and including those packages in their projects.

Once installed in a project, the packages' APIs are available to the rest of the project code.

**Package Compatibility**

Microsoft recommends developers target .NET Standard, which all .NET and .NET Core projects can consume, to maximize a package's compatibility. It states that this is the most efficient means for both creators and consumers, as a single package (usually containing a single assembly) works for all consuming projects. For more details in targeting compatibility click [here](https://docs.microsoft.com/en-us/nuget/what-is-nuget#package-targeting-compatibility).

# How to Create and Publish a Package

**Prerequisites**

1. .NET Core SDK installed
2. An account on [nuget.org](http://nuget.org/)
3. Class library project

## 1. Add package metadata to the Class library project file

Open the class library project. Edit the `[.csproj]` file and add the following minimal properties inside the exiting `<PropertyGroup>` tag, changing the values as appropriate:

```xml
<PackageId>AppLogger</PackageId>
<Version>1.0.0</Version>
<Authors>your_name</Authors>
<Company>your_company</Company>
```
[Here](https://docs.microsoft.com/en-us/dotnet/core/tools/csproj#nuget-metadata-properties) you can find a list of NugGet metadata properties you can add to your project file.

**IMPORTANT!
The PackageId must be unique across nuget.org or whatever host you're using for publishing the package.**

## 2. Run the pack command to build a NuGet package

From the .NET CLI run the dotnet pack command, which also builds the project automatically to create a NuGet package `[.nupkg]`.

```bash
dotnet pack
```

## 3. Publish the package to nuget.org

First before publishing you need to acquire an API key from nuget.org. To acquire the key follow these steps:

1. Sign into your nuget.org account
2. On the upper right, select your username then select API Keys
3. Select Create, provide a name for your key, select Select Scopes > Push. Under API Key, enter * for Glob pattern, then select Create.
4. After the key is created, select Copy to retrieve the access key. You will need it in the CLI to publish the package.
5. **Important:** Save your key in a secure location because you cannot copy the key again later on. If you return to the API key page, you need to regenerate the key to copy it. You can also remove the API key if you no longer want to push packages via the CLI.

Publish the package:

1. Change to the folder containing the .nupkg file.
2. Run the following command, specifying your package name and replacing the key value with your API key:

```Bash
dotnet nuget push CalcBasic.1.0.0.nupkg -k oy2b6iiedxwprasylsiq2k5awfmhd2sulnmz663zuxy7o4 -s https://api.nuget.org/v3/index.json
```
You should see the results of the publishing process:

```Bash
info : Pushing CalcBasic.1.0.0.nupkg to 'https://www.nuget.org/api/v2/package'...
info :   PUT https://www.nuget.org/api/v2/package/
info :   Created https://www.nuget.org/api/v2/package/ 2090ms
info : Your package was pushed.
```
After publishing the package should appear listed in the Manage Package session. Before the package is actually published it must go under validation. The package validation and indexing may take up to an hour to complete. When finished just add the package to any project like any other you use. From the .NET CLI:

```
dotnet add package CalcBasic --version 1.0.0
```


# References

- [nuget.org](http://nuget.org/) Date Accessed: 2018-06-01
- [NuGet Documentation](https://docs.microsoft.com/en-us/nuget/) Date Accessed: 2018-06-01

