using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using WeeloApi.Application.Common.Abstracts;
using WeeloApi.Application.Common.Exceptions;
using WeeloApi.Application.Common.Extensions;
using WeeloApi.Application.Common.Interfaces;
using WeeloApi.Application.Common.Utils;

namespace WeeloApi.Application.Features.Owners.Commands.Update
{
    /// <summary>
    /// Data to update  record owner by IdOwner
    /// </summary>
    public class UpdateOwnerRequest : CommandRequest<OwnerDto>, IValidatableObject
    {
        /// <summary>
        /// Identification for Owner
        /// </summary>
        /// <example>1</example>
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        public int IdOwner { get; set; }
        /// <summary>
        /// Name for Owner
        /// </summary>
        /// <example>JUAN CARLOS CARDONA</example>
        [MaxLength(150, ErrorMessage = ErrorMessage.MaxLength + "150.")]
        public string Name { get; set; }
        /// <summary>
        /// Address for Owner
        /// </summary>
        /// <example>CRA 9 No 27 - 09 IBAGUE </example>
        [MaxLength(200, ErrorMessage = ErrorMessage.MaxLength + "200.")]
        public string Address { get; set; }
        /// <summary>
        /// File data to Photo PNG
        /// </summary>
        public IFormFile Photo { get; set; }
        /// <summary>
        /// Birthday Owner
        /// </summary>
        /// <example>2000-12-01</example>
        public DateTime? Birthday { get; set; }
        /// <summary>
        /// Validate model
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errores = new List<ValidationResult>();
            var ServiceOptions = (IOptions<Global>)validationContext.GetService(typeof(IOptions<Global>));
 
            if (Photo != null)
            {
                if (Photo.Length > ServiceOptions.Value.MaxImageSizeProperty)
                {
                    errores.Add(new ValidationResult(ErrorMessage.MaxFileSize));
                }
                var Extension = Path.GetExtension(Photo.FileName);
                if (!ServiceOptions.Value.ValidExtension.Contains(Extension?.ToUpper()))
                {
                    errores.Add(new ValidationResult("[" + Extension + "] " + ErrorMessage.BadFormat));
                }
                if (!Photo.IsImage(ServiceOptions.Value.MaxImageSizeProperty))
                {
                    errores.Add(new ValidationResult(ErrorMessage.IsImage));
                }
            }
            return errores;
        
        }
    }
}