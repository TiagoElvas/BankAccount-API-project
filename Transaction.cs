using System;

class Transaction 
{
    public string TransactionType { get; set; }
    public int Amount { get; set; }
    public DateTime Date { get; set; }
    public int BalanceAfter { get; set; }

    public Transaction(string transactionType, int amount, DateTime date, int balanceAfter)
    {
        this.TransactionType = transactionType;
        this.Amount = amount;
        this.Date = date;
        this.BalanceAfter = balanceAfter;
    }

    // Method to print transaction details
    public void PrintTransactionHistory()
    {
        Console.WriteLine($"---- Transaction type: {TransactionType} ----");
        Console.WriteLine($"Amount: {Amount}€");
        Console.WriteLine($"Date: {Date:yyyy-MM-dd HH:mm:ss}"); // formatted date
        Console.WriteLine($"Balance after: {BalanceAfter}€");
        Console.WriteLine("----------------------------------------");
    }
}
