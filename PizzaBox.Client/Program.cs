using System;
using System.Collections.Generic;
using PizzaBox.Domain.Models;
using PizzaBox.Domain.Abstracts;

namespace PizzaBox.Client
{
    public class Program
    {
       private static void Main()
        {
            var stores = new List<AStore>{new ChicagoStore(), new NewYorkStore()};
            Console.WriteLine("Select a Store:");
            for(var x=0; x < stores.Count; x++){
                Console.WriteLine($"{x} for {stores[x]}");
            }

            string input = Console.ReadLine();

            Console.WriteLine(stores[int.Parse(input)]);
        }

    }
}