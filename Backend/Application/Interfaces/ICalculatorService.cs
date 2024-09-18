using Application.Models;

namespace Application.Interfaces;

public interface ICalculatorService
{
    CalculationResult Calculate(string expression);
    CalculationResult Add(double a, double b);
    CalculationResult Subtract(double a, double b);
    CalculationResult Multiply(double a, double b);
    CalculationResult Divide(double a, double b);
    CalculationResult Power(double baseValue, double exponent);
    CalculationResult Root(double value);
}
