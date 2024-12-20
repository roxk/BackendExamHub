## Pre-requisite

- Docker - https://www.docker.com/get-started/
    - Make sure your version has `compose`, i.e. `docker compose` works (instead of `docker-compose`)
- SSMS - https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16
    - Or sqlcmd or equivalent - https://learn.microsoft.com/en-us/sql/relational-databases/lesson-1-connecting-to-the-database-engine?view=sql-server-ver16#common-tools
- .NET 8 - https://dotnet.microsoft.com/en-us/download/dotnet/8.0

## Getting Started

1. Copy `.env.template` to `.env`.
2. Fill in `.env`.
3. Copy `app/appsettings.Development.json.template` to `app/appsettings.Development.json`.
4. In `app/settings.Development.json` replace `<replace-me>` with SA password.
3. Run the following
```
cd answer
docker compose up -d
```
