 
  # BankAccount API Project #
This is a simple C# Console Application that simulates a bank account with transaction history. It also includes an API integration to fetch real-time Bitcoin prices and convert the account balance from Euros to Bitcoin.

### Features ###

✅ Deposit and withdraw money from a bank account

✅ Keep track of transaction history (type, amount, date, balance)

✅ Fetch real-time Bitcoin price using an API

✅ Convert account balance from Euros to Bitcoin

## 🚀 Getting Started ##

**Pre-requisites**
.NET SDK (Download: https://dotnet.microsoft.com/en-us/download)
Visual Studio Code / Visual Studio / Rider (Any C# IDE)

## 📥 Installation ##

**1. Clone the repository**
```bash
git clone https://github.com/YOUR_USERNAME/BankAccountProject.git
cd BankAccountProject
```

**2. Install dependencies**
```bash
dotnet add package Newtonsoft.Json
```

**3. Run the application**
```bash
dotnet run
```
---

## 📡 API Integration ##

This project calls an external cryptocurrency API to fetch Bitcoin prices and convert the user's balance.

Example API Response:

{
    "bitcoin": {
        "usd": 43000.50
    }
}

Conversion Formula:

Balance in BTC = Balance in EUR / Bitcoin Price in USD

## 📌 Project Structure ##

📂 BankAccountProject

├── 📄 Program.cs                 # Main execution file

├── 📄 BankAccount.cs             # Handles deposits, withdrawals & balance

├── 📄 Transaction.cs             # Stores transaction details

├── 📄 README.md                  # Documentation

├── 📄 BankAccountProject.csproj   # .NET project file

## 🛠 Technologies Used ##

**C# (.NET 6+)**

**Newtonsoft.Json (for JSON parsing)**

**HttpClient (for API requests)**

📝 To-Do & Future Improvements

✅ Improve UI (Make it interactive with user input)

✅ Store transactions in a database (instead of just memory)

✅ Add more API integrations (e.g., exchange rates, other crypto prices)
