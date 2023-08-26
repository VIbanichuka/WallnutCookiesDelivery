## An E-Shop application with ASP.NET Core (Ongoing project)

This WalnutCookiesDelivery application features:
-[**WallnutCookiesDelivery.Web**](src/WallnutCookiesDelivery.Web/) - An ASP.NET Core Web Application

## Architecture
- Clean Onion architecture

This application is separated into 4 layers of architecture:
- The Domain layer [**WallnutCookiesDelivery.Core**](src/WallnutCookiesDelivery.Core/)
- The Application layer [**WallnutCookiesDelivery.Application**](src/WallnutCookiesDelivery.Application/)
- The Infrastructure layer [**WallnutCookiesDelivery.DataAccess**](src/WallnutCookiesDelivery.DataAccess/)
- The Presentation layer[**WallnutCookiesDelivery.Web**](src/WallnutCookiesDelivery.Web/)

For information about [Clean Onion architecture](https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures)

## Design Pattern
- Repository Pattern
- Dependency Injection Design Pattern
- The MVC (Model-View-Controller) architectural Design Pattern

For information about [MVC pattern](https://learn.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-7.0) and [DI pattern](https://dotnettutorials.net/lesson/dependency-injection-design-pattern-csharp/)

This application showcases:
- ASP.NET Core MVC 
- EntityFramework Core
- Microsoft SQL Server
- [AutoMapper](https://docs.automapper.org/en/latest/Getting-started.html) for mapping one object to another.
- LINQ
- ASP.NET Core Identities for authorisation and authentication

## Prerequisites

### .NET
1. [Install .NET 6](https://dotnet.microsoft.com/en-us/download)

### Database
1. Install the **dotnet-ef** tool
2. Install the Microsoft SQL Server Management Studio

### Running this application using Visual Studio Code

- **Visual Studio Code** - Open the [WallnutCookiesDelivery.Web](src/WallnutCookiesDelivery.Web/) terminal windows and then run the command:

    ```
    dotnet watch run 
    ```
This would launch the Homepage of the application. Navigate the application - **Home** - **Order Online** - **Menu** - **Privacy** - **Products** - **Register** - **Login**

<img width="960" alt="Screenshot 2023-08-26 000400" src="https://github.com/VIbanichuka/WallnutCookiesDelivery/assets/94909597/7728cfa9-fcd6-46d9-a6d7-11f3003ce6e4">

This is the menu page: Add your favourite cookies to the cart or customize your cookies:

<img width="960" alt="Screenshot 2023-08-26 002128" src="https://github.com/VIbanichuka/WallnutCookiesDelivery/assets/94909597/d720bb0b-1026-40c8-8f9f-484e64ebf570">

The product page can only be accessed by the admin. This is page where the admin manages the products displayed on the application:

<img width="960" alt="Screenshot 2023-08-26 002935" src="https://github.com/VIbanichuka/WallnutCookiesDelivery/assets/94909597/70fe05a0-6c22-40d3-ba03-28c6bc24f949">