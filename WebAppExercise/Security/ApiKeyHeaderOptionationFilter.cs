using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebAppExercise.Security
{
    public class ApiKeyHeaderOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            if (operation.Parameters == null)
                operation.Parameters = new List<OpenApiParameter>();

            var api_key_header = new OpenApiParameter
            {
                Name = SecurityConstants.ApiKeyHeaderName,
                In = ParameterLocation.Header,
                Required = true,
                Schema = new OpenApiSchema
                {
                    Type = "string"
                }
            };

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == Environments.Development)
                api_key_header.Schema.Default = new OpenApiString("3ce68e99-c33d-4dda-b6f5-e48377e24f55");

            operation.Parameters.Add(api_key_header);
        }
    }
}
