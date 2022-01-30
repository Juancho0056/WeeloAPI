using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WeeloApi.Application.Common.Abstracts;
using WeeloApi.Application.Common.Exceptions;
using WeeloApi.Application.Common.Interfaces;

namespace WeeloApi.Application.Features.Owners.Commands.Delete
{
    /// <summary>
    /// Delete record by Property Image
    /// </summary>
    public class DeletePropertyImageRequest : CommandRequest<Unit>, IValidatableObject
    {
        /// <summary>
        /// Identification Property Image
        /// </summary>
        /// <example>1</example>
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        public int IdPropertyImage { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errores = new List<ValidationResult>();
          
                return errores;

        }
    }
}