﻿using FivePrincipleOOP.Models;
using FivePrincipleOOPOpenClosePrinciple.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace FivePrincipleOOPOpenClosePrinciple.InterfaceImplementation
{
    public class PerGramPriceRule : IPriceRule
    {
        public bool IsMatch(OrderItem item)
        {
            return item.Sku.StartsWith("WEIGHT");
        }

        //LD STEP3
        public decimal CalculatePrice(OrderItem item)
        {
            return item.Quantity * 4m / 1000;
        }
    }
}