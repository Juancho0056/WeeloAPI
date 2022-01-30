
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeeloApi.Application.Features.Owners.Commands.Create;
using WeeloApi.Application.Features.Owners;
using WeeloApi.Application.Features.Owners.Commands.Delete;
using MediatR;
using System.IO;
using WeeloApi.Application.Features.Owners.Queries.Get;
using WeeloApi.Application.Features.Owners.Commands.Update;
using WeeloApi.Application.Common.Models;
using WeeloApi.Application.Features.Owners.Queries.GetAll;
using Microsoft.AspNetCore.Authorization;

namespace WeeloApi.WebUI.Controllers.v1
{
    /// <summary>
    /// Controlador para realizar operaciones basicas CRUD sobre los datos almacenados para los propietarios
    /// </summary>
    [Authorize]
    public class OwnerController : ApiControllerBase
    {
        /// <summary>
        /// Consultar Propietario por el identificador IdOwner
        /// </summary>
        /// <remarks>
        /// Obtiene los registros para un propietario de acuerdo al <code>IdOwner</code> entregado con la clase <code>GetOwnerRequest</code>
        ///
        /// Se realiza el consumo con un <code>Http GET</code>
        /// 
        /// Ejemplo de consumo:
        ///
        ///     GET /api/Owner/Get?IdOwner=1
        /// </remarks>
        /// <param name="request">Identification to get Owner</param>
        /// <returns>OwnerDto</returns>
        [ProducesResponseType(typeof(OwnerDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [HttpGet("[action]")]
        public async Task<IActionResult> Get([FromQuery] GetOwnerRequest request)
        {
            return await base.Query<GetOwnerRequest, OwnerDto>(request);
        }
        /// <summary>
        /// Consultar propietarios
        /// </summary>
        /// <remarks>
        /// Obtiene los registros para un propietario de acuerdo a los filtros entregados con la clase <code>GetAllOwnerRequest</code>
        /// 
        /// Ejemplo de consumo:
        ///
        ///     GET /api/Owner/GetAll?IdOwner=1&amp;Name=JUAN&amp;Address=TORRE&amp;PageNumber=1&amp;PageSize=10
        /// </remarks>
        /// <param name="request">Filtro para obtener los datos</param>
        /// <response code="200">Retorna los datos para el filtro entregado</response>
        [ProducesResponseType(typeof(PaginatedList<OwnerDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllOwnerRequest request)
        {
            return await base.Query<GetAllOwnerRequest, PaginatedList<OwnerDto>>(request);
        }

        /// <summary>
        /// Consultar foto de propietario
        /// </summary>
        /// <remarks>
        /// Ejemplo de consumo:
        ///
        ///     GET /api/Owner/GetPhoto?IdOwner=1
        /// </remarks>
        /// <response code="200">Retorna un FileStream con la imagen del propietario</response>
        // GET: api/Owner/GetPhoto
        [ProducesResponseType(typeof(FileStream), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetPhoto([FromQuery] GetPhotoOwnerRequest request)
        {
            return await base.QueryImage<GetPhotoOwnerRequest, FileStream>(request);
        }
        /// <summary>
        /// Crear propietario
        /// </summary>
        /// <remarks>
        /// Crea un nuevo registro para un propietario segun los datos entregados
        /// 
        /// Ejemplo de consumo:
        ///
        ///     POST "/api/Owner/Create" 
        ///     requestBody:
        ///         required: true
        ///         content:
        ///         multipart/form-data:
        ///     -Header  "Content-Type: multipart/form-data" -F "Name=JUAN CARLOS CARDONA" -F "Address=CRA 9 No 27 - 09 IBAGUE" -F "Birthday=2000-12-01T00:00:00.0000000" -F "Photo=@ínvitacionICX.png;type=image/png"
        /// </remarks>
        /// <param name="command">Campos necesarios para crear el propietario</param>
        /// <returns>OwnerDto</returns>
        [ProducesResponseType(typeof(OwnerDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [HttpPost("[action]")]
        public async Task<ActionResult> Create([FromForm] CreateOwnerRequest command)
        {
            return await base.Command<CreateOwnerRequest, OwnerDto>(command);
        }

        /// <summary>
        /// Actualizar propietario
        /// </summary>
        /// <remarks>
        /// Permite actualizar los datos de un propietario segun su codigo identificador
        /// 
        /// Sample request:
        ///
        ///     POST "/api/Owner/Update" -Header  "Content-Type: multipart/form-data" -F "IdOwner=1" -F "Name=JUAN CARLOS CARDONA" -F "Address=CRA 9 No 27 - 09 IBAGUE" -F "Birthday=2000-12-01T00:00:00.0000000" -F "Photo=@ínvitacionICX.png;type=image/png"
        /// </remarks>
        /// <param name="command">Instance for UpdateOwnerRequest</param>
        // PATCH: api/Owner/Update
        [ProducesResponseType(typeof(OwnerDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [HttpPatch("[action]")]
        public async Task<ActionResult> Update([FromForm] UpdateOwnerRequest command)
        {
            return await base.Command<UpdateOwnerRequest, OwnerDto>(command);
        }

        /// <summary>
        /// Eliminar propietario
        /// </summary>
        /// <remarks>
        /// Elimina un registro especifico para un propietario
        /// 
        /// Ejemplo de consumo:
        ///
        ///         DELETE /api/Owner/Delete?IdOwner=1
        /// </remarks>
        /// <param name="command">Instance for DeleteOwnerRequest</param>
        /// <returns></returns>
        [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [HttpDelete("[action]")]
        public async Task<ActionResult> Delete([FromQuery] DeleteOwnerRequest command)
        {
            return await base.Command<DeleteOwnerRequest, Unit>(command);
        }
    }
}
