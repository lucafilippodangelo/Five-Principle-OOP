using System;
using System.Collections.Generic;
using System.Text;
using FivePrincipleOOPOpenClosePrinciple.Models;

namespace FivePrincipleOOPOpenClosePrinciple.Interfaces
{
    public interface IPriceRule
    {
        bool IsMatch(OrderItem item);
        decimal CalculatePrice(OrderItem item);
    }
}
