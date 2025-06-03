# Quiz App API

A RESTful API for managing quiz applications, built with ASP.NET Core.

## Features

- User authentication and authorization
- Quiz session management
- User progress tracking
- RESTful API endpoints

## Prerequisites

- .NET 8.0 SDK or later
- SQL Server (or your preferred database)
- Visual Studio 2022 or Visual Studio Code

## Getting Started

1. Clone the repository:
```bash
git clone [repository-url]
cd QuizAppApi
```

2. Update the database connection string in `appsettings.json`

3. Run database migrations:
```bash
dotnet ef database update
```

4. Run the application:
```bash
dotnet run
```

The API will be available at `https://localhost:5001` or `http://localhost:5000`

## API Endpoints

### Authentication
- POST `/api/auth/register` - Register a new user
- POST `/api/auth/login` - Login user

### Users
- GET `/api/users` - Get all users
- GET `/api/users/{id}` - Get user by ID
- PUT `/api/users/{id}` - Update user
- DELETE `/api/users/{id}` - Delete user

### Quiz Sessions
- GET `/api/quizsessions` - Get all quiz sessions
- POST `/api/quizsessions` - Create new quiz session
- GET `/api/quizsessions/{id}` - Get quiz session by ID

## Project Structure

```
QuizAppApi/
├── Controllers/     # API endpoints
├── Models/         # Data models
├── Services/       # Business logic
├── Data/           # Database context
└── Program.cs      # Application entry point
```

## Contributing

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## License

This project is licensed under the MIT License - see the LICENSE file for details. 
