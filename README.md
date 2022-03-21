# signoz-playground

## Prerequisites

- [Docker](https://www.docker.com/products/docker-desktop)
- [.NET 5](https://dotnet.microsoft.com/en-us/download/dotnet/5.0)
- [Dotnet EF](https://docs.microsoft.com/pt-br/ef/core/cli/dotnet)

## Running Commands

To run all the `SigNoz` dependencies, type the following inside [infra directory](./infra):

```bash
docker-compose up
```

Add and apply migrations:

```bash
dotnet ef migrations add InitialCreate --project ./src/Order.Api/Order.Api.csproj --startup-project ./src/Order.Api/Order.Api.csproj --context OrderContext --verbose

dotnet ef database update --project ./src/Order.Api/Order.Api.csproj --startup-project ./src/Order.Api/Order.Api.csproj --context OrderContext --verbose
```

To open the `SigNoz` frontend, paste the following `url` in your browser:

```bash
http://localhost:3301
```

> **NOTE**: they're gonna ask your e-mail, first name and organization name, you can type anything to signup

To open the swagger specification, paste the following `url` in your browser:

```bash
http://localhost/swagger/index.html
```
