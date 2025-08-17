## Our_Exam_2425

An ASP.NET Core 8.0 Razor Pages application with a minimal API endpoint and Entity Framework Core (SQL Server) for persistence. It implements a simple “Numbers Game” where a player picks two numbers, competes against a bot’s two random numbers, and the result is stored for history.

### Tech stack
- **Framework**: ASP.NET Core 8.0 (Razor Pages + Minimal API)
- **Data access**: Entity Framework Core 8 (SQL Server)
- **UI**: Razor Pages in `Our_Exam_2425/Pages`
- **API docs**: Swagger (available in Development environment)

### Project structure
- `Our_Exam_2425/Program.cs`: App startup, service registration, middleware, minimal API route `/play/{a}/{b}`
- `Our_Exam_2425/Pages`: Razor Pages
  - `Index`: Play the game
  - `GameResult`: Show the result and recent games
  - `GameHistory`: List all games
- `Our_Exam_2425/Model`: Domain models (`Game`, `GameBinding`, `GameView`)
- `Our_Exam_2425/Data/AppDbContext.cs`: EF Core DbContext
- `Our_Exam_2425/Service`: `IServices` and `Services` for data operations
- `Our_Exam_2425/Filters/GameValidationFilter.cs`: Endpoint filter for input validation
- `Our_Exam_2425/Migrations`: EF Core migrations for `Games` table

### Prerequisites
- .NET SDK 8.0+
- SQL Server instance (local or remote)
  - On Windows, LocalDB is referenced by default in `appsettings.json`
  - On Linux/macOS, use a running SQL Server (e.g., Docker) and update the connection string

To start a local SQL Server in Docker:
```bash
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Your_password123" \
  -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server:2022-latest
```

Example connection string for Docker SQL Server (Linux/macOS):
```text
Server=localhost,1433;Database=OurExam;User Id=sa;Password=Your_password123;TrustServerCertificate=True;
```

### Configuration
Edit `Our_Exam_2425/appsettings.json`:
- `ConnectionStrings:SqlServer` — set to your SQL Server connection string
- `Logging` — optional logging levels

For local development features (Swagger, developer exception page), ensure:
```bash
export ASPNETCORE_ENVIRONMENT=Development
```

### Database setup
From the repository root, run EF migrations (ensure the connection string is valid first):
```bash
cd Our_Exam_2425
# Install EF CLI if needed:
# dotnet tool install -g dotnet-ef
# or ensure it's available: dotnet ef --version

dotnet ef database update
```
This creates the `Games` table with columns: `Id`, `A`, `B`, `X`, `Y`, `PlayerScore`, `BotScore`, `Winner`, `CreatedAt`.

### Build and run
From the repository root:
```bash
cd Our_Exam_2425
 dotnet restore
 dotnet build
 dotnet run
```
By default (see `launchSettings.json`), the app listens on:
- HTTP: `http://localhost:5036`
- HTTPS: `https://localhost:7055`

### How to play (UI)
1. Navigate to `http://localhost:5036` (or the port shown in the console)
2. Enter:
   - `A`: integer in [1..10]
   - `B`: integer in [1..10], must be even, and `A < B`
3. Submit to play. The bot’s numbers `X` and `Y` are generated automatically. You’ll be redirected to the result page.
4. View history via the "View Game History" link.

### Minimal API endpoint
- **Route**: `GET /play/{a}/{b}`
- **Constraints**:
  - `a` and `b` are integers in [1..10] (route constraints)
  - Filter validates: `a < b` and `b` is even
- **Response**:
  - `200 OK`: plain text summary of the result (also persists to DB)
  - `400 Bad Request`: validation problem (JSON) when constraints fail

Example (assuming HTTP):
```bash
curl "http://localhost:5036/play/2/4"
```

Swagger UI (Development only):
```text
http://localhost:5036/swagger
```

### Notes and known issues
- The Razor Pages flow computes the winner correctly.
- In the minimal API example in `Program.cs`, the `Winner` assignment has a missing `else` and will overwrite to "Bot". If you rely on the minimal API result, consider fixing it to use an `else` before deployment.
- Default `appsettings.json` uses Windows LocalDB: `Data Source=(localdb)\\ProjectModels; ...`. On Linux/macOS, replace with a standard SQL Server connection string (see example above).

### Troubleshooting
- If HTTPS fails locally, trust dev certificates:
```bash
dotnet dev-certs https --trust
```
- If `dotnet ef` is not found, install the EF CLI:
```bash
dotnet tool install -g dotnet-ef
```
- Ensure the database is reachable and credentials are correct.

### License
No license specified.