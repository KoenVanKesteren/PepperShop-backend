# peppershop-backend

## build with
.NET8
ASP.NET Core WebAPI
Entity Framework Core
MySql database 

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