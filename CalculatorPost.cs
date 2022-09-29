using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using MCT.functions.Models;

namespace MCT.function
{
    public static class CalculatorPost
    {
        [FunctionName("CalculatorPost")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "calculator")] HttpRequest req,
            ILogger log)
        {
            string body = await new StreamReader(req.Body).ReadToEndAsync();
            CalculationRequest calculationrequest = JsonConvert.DeserializeObject<CalculationRequest>(body);

            CalculationResult result = new CalculationResult();
            if (calculationrequest.Operator == "+")
            {
                result.Result = (calculationrequest.getal1 + calculationrequest.getal2).ToString();
                result.Operator = calculationrequest.Operator;
            }
            return new OkObjectResult("");
        }
    }
}
