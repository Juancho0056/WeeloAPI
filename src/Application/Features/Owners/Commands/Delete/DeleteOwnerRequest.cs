using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WeeloApi.Application.Common.Abstracts;
using WeeloApi.Application.Common.Exceptions;
using WeeloApi.Application.Common.Interfaces;

namespace WeeloApi.Application.Features.Owners.Commands.Delete
{
    /// <summary>
    /// Delete record by IdOwner
    /// </summary>
    public class DeleteOwnerRequest : CommandRequest<Unit>, IValidatableObject
    {
        /// <summary>
        /// Identification Owner
        /// </summary>
        /// <example>1</example>
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        public int IdOwner { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errores = new List<ValidationResult>();
            
            return errores;

        }
    }
}