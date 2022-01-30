
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WeeloApi.Application.Features.Propertys.Commands.Create;
using WeeloApi.Application.Features.Propertys;
using WeeloApi.Application.Features.Propertys.Commands.Delete;
using MediatR;
using WeeloApi.Application.Features.Propertys.Queries.Get;
using WeeloApi.Application.Features.Propertys.Commands.Update;
using WeeloApi.Application.Common.Models;
using WeeloApi.Application.Features.Propertys.Queries.GetAll;
using Microsoft.AspNetCore.Authorization;
using WeeloApi.Application.Features.PropertyImages.Commands.CreateImage;
using WeeloApi.Application.Features.PropertyImages;

namespace WeeloApi.WebUI.Controllers.v1
{
    /// <summary>
    /// Controlador para realizar operaciones basicas CRUD sobre los datos almacenados para las propiedades
    /// </summary>
    [Authorize]
    public class PropertyController : ApiControllerBase
    {

        /// <summary>
        /// Consultar propiedad por el identificador IdProperty
        /// </summary>
        /// <remarks>
        /// Obtiene los registros para una propiedad de acuerdo al <code>IdOwner</code> entregado con la clase <code>GetPropertyRequest</code>
        ///
        /// Se realiza el consumo con un <code>Http GET</code>
        /// 
        /// Ejemplo de consumo:
        ///
        ///     GET /api/Property/Get?IdProperty=1
        /// </remarks>
        /// <param name="request">Identification to get Property</param>
        /// <returns>PropertyDto</returns>
        [ProducesResponseType(typeof(PropertyDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [HttpGet("[action]")]
        public async Task<IActionResult> Get([FromQuery] GetPropertyRequest request)
        {
            return await base.Query<GetPropertyRequest, PropertyDto>(request);
        }
        /// <summary>
        /// Consultar propiedad
        /// </summary>
        /// <remarks>
        /// Obtiene los registros para una propiedad de acuerdo a los filtros entregados con la clase <code>GetAllPropertyRequest</code>
        /// 
        /// Ejemplo de consumo:
        ///
        ///     GET /api/Owner/GetAll?IdProperty=1&amp;Name=JUAN&amp;Address=TORRE&amp;PageNumber=1&amp;PageSize=10
        /// </remarks>
        /// <param name="request">Filtro para obtener los datos</param>
        /// <response code="200">Retorna los datos para el filtro entregado</response>
        [ProducesResponseType(typeof(PaginatedList<PropertyDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesDefaultResponseType]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] GetAllPropertyRequest request)
        {
            return await base.Query<GetAllPropertyRequest, PaginatedList<PropertyDto>>(request);
        }


        /// <summary>
        /// Crear propiedad
        /// </summary>
        /// <remarks>
        /// Crea un nuevo registro para una propiedad segun los datos entregados
        /// 
        /// Ejemplo consumo:
        ///
        ///     POST "/api/Property/Create" 
        ///     {
        ///         "Name": "Torreon",
        ///         "Address": "CRA 9 No 27 - 09 IBAGUE",
        ///         "Year":"2021",
        ///         "IdOwner":"1"
        ///     }
        /// </remarks>
        /// <param name="command">Data to create new Property</param>
        /// <returns>PropertyDto</returns>
        // POST: api/Property/Create
        [ProducesResponseType(typeof(PropertyDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [HttpPost("[action]")]
        public async Task<ActionResult> Create([FromBody] CreatePropertyRequest command)
        {
            return await base.Command<CreatePropertyRequest, PropertyDto>(command);
        }

        /// <summary>
        /// Agregar imagen a propiedad
        /// </summary>
        /// <remarks>
        /// Permite crear un registro para agregar una imagen a una propiedad
        /// 
        /// Ejemplo consumo:
        ///
        ///     POST "/api/Property/CreateImage" 
        ///     requestBody:
        ///         required: true
        ///         content:
        ///         multipart/form-data:
        ///     -Header  "Content-Type: multipart/form-data" -F "IdPropertyImage=1" -F "IdProperty=2" -F "Photo=@ínvitacionICX.png;type=image/png"
        /// </remarks>
        /// <param name="command">Data to create new PropertyImage</param>
        /// <returns>PropertyImageDto</returns>
        // POST: api/Owner/CreateImage
        [ProducesResponseType(typeof(PropertyImageDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [HttpPost("[action]")]
        public async Task<ActionResult> CreateImage([FromForm] CreatePropertyImageRequest command)
        {
            return await base.Command<CreatePropertyImageRequest, PropertyImageDto>(command);
        }
        /// <summary>
        /// Actualizar propiedad
        /// </summary>
        /// <remarks>
        /// Permite actualizar los datos de una propiedad segun su codigo identificador
        /// 
        /// Ejemplo consumo:
        ///
        ///     PATCH "/api/Property/Update" 
        ///     {
        ///         "IdProperty":"1"
        ///         "Name": "Torreon",
        ///         "Address": "CRA 9 No 27 - 09 IBAGUE",
        ///         "Price":"1000000",
        ///         "Year":"2021",
        ///         "IdOwner":"1"
        ///     }
        /// </remarks>
        /// <param name="command">Instance for UpdatePropertyRequest</param>
        // PATCH: api/Property/Update
        [ProducesResponseType(typeof(PropertyDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [HttpPatch("[action]")]
        public async Task<ActionResult> Update([FromBody] UpdatePropertyRequest command)
        {
            return await base.Command<UpdatePropertyRequest, PropertyDto>(command);
        }


        /// <summary>
        /// Actualizar precio propiedad
        /// </summary>
        /// <remarks>
        /// Permite actualizar el precio de una propiedad y genera un nuevo registro para PropertyTrace
        /// 
        /// Ejemplo consumo:
        ///
        ///     PATCH "/api/Property/Update" 
        ///     {
        ///         "IdProperty":"1"
        ///         "Price":"1000000"
        ///     }
        /// </remarks>
        /// <param name="command">Instance for UpdatePropertyRequest</param>
        // PATCH: api/Property/ChangePrice
        [ProducesResponseType(typeof(PropertyDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [HttpPatch("[action]")]
        public async Task<ActionResult> ChangePrice([FromBody] ChangePriceRequest command)
        {
            return await base.Command<ChangePriceRequest, PropertyDto>(command);
        }
        /// <summary>
        /// Eliminar propiedad
        /// </summary>
        /// <remarks>
        /// Elimina un registro especifico para una propiedad
        /// 
        /// Ejemplo consumo:
        ///
        ///         DELETE /api/Property/Delete?IdProperty=1
        /// </remarks>
        /// <param name="command">Instance for DeletePropertyRequest</param>
        /// <returns></returns>
        // DELETE: api/Property/Delete
        [ProducesResponseType(typeof(Unit), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        [HttpDelete("[action]")]
        public async Task<ActionResult> Delete([FromQuery] DeletePropertyRequest command)
        {
            return await base.Command<DeletePropertyRequest, Unit>(command);
        }

    }
}
