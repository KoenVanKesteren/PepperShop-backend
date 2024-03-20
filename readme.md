# peppershop-backend

## gebouwd met: 
.NET8
ASP.NET Core WebAPI
Entity Framework Core

de backend werkt met een MySql database maar voel je vrij om deze aan te passen

## packages
Pomelo.EntityFrameworkCore.MySql
microsoft.entityframeworkcore.design
Microsoft.EntityFrameworkCore.Tools

## deployment
restore packages:
	dotnet restore

setup database:
	- update 'appsettings.json' with your connection
	- in package manager console: 
		Add-Migration <name of migration>
		Update-Database