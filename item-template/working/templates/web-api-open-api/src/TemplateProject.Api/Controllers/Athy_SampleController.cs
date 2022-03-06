using Microsoft.AspNetCore.Mvc;

namespace TemplateProject.Api.Controllers;

[ApiController]
[Route("Athy_ControllerRoute")]
[Produces("Athy_ContentType")]
public class Athy_SampleController : ControllerBase
{
    private readonly ILogger<Athy_SampleController> _logger;

    public Athy_SampleController(ILogger<Athy_SampleController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Athy_EndpointDescription
    /// </summary>
    /// <param name="Athy_EndpointRoute"></param>
    /// <returns></returns>
    [HttpGet("Athy_EndpointRoute")]
    [ProducesResponseType(typeof(Athy_ReturnTypeName), (200), "Athy_ContentType")]
    public async Task<ActionResult<Athy_ReturnTypeName>> Athy_HttpGetMethodName([FromHeader] string Athy_HeaderParam, [FromPath] string Athy_PathParam, [FromQuery] string Athy_QueryStringParam)
    {
        return Ok(new Athy_ReturnTypeName());
    }

    /// <summary>
    /// Athy_EndpointDescription
    /// </summary>
    /// <param name="Athy_EndpointRoute"></param>
    /// <returns></returns>
    [HttpPost("Athy_EndpointRoute")]
    [ProducesResponseType(typeof(Athy_ReturnTypeName), (200), "Athy_ContentType")]
    public async Task<ActionResult<Athy_ReturnTypeName>> Athy_HttpPostMethodName([FromHeader] string Athy_HeaderParam, [FromPath] string Athy_PathParam, [FromBody] Athy_RequestBodyTypeName Athy_BodyParam)
    {
        return Ok(new Athy_ReturnTypeName());
    }
}
