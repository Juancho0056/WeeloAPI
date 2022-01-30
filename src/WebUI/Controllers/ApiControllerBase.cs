using WeeloApi.Application.Common.Interfaces;
using WeeloApi.Application.Common.Models;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using System;
using System.IO;

namespace WeeloApi.WebUI.Controllers
{
    /// <summary>
    /// ApiControllerBase
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
        private MediatR.ISender _mediator;
        private IConfiguration _configuration;
        private IWebHostEnvironment _environment;
        private IApplicationDbContext _context;
       
        /// <summary>
        /// 
        /// </summary>
        protected MediatR.ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<MediatR.ISender>();
        /// <summary>
        /// 
        /// </summary>
        protected IApplicationDbContext Context => _context ??= HttpContext.RequestServices.GetService<IApplicationDbContext>();
        /// <summary>
        /// 
        /// </summary>
        protected IConfiguration Configuration => _configuration ??= HttpContext.RequestServices.GetService<IConfiguration>();
        /// <summary>
        /// 
        /// </summary>
        protected IWebHostEnvironment Env => _environment ??= HttpContext.RequestServices.GetService<IWebHostEnvironment>();

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="Request"></typeparam>
        /// <typeparam name="Response"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        protected virtual async Task<ActionResult> Command<Request, Response>(Request command) where Request : IRequest<CommandResult<Response>>
        {
            //TryValidateModel(command);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
           
            var result = await Mediator.Send(command);
            if (result.Success)
                return Ok(result.Data);
            else
                throw new Exception(result.Error);




        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="Request"></typeparam>
        /// <typeparam name="Response"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        protected virtual async Task<ActionResult> QueryImage<Request, Response>(Request command) where Request : IRequest<QueryResult<Response>> where Response : FileStream
        {
            //TryValidateModel(command);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await Mediator.Send(command);
            if (result.Success) 
                return File(result.Data, "image/png");
            else
                throw new Exception(result.Error);

        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="Request"></typeparam>
        /// <typeparam name="Response"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        protected virtual async Task<ActionResult> Query<Request, Response>(Request command) where Request : IRequest<QueryResult<Response>>
        {
            //TryValidateModel(command);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await Mediator.Send(command);

            if (result.Success)  
                return Ok(result.Data); 
            else
                throw new Exception(result.Error);




        }

    }
}