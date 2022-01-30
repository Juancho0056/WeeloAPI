using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WeeloApi.Application.Common.Abstracts;
using WeeloApi.Application.Common.Exceptions;
using WeeloApi.Application.Common.Interfaces;
using WeeloApi.Application.Common.Utils;

namespace WeeloApi.Application.Features.Propertys.Commands.Update
{
    public class ChangePriceRequest : CommandRequest<PropertyDto>, IValidatableObject
    {
        /// <summary>
        /// Identification for Property
        /// </summary>
        /// <example>1</example>
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        public int IdProperty { get; set; }

        /// <summary>
        /// Price for Property
        /// </summary>
        /// <example>1000000</example>
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        [Range(typeof(decimal), "0", "99999999999999999999999", ErrorMessage = ErrorMessage.DecimalLength + "24")]
        public decimal Price { get; set; }
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errores = new List<ValidationResult>();
            var ServiceOptions = (IOptions<Global>)validationContext.GetService(typeof(IOptions<Global>));

  

                return errores;
        }
    }
}