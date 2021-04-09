using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Amazon.Lambda.Core;
using System.Dynamic;
using Newtonsoft.Json;
using Amazon.Lambda.APIGatewayEvents;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace Assignment9
{
    public class Function
    {
        static readonly HttpClient client = new HttpClient();
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task<ExpandoObject>  FunctionHandler(APIGatewayProxyRequest input, ILambdaContext context)
        {
            dynamic data = new ExpandoObject();
            Dictionary<string, string> dict = (Dictionary<string, string>)input.QueryStringParameters;
            string something = await client.GetStringAsync("https://api.nytimes.com/svc/books/v3/lists/current/" + dict.First().Value + ".json?api-key=iXIGuGPUAFHQ5FFAnHAdkrJJ0at4fkLV");
            dynamic objects = JsonConvert.DeserializeObject<ExpandoObject>(something);
            return objects;

            //Easily breakable but it beats your 6 lines SOOOOONNNNNNNNNNN
            
        }

        
    }
}
