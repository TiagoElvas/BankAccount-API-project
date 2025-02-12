using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Text.Json.Nodes;

class BankAccount
{
    private int _balance = 100;
    private string Owner = "Tiago";
    private List<Transaction> Transactions = new List<Transaction>();

    // Withdraw method
    public int Withdraw(int amount)
    {
        if (amount > _balance)
        {
            int amountToWithdraw = amount - _balance;
            Console.WriteLine($"{Owner}, the amount you want to withdraw is more than what you have in your fund.");
            Console.WriteLine($"{Owner}, you need to provide an additional: {amountToWithdraw}€");
            Console.WriteLine($"{Owner}, current balance = {_balance}€");

            // Add transaction to history (with insufficient funds)
            Transactions.Add(new Transaction("withdraw", amount, DateTime.Now, getBalance()));
            return amountToWithdraw;
        }

        // Successful withdrawal
        _balance -= amount;
        Transactions.Add(new Transaction("withdraw", amount, DateTime.Now, getBalance()));
        return _balance;
    }

    // Deposit method
    public void Deposit(int amount)
    {
        if (amount < 0)
        {
            Console.WriteLine("Invalid amount. The value must be positive.");
        }
        else
        {
            _balance += amount;
            Transactions.Add(new Transaction("deposit", amount, DateTime.Now, getBalance()));
        }
    }

    // Getter for current balance
    public int getBalance()
    {
        return _balance;
    }

    // Method to print and return all transactions
    public List<Transaction> GetTransactions()
    {
        foreach (Transaction currentTransaction in Transactions)
        {
            currentTransaction.PrintTransactionHistory();  // Print each transaction's history
        }
        return Transactions; // Optionally return the list of transactions
    }

    // Method that makes a http request to an API
    public async Task ConvertBalanceToBitcoin()
    {

        Console.WriteLine("Fetching Bitcoin Price ...");

        string url = "https://api.coingecko.com/api/v3/simple/price?ids=bitcoin&vs_currencies=usd";

        //creating an new Http instance
        using (HttpClient client = new HttpClient())
        {

            try
            {
                //sends an new HTTP get request to an url (an API endpoint) and waits for the response.
                HttpResponseMessage response = await client.GetAsync(url);

                //checks if the response status is 200 (ok), otherwise, throws an exception;
                response.EnsureSuccessStatusCode();

                //reads the response body asynchronously
                string jsonResponse = await response.Content.ReadAsStringAsync();

                //Parses the JSON strin into a JObject
                JObject data = JObject.Parse(jsonResponse);


                // Extracts the value of "usd" inside the "bitcoin" JSON object. 
                // This gives the **current price of Bitcoin in USD**.
                double btcPrice = (double)data["bitcoin"]["usd"];

                // Converts the user's balance from Euros (€) to Bitcoin (BTC). 
                // It does this by dividing the current balance by the Bitcoin price.
                double balanceInBtc = _balance / btcPrice;

                // Prints the converted balance, formatted to 6 decimal places (F6), ensuring a proper BTC format.
                Console.WriteLine($"{Owner}, your balance of {_balance}€ is approximately {balanceInBtc:F6} BTC.");



            }catch(Exception ex){
                Console.WriteLine("Error fetching Bitcoin price. Error: " + ex.Message);
            }
        }



    }
}