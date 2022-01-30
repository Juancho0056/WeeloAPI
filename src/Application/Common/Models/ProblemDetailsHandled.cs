using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeeloApi.Application.Common.Models
{
    /// <summary>
    ///     Class for validation errors.
    /// </summary>
    public class ProblemDetailsHandled
    {
        /// <summary>
        ///     Name for Exception
        /// </summary>
        /// <example>NullReferenceException</example>
        public string Name { get; set; }
        /// <summary>
        /// Exception page help
        /// </summary>
        /// <example>https://tools.ietf.org/html/rfc7231#section-6.5.4</example>
        public string Type { get; set; }
        /// <summary>
        /// Description for the Exception
        /// </summary>
        /// <example>The specified resource was not found.</example>
        public string Title { get; set; }
        /// <summary>
        /// Exception Message 
        /// </summary>
        /// <example>Object reference not set to an instance of an object.</example>
        public string Message { get; set; }
        /// <summary>
        /// Exception StackTrace
        /// </summary>
        /// <example>  at WeeloApi.Application.Features.Owners.Queries.Get.GetOwnerHandler.HandleQuery(GetOwnerRequest request, CancellationToken cancellationToken) in C:\Users\ASUS\OneDrive\Documents\WeeloApi\src\Application\Features\Owners\Queries\Get\GetOwnerHandler.cs:line 25</example>
        public string StackTrace { get; set; }
    }
}
