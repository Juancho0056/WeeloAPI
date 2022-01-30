
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

namespace WeeloApi.Application.Features.Owners.Queries.Get
{
    /// <summary>
    /// GetPhotoOwnerRequest
    /// </summary>
    public class GetPhotoOwnerRequest : QueryRequest<FileStream>, IValidatableObject
    {
        /// <summary>
        /// Identification Owner
        /// </summary>
        /// <example>1</example>
        public int IdOwner { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errores = new List<ValidationResult>();
            var _context = (IApplicationDbContext)validationContext.GetService(typeof(IApplicationDbContext));
            var ServiceOptions = (IOptions<Global>)validationContext.GetService(typeof(IOptions<Global>));
            try
            {
                var owner = _context.Owners.
                  AsNoTracking().
                  Where(x => x.IdOwner == IdOwner).FirstOrDefault();

                if (owner is null)
                {
                    errores.Add(new ValidationResult(ErrorMessage.NotFound("Owner"), new[] { "OwnerId" }));
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