# Our_Exam_2425

**Our_Exam_2425** is a simple Numbers Game web application built with ASP.NET Core 8.0 using Razor Pages and Minimal API. Players select two numbers to compete against a bot's randomly generated numbers, with all game results stored and displayed through a clean, responsive interface.

## 🎮 Game Rules

- **Player Input**: Choose two numbers A and B where:
  - Both numbers are between 1-10
  - A must be less than B
  - B must be even
- **Bot Competition**: Bot generates two random numbers X and Y
- **Scoring**: Higher sum wins the round
- **History**: All games are saved and can be reviewed

## 🚀 Features

- **Interactive Game Interface**: Clean Razor Pages UI for gameplay
- **RESTful API**: Minimal API endpoint for programmatic access
- **Game History**: View all previous games with results
- **Input Validation**: Client-side and server-side validation
- **Real-time Results**: Immediate game outcome display
- **Swagger Documentation**: API documentation in development mode

## 🛠️ Tech Stack

- **Backend**: ASP.NET Core 8.0 (Razor Pages + Minimal API)
- **Database**: Entity Framework Core 8 with SQL Server
- **Frontend**: Razor Pages with Bootstrap styling
- **API**: RESTful endpoints with Swagger documentation

## 📁 Project Structure

```
Our_Exam_2425/
├── Program.cs                    # App startup and API routes
├── Pages/                        # Razor Pages UI
│   ├── Index.cshtml             # Game interface
│   ├── GameResult.cshtml        # Result display
│   └── GameHistory.cshtml       # Game history
├── Model/                        # Domain models
│   ├── Game.cs
│   ├── GameBinding.cs
│   └── GameView.cs
├── Data/
│   └── AppDbContext.cs          # EF Core context
├── Service/                      # Business logic
│   ├── IServices.cs
│   └── Services.cs
├── Filters/
│   └── GameValidationFilter.cs  # API validation
└── Migrations/                   # Database migrations
```

## ⚡ Quick Start

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- SQL Server (LocalDB for Windows, Docker for cross-platform)

### Database Setup

#### Option 1: SQL Server with Docker (Cross-platform)
```bash
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=YourStrong!Passw0rd" \
  -p 1433:1433 --name sqlserver \
  -d mcr.microsoft.com/mssql/server:2022-latest
```

Update connection string in `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "SqlServer": "Server=localhost,1433;Database=OurExam;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;"
  }
}
```

#### Option 2: Windows LocalDB (Default)
No additional setup required - uses the default LocalDB configuration.

### Installation and Run
```bash
# Clone and navigate to project
cd Our_Exam_2425

# Restore dependencies
dotnet restore

# Apply database migrations
dotnet ef database update

# Run the application
dotnet run
```

### Access the Application
- **Web UI**: `http://localhost:5036` or `https://localhost:7055`
- **Swagger API**: `http://localhost:5036/swagger` (Development mode only)

## 🎯 Usage

### Web Interface
1. Navigate to the homepage
2. Enter your numbers A and B (following game rules)
3. Click "Play Game" to compete against the bot
4. View your result and game history
5. Access previous games through "View Game History"

### API Endpoint
```bash
# Play game via API
curl "http://localhost:5036/play/2/4"

# Example response (plain text)
"Player: 2 + 4 = 6, Bot: 3 + 7 = 10. Bot wins!"
```

**API Route**: `GET /play/{a}/{b}`
- **Constraints**: Numbers 1-10, a < b, b must be even
- **Response**: 200 OK (game result) or 400 Bad Request (validation error)

## 📊 Game Data

### Game Model
| Field | Type | Description |
|-------|------|-------------|
| `Id` | int | Unique game identifier |
| `A`, `B` | int | Player's chosen numbers |
| `X`, `Y` | int | Bot's random numbers |
| `PlayerScore` | int | Player's sum (A + B) |
| `BotScore` | int | Bot's sum (X + Y) |
| `Winner` | string | "Player", "Bot", or "Tie" |
| `CreatedAt` | DateTime | Game timestamp |

## 🔧 Configuration

### Environment Setup
```bash
# Enable development features (Swagger, detailed errors)
export ASPNETCORE_ENVIRONMENT=Development
```

### Database Configuration
Update `appsettings.json` for your database setup:
```json
{
  "ConnectionStrings": {
    "SqlServer": "your-connection-string-here"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information"
    }
  }
}
```

## 🧪 Testing

### Manual Testing
- Test various number combinations within valid ranges
- Try invalid inputs to verify validation
- Check game history persistence
- Test API endpoints with curl or Swagger UI

### Validation Testing
```bash
# Valid request
curl "http://localhost:5036/play/1/2"

# Invalid requests (should return 400)
curl "http://localhost:5036/play/5/3"  # a > b
curl "http://localhost:5036/play/2/3"  # b is odd
curl "http://localhost:5036/play/0/2"  # a out of range
```

## 🚨 Troubleshooting

### Common Issues

**HTTPS Certificate Issues**
```bash
dotnet dev-certs https --trust
```

**EF Core CLI Missing**
```bash
dotnet tool install -g dotnet-ef
```

**Database Connection Errors**
- Verify SQL Server is running
- Check connection string format
- Ensure database exists (run migrations)

**Cross-platform Database Issues**
- LocalDB only works on Windows
- Use Docker SQL Server on Linux/macOS
- Update connection string accordingly

## 🎯 Learning Outcomes

This project demonstrates:
- **Full-stack Development**: Razor Pages with API integration
- **Data Persistence**: Entity Framework Core with SQL Server
- **Input Validation**: Multiple validation layers
- **RESTful API Design**: Clean endpoint architecture
- **Modern Web Development**: ASP.NET Core 8 best practices

---

A practical example of ASP.NET Core development combining traditional web pages with modern API design patterns.
