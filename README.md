
# Personnel Registration System

This project is a **Personnel Registration System**, designed for managing and maintaining records of employees or personnel. The system allows for CRUD (Create, Read, Update, Delete) operations on personnel data and includes various components to support user interface, data storage, and business logic.

## Table of Contents

- [Features](#features)
- [Installation](#installation)
- [Configuration](#configuration)
- [Database](#database)
- [Folder Structure](#folder-structure)
- [Contributing](#contributing)
- [License](#license)

## Features

- **Personnel Registration**: Add, edit, delete, and view personnel information.
- **Database Integration**: Uses an SQLite database to store personnel data.
- **MVC Architecture**: Built using the ASP.NET Core MVC framework.
- **User Interface**: A web-based interface for managing personnel information.
- **Responsive Design**: Works on both desktop and mobile devices.

## Installation

1. **Clone the repository**:
   ```bash
   git clone <repository-url>
   ```
   
2. **Navigate to the project directory**:
   ```bash
   cd Personnel
   ```

3. **Restore NuGet packages**:
   ```bash
   dotnet restore
   ```

4. **Build the project**:
   ```bash
   dotnet build
   ```

5. **Run the project**:
   ```bash
   dotnet run
   ```

   The application should now be running at `http://localhost:5000` by default.

## Configuration

Configuration settings for the project can be found in the `appsettings.json` and `appsettings.Development.json` files. These files include settings for the database connection and other application-specific configurations.

### Example Configuration (`appsettings.json`):
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=Personel.db"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*"
}
```

## Database

This project uses an SQLite database (`Personel.db`). If you want to reset or update the database, follow these steps:

1. **Apply Migrations**:
   ```bash
   dotnet ef database update
   ```

2. **Seed Initial Data** (if applicable):
   You can add seed data through the `Data` folder or configure it through migrations.

## Folder Structure

Here’s an overview of the main folders in the project:

- **Controllers**: Contains the MVC controllers that handle HTTP requests and return responses.
- **Models**: Includes the data models for personnel records.
- **Views**: Contains the Razor views (HTML templates) used for rendering the user interface.
- **Data**: Includes the database context and migration files.
- **wwwroot**: Static files such as CSS, JavaScript, and images.
- **Migrations**: Entity Framework migrations to manage the database schema.
- **Properties**: Project properties such as launch settings.

## Contributing

Feel free to contribute to this project by submitting pull requests, reporting issues, or suggesting new features. Before contributing, please ensure that your code follows the coding standards and conventions used in this project.

## License

This project is licensed under the MIT License. See the `LICENSE` file for more details.
