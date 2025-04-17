# BankingApp

A modern, secure banking application built with ASP.NET Core MVC, featuring a clean and professional user interface.

![BankingApp Screenshot](screenshots/banking-app.png)

## Features

- **User Authentication**
  - Secure login system
  - Session management
  - Profile management

- **Account Management**
  - View account balances
  - Multiple account types (Savings, Current)
  - Account statements
  - Transaction history

- **Money Transfer**
  - Internal transfers between accounts
  - External transfers to beneficiaries
  - Transaction tracking
  - Transfer history

- **Beneficiary Management**
  - Add/remove beneficiaries
  - Quick transfer to saved beneficiaries
  - Beneficiary details management

- **Modern UI/UX**
  - Responsive design
  - Clean and professional interface
  - Interactive elements
  - Real-time updates

## Technology Stack

- **Backend**
  - ASP.NET Core MVC
  - C#
  - Entity Framework Core
  - SQL Server

- **Frontend**
  - Bootstrap 5
  - Custom CSS
  - Font Awesome icons
  - jQuery

- **Security**
  - Session-based authentication
  - Input validation
  - Secure data handling

## Getting Started

### Prerequisites

- .NET 6.0 SDK or later
- Visual Studio 2022 or Visual Studio Code
- SQL Server (LocalDB or Express)

### Installation

1. Clone the repository
```bash
git clone https://github.com/yourusername/BankingApp.git
```

2. Navigate to the project directory
```bash
cd BankingApp
```

3. Restore dependencies
```bash
dotnet restore
```

4. Update the connection string in `appsettings.json`
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=BankingApp;Trusted_Connection=True;"
  }
}
```

5. Run the application
```bash
dotnet run
```

6. Open your browser and navigate to `https://localhost:5001`

## Project Structure

```
BankingApp/
├── Controllers/         # MVC Controllers
├── Models/             # Data Models
├── Services/           # Business Logic
├── Views/              # Razor Views
├── wwwroot/            # Static Files
│   ├── css/           # Stylesheets
│   ├── js/            # JavaScript
│   └── lib/           # Third-party libraries
└── Program.cs          # Application Entry Point
```

## Features in Detail

### Account Management
- View account balances and details
- Access transaction history
- Download account statements
- Manage multiple accounts

### Money Transfer
- Quick transfer between accounts
- Scheduled transfers
- Transfer to external accounts
- Transaction tracking

### Security Features
- Secure authentication
- Session management
- Input validation
- Error handling

### User Experience
- Responsive design
- Intuitive navigation
- Real-time updates
- Clean interface

## Contributing

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## Acknowledgments

- Bootstrap for the responsive framework
- Font Awesome for the icons
- ASP.NET Core team for the amazing framework

## Contact

Your Name - [@yourtwitter](https://twitter.com/yourtwitter)

Project Link: [https://github.com/yourusername/BankingApp](https://github.com/yourusername/BankingApp) 
