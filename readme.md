# Library App

## Description

Library App is a console-based library management system built with .NET 8 that demonstrates clean architecture principles and modern software development practices. This application allows librarians to manage patrons, book loans, and membership renewals through an intuitive command-line interface.

The project serves as a sample application for learning GitHub Copilot integration and showcases:
- Clean Architecture with separated layers
- Repository and Service patterns
- Dependency injection
- JSON-based data persistence
- Comprehensive unit testing
- State machine pattern for UI navigation

## Project Structure

```
GuidedProjectApp/
├── GuidedProjectApp.sln
├── readme.md
└── AccelerateDevGitHubCopilot/
    ├── src/
    │   ├── Library.ApplicationCore/
    │   │   ├── Library.ApplicationCore.csproj
    │   │   ├── Entities/
    │   │   │   ├── Author.cs
    │   │   │   ├── Book.cs
    │   │   │   ├── BookItem.cs
    │   │   │   ├── Loan.cs
    │   │   │   └── Patron.cs
    │   │   ├── Enums/
    │   │   │   ├── EnumHelper.cs
    │   │   │   ├── LoanExtensionStatus.cs
    │   │   │   ├── LoanReturnStatus.cs
    │   │   │   └── MembershipRenewalStatus.cs
    │   │   ├── Interfaces/
    │   │   │   ├── ILoanRepository.cs
    │   │   │   ├── ILoanService.cs
    │   │   │   ├── IPatronRepository.cs
    │   │   │   └── IPatronService.cs
    │   │   └── Services/
    │   │       ├── LoanService.cs
    │   │       └── PatronService.cs
    │   ├── Library.Console/
    │   │   ├── Library.Console.csproj
    │   │   ├── Program.cs
    │   │   ├── ConsoleApp.cs
    │   │   ├── ConsoleState.cs
    │   │   ├── CommonActions.cs
    │   │   ├── appSettings.json
    │   │   └── Json/
    │   │       ├── Authors.json
    │   │       ├── Books.json
    │   │       ├── BookItems.json
    │   │       ├── Loans.json
    │   │       └── Patrons.json
    │   └── Library.Infrastructure/
    │       ├── Library.Infrastructure.csproj
    │       └── Data/
    │           ├── JsonData.cs
    │           ├── JsonLoanRepository.cs
    │           └── JsonPatronRepository.cs
    └── tests/
        └── UnitTests/
            ├── UnitTests.csproj
            ├── LoanFactory.cs
            ├── PatronFactory.cs
            └── ApplicationCore/
                ├── LoanService/
                │   ├── ExtendLoan.cs
                │   └── ReturnLoan.cs
                └── PatronService/
```

## Key Classes and Interfaces

### Domain Entities
- **Patron**: Represents library members with membership details and loan history
- **Book**: Contains book information including title, author, genre, and ISBN
- **BookItem**: Represents physical copies of books with acquisition date and condition
- **Loan**: Tracks book loans with due dates, return dates, and associated patron/book
- **Author**: Stores author information

### Core Interfaces
- **IPatronRepository**: Defines patron data access operations (search, get, update)
- **ILoanRepository**: Defines loan data access operations (get, update)
- **IPatronService**: Defines patron business logic (membership renewal)
- **ILoanService**: Defines loan business logic (extend, return)

### Key Implementation Classes
- **ConsoleApp**: Main application controller implementing state machine pattern
- **LoanService**: Business logic for loan operations with validation
- **PatronService**: Business logic for patron operations
- **JsonPatronRepository**: JSON-based patron data persistence
- **JsonLoanRepository**: JSON-based loan data persistence
- **JsonData**: Central data management and object population

### Enums
- **ConsoleState**: Application navigation states (PatronSearch, PatronDetails, etc.)
- **CommonActions**: Available user actions (Select, Quit, Extend, Return, etc.)
- **LoanExtensionStatus**: Results of loan extension operations
- **LoanReturnStatus**: Results of loan return operations
- **MembershipRenewalStatus**: Results of membership renewal operations

## Usage

### Prerequisites
- .NET 8 SDK
- Visual Studio 2022 or VS Code with C# extension

### Running the Application

1. Clone the repository
2. Navigate to the solution directory
3. Build the solution:
   ```bash
   dotnet build
   ```
4. Run the console application:
   ```bash
   dotnet run --project AccelerateDevGitHubCopilot/src/Library.Console
   ```

### Application Flow

1. **Patron Search**: Enter a patron name to search the library database
2. **Select Patron**: Choose from matching results to view patron details
3. **View Patron Details**: See membership info and current loans
4. **Manage Loans**: Select individual loans to extend or return books
5. **Membership Management**: Renew patron memberships as needed

### Available Actions
- **Search Patrons**: Find library members by name
- **Extend Loans**: Add 14 days to loan due dates
- **Return Books**: Mark loans as returned
- **Renew Membership**: Extend patron membership by one year

### Running Tests
```bash
dotnet test
```

## License

This project is for educational purposes and is part of the GitHub Copilot guided project module.