using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeeloApi.Application.Common.Abstracts;
using WeeloApi.Application.Common.Exceptions;
using WeeloApi.Application.Common.Interfaces;

namespace WeeloApi.Application.Features.Propertys.Commands.Delete
{
    /// <summary>
    /// Delete record by IdProperty
    /// </summary>
    public class DeletePropertyRequest : CommandRequest<Unit>, IValidatableObject
    {
        /// <summary>
        /// Identification Property
        /// </summary>
        /// <example>1</example>
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        public int IdProperty { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errores = new List<ValidationResult>();

                return errores;
         
        }
    }
}