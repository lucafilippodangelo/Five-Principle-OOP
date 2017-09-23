using FivePrincipleOOPOpenClosePrinciple.Interfaces;
using FivePrincipleOOPOpenClosePrinciple.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FivePrincipleOOPOpenClosePrinciple.InterfaceImplementation
{
    public class Buy4GetOneFree : IPriceRule
    {
        public bool IsMatch(OrderItem item)
        {
            return item.Sku.StartsWith("B4GO");
        }

        //LD STEP3
        public decimal CalculatePrice(OrderItem item)
        {
            decimal total = 0m;
            total += item.Quantity * 1m;
            int setsOfFive = item.Quantity / 5;
            total -= setsOfFive * 1m;
            return total;
        }
    }
}
