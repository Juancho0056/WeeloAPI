using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeloApi.Application.Common.Abstracts;
using WeeloApi.Application.Common.Exceptions;
using WeeloApi.Application.Common.Interfaces;
using WeeloApi.Application.Common.Utils;

namespace WeeloApi.Application.Features.PropertyTraces.Commands.Update
{
    public class UpdatePropertyTraceRequest : CommandRequest<PropertyTraceDto>, IValidatableObject
    {
        /// <summary>
        /// Identification for trace
        /// </summary>
        /// <example>1</example>
        public int IdPropertyTrace { get; set; }
        /// <summary>
        /// Sale publication date for Property
        /// </summary>
        /// <example>2021-12-31</example>
        public DateTime? DateSale { get; set; }
        /// <summary>
        /// Name for Property
        /// </summary>
        /// <example>APTO 906</example>
        [MaxLength(150, ErrorMessage = ErrorMessage.MaxLength + "150.")]
        public string Name { get; set; }
        /// <summary>
        /// Price for Property
        /// </summary>
        /// <example>1000000</example>
        [Range(typeof(decimal), "0", "99999999999999999999999", ErrorMessage = ErrorMessage.DecimalLength + "24")]
        public decimal Value { get; set; }
        /// <summary>
        /// Tax for Property
        /// </summary>
        /// <example>1000000</example>
        [Range(typeof(decimal), "0", "99999999999999999999999", ErrorMessage = ErrorMessage.DecimalLength + "24")]
        public decimal Tax { get; set; }

        /// <summary>
        /// Property for Trace
        /// </summary>
        /// <example>1</example>
        [Range(0, int.MaxValue, ErrorMessage = ErrorMessage.MaxLength)]
        public int IdProperty { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errores = new List<ValidationResult>();
            var ServiceOptions = (IOptions<Global>)validationContext.GetService(typeof(IOptions<Global>));
        

            return errores;
          
        }
    }
}