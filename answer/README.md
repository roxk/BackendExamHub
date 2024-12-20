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

## Comment On The Test

1. Most time spent on reading TSQL doc and syntax, installing SSMS.
 - JSON syntax
 - `output` parameter passing
 - JSON parameter passing in C# via `context.Database.*Sql`
 2. MSSQL image doesn't work on ARM64 (I have a surface pro 11), so I end up using azure edge version.
 3. It took me ~4 hours, mostly on TSQL. If it's PGSQL, I might be able to shorten it to 2 hours. If it's code-first (i.e. no stored procedure), I might be able to finish it in 1 hour. 

 ## Question to Reviewer

 1. Why DB-first instead of code-first? Writing stored proc is painful. It kind of wastes C#'s excellent debugger. Just curious.
