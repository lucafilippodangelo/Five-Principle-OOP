﻿using FivePrincipleOOPOpenClosePrinciple.Interfaces;
using FivePrincipleOOPOpenClosePrinciple.Models;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System;

namespace FivePrincipleOOPOpenClosePrinciple.InterfaceImplementation
{
    public class PricingCalculator : IPricingCalculator
    {
        private readonly List<IPriceRule> _pricingRules;

        //LD STEP2 
        public PricingCalculator()
        {
            _pricingRules = new List<IPriceRule>();
            _pricingRules.Add(new EachPriceRule());
            _pricingRules.Add(new PerGramPriceRule());
            _pricingRules.Add(new SpecialPriceRule());
            _pricingRules.Add(new Buy4GetOneFree());
        }



        public decimal CalculatePrice(OrderItem item)
        {
            return _pricingRules.First(r => r.IsMatch(item)).CalculatePrice(item);
        }
    }
}
