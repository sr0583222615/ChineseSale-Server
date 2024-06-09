﻿using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace AngularServer1
{
    // Custom operation filter to include security header in Swagger UI
    public class SecurityRequirementsOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var filterPipeline = context.ApiDescription.ActionDescriptor.FilterDescriptors;
            var hasAuthorizeFilter = filterPipeline.Any(filterInfo => filterInfo.Filter is Microsoft.AspNetCore.Mvc.Authorization.AuthorizeFilter);

            if (hasAuthorizeFilter)
            {
                operation.Security = new List<OpenApiSecurityRequirement>
            {
                new OpenApiSecurityRequirement
                {
                    [
                        new OpenApiSecurityScheme { Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" } }
                    ] = new List<string>()
                }
            };
            }
        }
    }
}
