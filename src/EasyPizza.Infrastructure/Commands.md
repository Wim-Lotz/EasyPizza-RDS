# Useful Commands

## Create Postgres Docker Image

docker run -d --name postgres -p 5432:5432 -e POSTGRES_PASSWORD=pizza postgres

## Migration Commands

* dotnet ef migrations add <name> --project EasyPizza.Infrastructure --startup-project EasyPizza.API
* dotnet ef database update --project EasyPizza.Infrastructure --startup-project EasyPizza.API
* dotnet ef migrations remove --project EasyPizza.Infrastructure --startup-project EasyPizza.API

### Rollback
dotnet ef database update <name> --project EasyPizza.Infrastructure --startup-project EasyPizza.API
