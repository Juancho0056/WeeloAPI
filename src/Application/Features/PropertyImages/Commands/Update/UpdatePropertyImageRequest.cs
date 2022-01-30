using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using WeeloApi.Application.Common.Abstracts;
using WeeloApi.Application.Common.Exceptions;
using WeeloApi.Application.Common.Extensions;
using WeeloApi.Application.Common.Interfaces;
using WeeloApi.Application.Common.Utils;
using WeeloApi.Application.Features.PropertyImages;

namespace WeeloApi.Application.Features.Owners.Commands.Update
{
    /// <summary>
    /// Data to update  record owner by IdOwner
    /// </summary>
    public class UpdatePropertyImageRequest : CommandRequest<PropertyImageDto>, IValidatableObject
    {
        /// <summary>
        /// Identification for Property Image
        /// </summary>
        /// <example>1</example>
        [Required(ErrorMessage = ErrorMessage.IsRequired)]
        public int IdPropertyImage { get; set; }
        /// <summary>
        /// Identification for Property
        /// </summary>
        /// <example>CRA 9 No 27 - 09 IBAGUE </example>
        [MaxLength(200, ErrorMessage = ErrorMessage.MaxLength + "200.")]
        public int? IdProperty { get; set; }
        /// <summary>
        /// File data to Photo PNG
        /// </summary>
        public IFormFile File { get; set; }
        /// <summary>
        /// Is Enabled
        /// </summary>
        /// <example>true</example>
        public bool? Enabled { get; set; }
        /// <summary>
        /// Validate model
        /// </summary>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errores = new List<ValidationResult>();
            var ServiceOptions = (IOptions<Global>)validationContext.GetService(typeof(IOptions<Global>));

          
        

            if (File != null)
            {
                //if (File.Length > ServiceOptions.Value.MaxImageSizeProperty)
                //{
                //    errores.Add(new ValidationResult(ErrorMessage.MaxFileSize));
                //}
                var Extension = Path.GetExtension(File.FileName);
                if (!ServiceOptions.Value.ValidExtension.Contains(Extension?.ToUpper()))
                {
                    errores.Add(new ValidationResult("[" + Extension + "] " + ErrorMessage.BadFormat));
                }
                if (!File.IsImage(ServiceOptions.Value.MaxImageSizeProperty))
                {
                    errores.Add(new ValidationResult(ErrorMessage.IsImage));
                }
            }
            return errores;
        
        }
    }
}