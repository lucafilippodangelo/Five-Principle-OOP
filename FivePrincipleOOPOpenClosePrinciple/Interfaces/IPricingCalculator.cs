using FivePrincipleOOP.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FivePrincipleOOPOpenClosePrinciple.Interfaces
{
    public interface IPricingCalculator
    {
        decimal CalculatePrice(OrderItem item);
    }
}
