using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using WeeloApi.Application.Common.Abstracts;
using WeeloApi.Application.Common.Exceptions;

namespace WeeloApi.Application.Features.Propertys.Commands.Update
{
    public class UpdatePropertyRequest : CommandRequest<PropertyDto>, IValidatableObject
    {
        /// <summary>
        /// Identification for Property
        /// </summary>
        /// <example>1</example>
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        public int IdProperty { get; set; }
        /// <summary>
        /// Name for Property
        /// </summary>
        /// <example>APTO 906</example>
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        [MaxLength(150, ErrorMessage = ErrorMessage.MaxLength + "150.")]
        public string Name { get; set; }
        /// <summary>
        /// Address for Property
        /// </summary>
        /// <example>CRA 9 No 27 - 09 IBAGUE </example>
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        [MaxLength(200, ErrorMessage = ErrorMessage.MaxLength + "200.")]
        public string Address { get; set; }
        /// <summary>
        /// Price for Property
        /// </summary>
        /// <example>1000000</example>
        //[Required(ErrorMessage = ErrorMessage.IsRequired)]
        //[Range(typeof(decimal), "0", "99999999999999999999999", ErrorMessage = ErrorMessage.DecimalLength + "24")]
        //public decimal Price { get; set; }
        /// <summary>
        /// Year for Property
        /// </summary>
        /// <example>2021</example>
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        [Range(typeof(int), "1000", "9999", ErrorMessage = ErrorMessage.DecimalLength + "4")]
        public int Year { get; set; }
        /// <summary>
        /// Owner for Property
        /// </summary>
        /// <example>1</example>
        public int? IdOwner { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errores = new List<ValidationResult>();
         
 
 
                

                return errores;
        
        }
    }
}