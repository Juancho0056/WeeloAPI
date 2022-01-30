
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

namespace WeeloApi.Application.Features.PropertyImages.Commands.CreateImage
{
    public class CreatePropertyImageRequest : CommandRequest<PropertyImageDto>, IValidatableObject
    {
        public int IdProperty { get; set; }
        public IFormFile File { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            
            List<ValidationResult> errores = new();
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
                    errores.Add(new ValidationResult("["+ Extension +"] "+ErrorMessage.BadFormat));
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
