# CatFact Console App

A simple .NET console application that fetches random cat facts from the [catfact.ninja](https://catfact.ninja/) API and allows you to save them to a text file.

## Features

- Fetch a random cat fact from the API
- Display the last fetched fact in the console
- Save fetched facts to `saved_facts.txt` (appended, one per line)
- View all saved facts

## Prerequisites

- [.NET 6.0 SDK or later](https://dotnet.microsoft.com/download)
- Git

## Getting Started

Follow these steps to get up and running:

### 1. Clone the Repository

```bash
git clone https://github.com/zanpatryk/CatFact.git
cd CatFact
```

### 2. Restore Dependencies

Restore the NuGet packages required by the project:

```bash
dotnet restore
```

### 3. Build the Project

Compile the application:

```bash
dotnet build
```

### 4. Run the Application

Start the console app:

```bash
dotnet run
```

You should see a menu with options:

```
Choose an option:
1) Peek current fact
2) Save last fact
3) Peek saved facts file
4) Exit
```

- **1)** Fetches and displays a new cat fact
- **2)** Saves the last fetched fact to `saved_facts.txt`
- **3)** Displays all facts saved so far
- **4)** Exits the application

### 5. Running Testing

Unit tests are included alongside the app. To execute them:

```bash
dotnet test
```

This will discover and run all xUnit tests, including:

FactServiceTests: Mocks HTTP responses to verify JSON deserialization (FactService.GetFactAsync).

ProgramTests: Mocks IFactService and redirects console I/O to verify menu flow and output.

Tests use xUnit and Moq for mocking dependencies.

## File Location

- The `saved_facts.txt` file is created in the same directory where the application is run.

---
