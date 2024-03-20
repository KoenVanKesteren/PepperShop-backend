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

### restore packages

```sh
	dotnet restore
```

### setup database
update 'appsettings.json' with your connection


```sh
Add-Migration <name of migration>
```

```sh
Update-Database
```