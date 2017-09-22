using FivePrincipleOOP.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FivePrincipleOOPOpenClosePrinciple.Interfaces
{
    public interface IPriceRule
    {
        
        bool IsMatch(OrderItem item);
        decimal CalculatePrice(OrderItem item);
    }
}
