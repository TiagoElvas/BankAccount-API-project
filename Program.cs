using System;
using System.Threading.Tasks;

class Hello
{
    static async Task Main(String[] args)
    {
        BankAccount bank = new BankAccount();

        Console.WriteLine("Welcome to the Bank Account App!");
        Console.WriteLine("1. Deposit money");
        Console.WriteLine("2. Withdraw money");
        Console.WriteLine("3. View balance");
        Console.WriteLine("4. View transaction history");
        Console.WriteLine("5. Convert balance to Bitcoin (BTC)");
        Console.WriteLine("0. Exit");
        
        while (true)
        {
             Console.Write("\nSelect an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Enter deposit amount: ");
                    int depositAmount = int.Parse(Console.ReadLine());
                    bank.Deposit(depositAmount);
                    break;

                case "2":
                    Console.Write("Enter withdrawal amount: ");
                    int withdrawAmount = int.Parse(Console.ReadLine());
                    bank.Withdraw(withdrawAmount);
                    break;

                case "3":
                    Console.WriteLine($"Your balance: {bank.getBalance()}€");
                    break;

                case "4":
                    bank.GetTransactions();
                    break;

                case "5":
                    await bank.ConvertBalanceToBitcoin();
                    break;

                case "0":
                    Console.WriteLine("Exiting... Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
        }


        

        


    }
}

