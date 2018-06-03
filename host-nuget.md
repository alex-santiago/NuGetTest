# How to host your own NuGet Packages

There are mainly three different ways you can host your nuget packages privately:

* Local feed: Packages are placed on a network file share, ideally using nuget init and nuget add to create a hierarchical folder structure (NuGet 3.3+)
* NuGet.Server: Packages are made available through a local HTTP server
* NuGet Gallery: Packages are hosted on an Internet server using the [NuGet Gallery Project](https://github.com/NuGet/NuGetGallery#build-and-run-the-gallery-in-arbitrary-number-easy-steps)

Microsoft points to other several products that support remote private feeds. For details, see the [complete document]
(https://docs.microsoft.com/en-us/nuget/hosting-packages/overview).

I tried the NuGet Gallery and the VSTS Package Management.

## 1. Nuget Gallery

The use of Nuget Gallery is pretty straightforward.

1. Clone the git repo
2. Build the application
3. Publish the website on the web server

The complete documentation can be found in the [NuGet Gallery](https://github.com/NuGet/NuGetGallery#nuget-gallery--where-packages-are-found) GitHub repository.

This solution is good because it gives a lot more flexibility when it comes to managing your packages. But I concluded that it takes more time to setup, and at the end, you have an entirely new server or website added for you to manage. That is why I decided to go for the Microsoft VSTS solution instead.

## 2. Microsoft Visual Studio Team Services Package Management

**Prerequisites:**

1. **Package Management Extension:** To create the feed for the packages, you need to add the Package Management Extension from the [Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=ms.feed) and associate it to the user or group that has permission in the project.

2. **Create a package feed:**

A feed is a container for packages. You consume and publish packages through a particular feed. Information on how to [Create a feed](https://docs.microsoft.com/en-ca/vsts/package/feeds/create-feed).

### Steps to publish a package:

1. Navigate to your feed
2. Select the option Connect to feed
3. Download the Nuget + VSTS Credential Provider and unpack the files
4. Open a command prompt in the folder where the NuGet and the Credential Provider were unpacked
5. Copy and execute in the prompt the command to add the NuGet source for the package
```Bash
nuget.exe sources Add -Name "CalcBasic" -Source "https://alexandressilva.pkgs.visualstudio.com/_packaging/CalcBasic/nuget/v3/index.json"
```
6. Copy and execute in the prompt the command to push the package to the feed
```Bash
nuget.exe push -Source "CalcBasic" -ApiKey VSTS my_package.nupkg
```
**Don't forget to replace `my_package.nupkg` with the path and name of your nuget package**

## Consume NuGet packages from a feed in Visual Studio

1. Navigate to your feed
2. Connect to the feed
3. Copy the NuGet package source URL
4. Inside Visual Studio, add the URL to the Package Sources in the NuGet Package Manager
5. In the Solution Explorer, right-click in your project and select Manage NuGet Packages
6. In the right corner, choose your source from the Package Source combo box then search for the package you want to use
7. Select the package, click Install and you are good to go

# References

- [Hosting your own NuGet feeds](https://docs.microsoft.com/en-us/nuget/hosting-packages/overview) Date Accessed: 2018-06-01
- [NuGet Gallery](https://github.com/NuGet/NuGetGallery#nuget-gallery--where-packages-are-found) Date Accessed: 2018-06-01
- [nuget.org](http://nuget.org/) Date Accessed: 2018-06-01
- [NuGet Documentation](https://docs.microsoft.com/en-us/nuget/) Date Accessed: 2018-06-01
- [Publish a NuGet package from the command line](https://www.visualstudio.com/docs/package/nuget/publish) Date Accessed: 2018-06-02
- [Consume NuGet packages in Visual Studio](https://docs.microsoft.com/en-ca/vsts/package/nuget/consume)

