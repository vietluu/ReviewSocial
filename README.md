# ReviewSocial

This is the README documentation for the Reviewsocial project running on the ASP.NET Core MVC platform.

## Requirements
To run the Reviewsocial project, you will need:

- Visual Studio or Visual Studio Code.
- .NET Core SDK 7.0 or later.
- SQL Server.
- Installation
### To install the Reviewsocial project, follow these steps:

### Clone this repo.
* Run the dotnet restore command in the terminal or command prompt to install the necessary NuGet packages.
Adjust the database connection string in the appsettings.json file to meet your requirements.
Run the dotnet ef database update command to update the database.
Run the dotnet run command to start the Reviewsocial project.
Usage
To use the Reviewsocial project, access the URL http://localhost:5000 on your web browser.

## Directory Structure
The Reviewsocial project has the following directory structure:

  Reviewsocial/ </br>
├── Controllers/ </br>
├── Data/ </br>
│   ├── Migrations/ </br>
│   └── ApplicationDbContext.cs </br>
├── Models/ </br>
├── Views/ </br>
├── appsettings.json </br>
├── Program.cs </br>
├── Startup.cs </br>
└── README.md </br>

## Technologies Used
* The Reviewsocial project is built on the ASP.NET Core MVC platform, using Entity Framework Core to manage the database, Razor to create Views, and Bootstrap to design the user interface.


