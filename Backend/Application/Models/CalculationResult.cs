namespace Application.Models;

public class CalculationResult
{
    public double Result { get; set; }
    public string ErrorMessage { get; set; }

    public bool IsError { get; set; }

    public CalculationResult(bool isError, double result)
    {
        IsError = isError;
        Result = result;
    }
    public CalculationResult(bool isError, string message)
    {
        IsError = isError;
        ErrorMessage = message;
    }

    public static CalculationResult Operation(double result) => new CalculationResult(false, result);
    public static CalculationResult Error(string message) => new CalculationResult(true, message);
}
