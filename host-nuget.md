---
title: "Host Nuget"
date: 2018-06-01T16:51:19-07:00
tags: [integration, .NET, NuGet]
draft: true
---

# How to host your own NuGet Packages

There are mainly three different ways you can host your nuget packages privately:

* Local feed: Packages are placed on a network file share, ideally using nuget init and nuget add to create a hierarchical folder structure (NuGet 3.3+)
* NuGet.Server: Packages are made available through a local HTTP server
* NuGet Gallery: Packages are hosted on an Internet server using the [NuGet Gallery Project](https://github.com/NuGet/NuGetGallery#build-and-run-the-gallery-in-arbitrary-number-easy-steps)

Microsoft points to other several products that support remote private feeds. For details, see the [complete document]
(https://docs.microsoft.com/en-us/nuget/hosting-packages/overview).

I tried the NuGet Gallery and the VSTS Package Management.

## 1. Nuget Gallery

The use of Nuget Gallery is pretty straight forward.

1. Clone the git repo
2. Build the application
3. Publish the website in the web server

The complete documentation can be found in the [NuGet Gallery](https://github.com/NuGet/NuGetGallery#nuget-gallery--where-packages-are-found) GitHub repository.

This solution is good because it gives a lot more flexibility when it comes to managing your packages. But I reach the conclusion that it takes more time to setup and at the end you have an entire new server or website added for you to manage and worry about. That is why I decided to go for the Microsoft VSTS solution instead.

## 2. Microsoft Visual Studio Team Services Package Management

**Prerequisites:**

1. **Package Management Extension:** To create the feed for the packages, you need to add the Package Management Extension from the [Visual Studio Marketplace](https://marketplace.visualstudio.com/items?itemName=ms.feed) and associate it to the user or group that has permission in the project.

2. **Create a package feed:**

A feed is a container for packages. You consume and publish packages through a particular feed. Information on how to [Create a feed](https://docs.microsoft.com/en-ca/vsts/package/feeds/create-feed).

### Steps to publish a package:

1. Navigate to your feed
2. Select connect to feed
3.

# References

- [Hosting your own NuGet feeds](https://docs.microsoft.com/en-us/nuget/hosting-packages/overview) Date Accessed: 2018-06-01
- [NuGet Gallery](https://github.com/NuGet/NuGetGallery#nuget-gallery--where-packages-are-found) Date Accessed: 2018-06-01
- [nuget.org](http://nuget.org/) Date Accessed: 2018-06-01
- [NuGet Documentation](https://docs.microsoft.com/en-us/nuget/) Date Accessed: 2018-06-01
- [Publish a NuGet package from the command line](https://www.visualstudio.com/docs/package/nuget/publish) Date Accessed: 2018-06-02

