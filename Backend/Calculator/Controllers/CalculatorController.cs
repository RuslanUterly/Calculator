using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Persistance.Models;
using Persistance;
using Infrastructure;

namespace Calculator.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CalculatorController(ICalculatorService calculatorService) : ControllerBase
{
    private readonly ICalculatorService _calculatorService = calculatorService;

    [HttpPost("add")]
    public IActionResult Add([FromBody] OperationRequest operand)
    {
        var calculate = _calculatorService.Add(operand.BaseValue, operand.Value);

        return Ok(calculate.Result);
    }

    [HttpPost("subtract")]
    public IActionResult Subtract([FromBody] OperationRequest operand)
    {
        var calculate = _calculatorService.Subtract(operand.BaseValue, operand.Value);

        return Ok(calculate.Result);
    }

    [HttpPost("multiply")]
    public IActionResult Multiply([FromBody] OperationRequest operand)
    {
        var calculate = _calculatorService.Multiply(operand.BaseValue, operand.Value);

        return Ok(calculate.Result);
    }

    [HttpPost("divide")]
    [DevidedByZeroFilter()]
    public IActionResult Divide([FromBody] OperationRequest operand)
    {
        var calculate = _calculatorService.Divide(operand.BaseValue, operand.Value);

        if (calculate.IsError)
            return BadRequest(calculate.ErrorMessage);

        return Ok(calculate.Result);
    }

    [HttpPost("pow")]
    [InfinityFilter()]
    public IActionResult Power([FromBody] OperationRequest operation)
    {
        var calculate = _calculatorService.Power(operation.BaseValue, operation.Value);

        if (calculate.IsError)
            return BadRequest(calculate.ErrorMessage);

        return Ok(calculate.Result);
    }

    [HttpPost("root")]
    [InfinityFilter()]
    [NegativeNumberFilter()]
    public IActionResult Root([FromBody] OperationRequest operation)
    {
        var calculate = _calculatorService.Root(operation.BaseValue, operation.Value);

        if (calculate.IsError)
            return BadRequest(calculate.ErrorMessage);

        return Ok(calculate.Result);

    }

    [HttpPost("calculate")]
    public IActionResult Calculate([FromBody] CalculateRequest operation)
    {
        var calculate = _calculatorService.Calculate(operation.Expression);

        if (calculate.IsError)
            return BadRequest(calculate.ErrorMessage);

        return Ok(calculate.Result);
    }
}
