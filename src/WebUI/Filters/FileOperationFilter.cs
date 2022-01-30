using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace WeeloApi.WebUI.Filters
{
    /// <summary>
    /// Filter property File Swagger
    /// </summary>
    public class FileOperationFilter : IOperationFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="context"></param>
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var isMultipart = context.ApiDescription.ActionDescriptor.ActionConstraints
            .Select(r => r as ConsumesAttribute)
            .Where(r => r != null && r.ContentTypes.Any(p => p == "multipart/form-data")).Any();

            if (isMultipart) 
            {
                operation.RequestBody = new OpenApiRequestBody
                {
                    Content =
                {
                    ["multipart/form-data"] = new OpenApiMediaType()
                    {
                        Encoding =
                        {
                            ["files"] = new OpenApiEncoding()
                            {
                                Style = ParameterStyle.Form
                            }
                        },
                        Schema = new OpenApiSchema()
                        {
                            Type = "object",
                            Properties =
                            {
                                ["files"] = new OpenApiSchema()
                                {
                                    Description = "Select file",
                                    Type = "array",
                                    Items = new OpenApiSchema()
                                    {
                                        Type="string",
                                        Format="binary",
                                    }
                                }
                            }
                        }
                    }
                }
                };
            }
        }
    }
}
