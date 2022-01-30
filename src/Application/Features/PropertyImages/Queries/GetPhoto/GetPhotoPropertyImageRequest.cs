
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using WeeloApi.Application.Common.Abstracts;
using WeeloApi.Application.Common.Exceptions;
using WeeloApi.Application.Common.Interfaces;
using WeeloApi.Application.Common.Utils;

namespace WeeloApi.Application.Features.PropertyImages.Queries.GetPhoto
{
    /// <summary>
    /// GetPhotoPropertyImageRequest
    /// </summary>
    public class GetPhotoPropertyImageRequest : QueryRequest<FileStream>, IValidatableObject
    {
        /// <summary>
        /// Identification Property Image
        /// </summary>
        /// <example>1</example>
        public int IdPropertyImage { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errores = new List<ValidationResult>();
            var _context = (IApplicationDbContext)validationContext.GetService(typeof(IApplicationDbContext));
            var ServiceOptions = (IOptions<Global>)validationContext.GetService(typeof(IOptions<Global>));
            try
            {
                var propertyImage = _context.PropertyImages.
                  AsNoTracking().
                  Where(x => x.IdPropertyImage == IdPropertyImage).FirstOrDefault();

                if (propertyImage is null)
                {
                    errores.Add(new ValidationResult(ErrorMessage.NotFound("PropertyImage"), new[] { "PropertyImageId" }));
                    return errores;
                }

                return errores;
            }
            catch (Exception e)
            {
                errores.Add(new ValidationResult(e.Message));
                return errores;
            }
        }
    }
}