rem dotnet tool install --global dotnet-ef
rem dotnet ef migrations add InitData -c DataContextMigration -o Migrations/Data
rem dotnet ef database update -c DataContextMigration 
