using Amazon.Lambda.Core;
using Amazon.Lambda.Annotations;
using Amazon.Lambda.Annotations.APIGateway;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace backend;

public class Functions
{
    private ICalculatorService _calculatorService;
    
    public Functions(ICalculatorService calculatorService)
    {
        _calculatorService = calculatorService;
    }
    
    [LambdaFunction()]
    [HttpApi(LambdaHttpMethod.Get, "/")]
    public string Default()
    {
        var docs = @"Lambda Calculator Home:
You can make the following requests to invoke other Lambda functions perform calculator operations:
/add/{x}/{y}
/subtract/{x}/{y}
/multiply/{x}/{y}
/divide/{x}/{y}
";
        return docs;
    }
    
    [LambdaFunction()]
    [HttpApi(LambdaHttpMethod.Get, "/add/{x}/{y}")]
    public IHttpResult Add(int x, int y, ILambdaContext context)
    {
        var sum = _calculatorService.Add(x, y);

        context.Logger.LogInformation($"{x} plus {y} is {sum}");
        return HttpResults.Ok(x + y);
    }
    
    [LambdaFunction()]
    [HttpApi(LambdaHttpMethod.Get, "/subtract/{x}/{y}")]
    public IHttpResult Subtract(int x, int y, ILambdaContext context)
    {
        var difference = _calculatorService.Subtract(x, y);

        context.Logger.LogInformation($"{x} subtract {y} is {difference}");
        return HttpResults.Ok(difference);
    }
    
    [LambdaFunction()]
    [HttpApi(LambdaHttpMethod.Get, "/multiply/{x}/{y}")]
    public IHttpResult Multiply(int x, int y, ILambdaContext context)
    {
        var product = _calculatorService.Multiply(x, y);

        context.Logger.LogInformation($"{x} multiplied by {y} is {product}");
        return HttpResults.Ok(product);
    }
    
    [LambdaFunction()]
    [HttpApi(LambdaHttpMethod.Get, "/divide/{x}/{y}")]
    public IHttpResult Divide(int x, int y, ILambdaContext context)
    {
        var quotient = _calculatorService.Divide(x, y);

        context.Logger.LogInformation($"{x} divided by {y} is {quotient}");
        return HttpResults.Ok(quotient);
    }
}