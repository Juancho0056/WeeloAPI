using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WeeloApi.Application.Common.Abstracts;
using WeeloApi.Application.Common.Exceptions;
using WeeloApi.Application.Common.Interfaces;
namespace WeeloApi.Application.Features.PropertyTraces.Commands.Create
{
    /// <summary>
    /// Data to create new record for trace property
    /// </summary>
    public class CreatePropertyTraceRequest : CommandRequest<PropertyTraceDto>, IValidatableObject
    {
        /// <summary>
        /// Sale publication date for Property
        /// </summary>
        /// <example>2021-12-31</example>
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        public DateTime DateSale { get; set; }
        /// <summary>
        /// Name for Property
        /// </summary>
        /// <example>APTO 906</example>
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        [MaxLength(150, ErrorMessage = ErrorMessage.MaxLength + "150.")]
        public string Name { get; set; }
        /// <summary>
        /// Price for Property
        /// </summary>
        /// <example>1000000</example>
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        [Range(typeof(decimal), "0", "99999999999999999999999", ErrorMessage = ErrorMessage.DecimalLength + "24")]
        public decimal Value { get; set; }
        /// <summary>
        /// Tax for Property
        /// </summary>
        /// <example>1000000</example>
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        [Range(typeof(decimal), "0", "99999999999999999999999", ErrorMessage = ErrorMessage.DecimalLength + "24")]
        public decimal Tax { get; set; }

        /// <summary>
        /// Property for Trace
        /// </summary>
        /// <example>1</example>
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        [Range(0, int.MaxValue, ErrorMessage = ErrorMessage.MaxLength )]
        public int IdProperty { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errores = new List<ValidationResult>();
            var _context = (IApplicationDbContext)validationContext.GetService(typeof(IApplicationDbContext));

           
                
                return errores;
   
        }
    }
}