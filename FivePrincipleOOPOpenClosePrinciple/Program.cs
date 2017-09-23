

using FivePrincipleOOPOpenClosePrinciple.Models;
using System;

namespace FivePrincipleOOPOpenClosePrinciple
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Cart carrello = new Cart();
            carrello.Add(new FivePrincipleOOP.Models.OrderItem() { Quantity = 500, Sku = "WEIGHT_PEANUTS" });
            var luca= carrello.TotalAmount();
        }
    }
}