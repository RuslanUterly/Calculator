using Application.Interfaces;
using Application.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services;

public class CalculatorService : ICalculatorService
{
    public CalculationResult Calculate(string expression)
    {
        try
        {
            var result = new DataTable().Compute(expression, null);
            return CalculationResult.Operation(Convert.ToDouble(result));
        }
        catch (Exception ex)
        {
            return CalculationResult.Error(ex.Message);
        }
    }

    public CalculationResult Add(double a, double b)
    {
        return CalculationResult.Operation(a + b);
    }

    public CalculationResult Subtract(double a, double b)
    {
        return CalculationResult.Operation(a - b);
    }

    public CalculationResult Divide(double a, double b)
    {
        if (b == 0)
        {
            return CalculationResult.Error("Деление на ноль");
        }

        return CalculationResult.Operation(a / b);
    }

    public CalculationResult Multiply(double a, double b)
    {
        return CalculationResult.Operation(a * b);
    }

    public CalculationResult Power(double baseValue, double exponent)
    {
        return CalculationResult.Operation(Math.Pow(baseValue, exponent));
    }

    public CalculationResult Root(double baseValue, double exponent)
    {
        if (baseValue < 0)
            return CalculationResult.Error("Нельзя произвести операцию с числем меньше нуля");

        return CalculationResult.Operation(Math.Pow(baseValue, 1.0 / exponent));
    }
}
