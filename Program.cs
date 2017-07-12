using System;
using System.Collections.Generic;

namespace dictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine();
            
            Dictionary<string, string> stocks = new Dictionary<string, string>();
            stocks.Add("GM", "General Motors");
            stocks.Add("CAT", "Caterpillar");
            // Add a few more of your favorite stocks
            stocks.Add("AMZN", "Amazon");
            stocks.Add("TSLA", "Tesla");
            stocks.Add("AAPL", "Apple");

            //To find a value in a Dictionary, you can use square bracket notation much like JavaScript object key lookups.
            //string GM = stocks["GM"];   <--- "General Motors"
            //Create list of ValueTuples that represents stock purchases. Properties will be ticker, shares, price.

            List<(string ticker, int shares, double price)> purchases = new List<(string, int, double)>();

            // Add more for each stock you added to the stocks dictionary
            purchases.Add((ticker: "AMZN", shares: 64, price: 22.49));
            purchases.Add((ticker: "AAPL", shares: 49, price: 28.31));
            purchases.Add((ticker: "TSLA", shares: 20, price: 43.88));

            /* 
            Define a new Dictionary to hold the aggregated purchase information.
            - The key should be a string that is the full company name.
            - The value will be the valuation of each stock (price*amount)

            {
                "General Electric": 35900,
                "AAPL": 8445,
                ...
            }
            */

            Dictionary<string, double> purchaseInfo = new Dictionary<string, double>();

            // Iterate over the purchases and 
            foreach ((string ticker, int shares, double price) purchase in purchases)
            {
            // Does the company name key already exist in the report dictionary?
                string key = stocks[purchase.ticker];

            // If it does, update the total valuation
                if(purchaseInfo.ContainsKey(key)){
                    purchaseInfo[key] = purchaseInfo[key] + purchase.price;

                    Console.WriteLine($"{key} value is {purchaseInfo[key]:C}");
            // If not, add the new key and set its value
                } else {
                    purchaseInfo.Add(key, purchase.price);
                    Console.WriteLine($"{key} value is {purchaseInfo[key]:C}");
                }
            }
            Console.WriteLine();

            foreach(KeyValuePair<string, double>item in purchaseInfo){
                Console.WriteLine($"{item.Key} sold {item.Value} shares");
            }
        }
    }
}