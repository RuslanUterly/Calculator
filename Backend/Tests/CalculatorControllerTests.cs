using Application.Interfaces;
using Application.Models;
using Calculator.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Persistance.Models;

namespace Tests;

public class CalculatorControllerTests
{
    private readonly Mock<ICalculatorService> _mockCalculatorService;
    private readonly CalculatorController _controller;

    public CalculatorControllerTests()
    {
        _mockCalculatorService = new Mock<ICalculatorService>();
        _controller = new CalculatorController(_mockCalculatorService.Object);
    }

    [Fact]
    public void Add_ShouldReturnOk_WhenSuccess()
    {
        // Arrange
        var operand = new OperationRequest { BaseValue = 5, Value = 3 };
        var calculationResult = new CalculationResult(false, 8);
        _mockCalculatorService.Setup(s => s.Add(operand.BaseValue, operand.Value)).Returns(calculationResult);

        // Act
        var result = _controller.Add(operand) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal(8d, Convert.ToDouble(result.Value));
    }

    [Fact]
    public void Subtract_ShouldReturnOk_WhenSuccess()
    {
        // Arrange
        var operand = new OperationRequest { BaseValue = 5, Value = 3 };
        var calculationResult = new CalculationResult(false, 2);
        _mockCalculatorService.Setup(s => s.Subtract(operand.BaseValue, operand.Value)).Returns(calculationResult);

        // Act
        var result = _controller.Subtract(operand) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal(2d, Convert.ToDouble(result.Value));
    }

    [Fact]
    public void Multiply_ShouldReturnOk_WhenSuccess()
    {
        // Arrange
        var operand = new OperationRequest { BaseValue = 5, Value = 3 };
        var calculationResult = new CalculationResult(false, 15);
        _mockCalculatorService.Setup(s => s.Multiply(operand.BaseValue, operand.Value)).Returns(calculationResult);

        // Act
        var result = _controller.Multiply(operand) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal(15d, Convert.ToDouble(result.Value));
    }

    [Fact]
    public void Divide_ShouldReturnBadRequest_WhenCalculationIsError()
    {
        // Arrange
        var operand = new OperationRequest { BaseValue = 5, Value = 0 };
        var calculationResult = new CalculationResult(true, "Деление на ноль");
        _mockCalculatorService.Setup(s => s.Divide(operand.BaseValue, operand.Value)).Returns(calculationResult);

        // Act
        var result = _controller.Divide(operand) as BadRequestObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(400, result.StatusCode);
        Assert.Equal("Деление на ноль", result.Value);
    }

    [Fact]
    public void Power_ShouldReturnOk_WhenSuccess()
    {
        // Arrange
        var operation = new OperationRequest { BaseValue = 2, Value = 3 };
        var calculationResult = new CalculationResult(false, 8);
        _mockCalculatorService.Setup(s => s.Power(operation.BaseValue, operation.Value)).Returns(calculationResult);

        // Act
        var result = _controller.Power(operation) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal(8d, Convert.ToDouble(result.Value));
    }

    [Fact]
    public void Root_ShouldReturnBadRequest_WhenCalculationIsError()
    {
        // Arrange
        var operation = new OperationRequest { BaseValue = -4, Value = 2 };
        var calculationResult = new CalculationResult (true, "Нельзя произвести операцию с числом меньше нуля");

        _mockCalculatorService.Setup(s => s.Root(operation.BaseValue, operation.Value)).Returns(calculationResult);

        // Act
        var result = _controller.Root(operation) as BadRequestObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(400, result.StatusCode);
        Assert.Equal("Нельзя произвести операцию с числом меньше нуля", result.Value);
    }

    [Fact]
    public void Calculate_ShouldReturnOk_WhenSuccess()
    {
        // Arrange
        var request = new CalculateRequest { Expression = "5 + 3" };
        var calculationResult = new CalculationResult (false, 8);
        _mockCalculatorService.Setup(s => s.Calculate(request.Expression)).Returns(calculationResult);

        // Act
        var result = _controller.Calculate(request) as OkObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
        Assert.Equal(8d, Convert.ToDouble(result.Value));
    }

    [Fact]
    public void Calculate_ShouldReturnBadRequest_WhenCalculationIsError()
    {
        // Arrange
        var request = new CalculateRequest { Expression = "5 / 0" };
        var calculationResult = new CalculationResult (true, "Деление на ноль");
        _mockCalculatorService.Setup(s => s.Calculate(request.Expression)).Returns(calculationResult);

        // Act
        var result = _controller.Calculate(request) as BadRequestObjectResult;

        // Assert
        Assert.NotNull(result);
        Assert.Equal(400, result.StatusCode);
        Assert.Equal("Деление на ноль", result.Value);
    }
}