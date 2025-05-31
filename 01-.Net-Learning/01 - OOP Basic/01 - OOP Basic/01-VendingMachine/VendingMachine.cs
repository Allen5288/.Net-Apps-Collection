using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01___OOP_Basic.VendingMachine
{
    internal class VendingMachine
    {
        int price = 2;
        int balance;
        int total;

        public void ShowPromot()
        {
            Console.WriteLine("Welcome to the Vending Machine!");
            Console.WriteLine("Please insert coins to purchase an item.");
            Console.WriteLine($"Item price: {price} coins");
        }

        public void InsertMoney(int amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Please insert a valid amount of coins.");
                return;
            }
            balance += amount;
            Console.WriteLine($"You have inserted {amount} coins. Current balance: {balance} coins.");
        }

        public void ShowBalance()
        {
            Console.WriteLine($"Your current balance is: {balance} coins.");
        }

        public void ShowTotal()
        {
            Console.WriteLine($"Total amount inserted: {total} coins.");
        }

        public void GetVendingItem()
        {
            if (balance < price)
            {
                Console.WriteLine("Insufficient balance. Please insert more coins.");
                return;
            }
            balance -= price;
            total += price;
            Console.WriteLine($"You have purchased an item for {price} coins. Remaining balance: {balance} coins.");
        }

    }
}
