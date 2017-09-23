using FivePrincipleOOPOpenClosePrinciple.Models;

namespace FivePrincipleOOPOpenClosePrinciple.Interfaces
{
    public interface IPricingCalculator
    {
        decimal CalculatePrice(OrderItem item);
    }
}
