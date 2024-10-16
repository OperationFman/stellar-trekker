using Amazon.Lambda.APIGatewayEvents;
using Backend.Base;
using Backend.BLL.Services;
using Backend.Client.Requests;
using Newtonsoft.Json;
using System.Net;

namespace Backend.Lambdas
{
    public class PlacePalletFunction : BaseLambdaFunction
    {
        public APIGatewayProxyResponse PlacePallet(LambdaRequest lambdaRequest)
        {
            var palletService = new PalletService();
            var placePalletRequest = JsonConvert.DeserializeObject<PlacePalletRequest>(lambdaRequest.Body);
            palletService.PlacePallet(placePalletRequest);

            return new APIGatewayProxyResponse
            {
                StatusCode = (int)HttpStatusCode.OK
            };
        }
    }
}
