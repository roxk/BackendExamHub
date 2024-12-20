## Pre-requisite

- Docker - https://www.docker.com/get-started/
    - Make sure your version has `compose`, i.e. `docker compose` works (instead of `docker-compose`)
- SSMS - https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16
    - Or `sqlcmd`/equivalent - https://learn.microsoft.com/en-us/sql/relational-databases/lesson-1-connecting-to-the-database-engine?view=sql-server-ver16#common-tools
- .NET 8 - https://dotnet.microsoft.com/en-us/download/dotnet/8.0

## Getting Started

1. Copy `.env.template` to `.env`.
2. Fill in `.env`.
3. Copy `app/appsettings.Development.json.template` to `app/appsettings.Development.json`.
4. In `app/settings.Development.json` replace `<replace-me>` with SA password.
5. Run the following
```
cd answer
docker compose up -d
```
6. Restore DB from `mercury_fire_test.bak` via SSMS or `sqlcmd`.
    - DB can be reached via `localhost:1443`. See `app/appsettings.Development.json` for more details. You might need to click "trust certificate"
    - The backup file is mounted at `/app/mercury_fire_test.bak` inside the container
7. Run `http://localhost:5000/swagger` to start.
