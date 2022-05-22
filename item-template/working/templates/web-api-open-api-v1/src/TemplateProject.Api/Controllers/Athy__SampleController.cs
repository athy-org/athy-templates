using Microsoft.AspNetCore.Mvc;
using TemplateProject.Domain.Abstractions;

namespace TemplateProject.Api.Controllers;

[ApiController]
[Route("Athy__ControllerRoute")]
[Produces("Athy__ContentType")]
public class Athy__SampleController : ControllerBase
{
    private readonly ILogger<Athy__SampleController> _logger;

    public Athy__SampleController(ILogger<Athy__SampleController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Athy__EndpointDescription
    /// </summary>
    /// <param name="Athy__EndpointRoute"></param>
    /// <returns></returns>
    [Athy__HttpMethod("Athy__EndpointRoute")]
    [ProducesResponseType(typeof(Athy__ReturnTypeName), (200), "Athy__ContentType")]
    public async Task<ActionResult<Athy__ReturnTypeName>> Athy__HttpGetMethodName([FromHeader] string Athy__HeaderParam, [FromPath] string Athy__PathParam, [FromQuery] string Athy__QueryStringParam)
    {
        return Ok(new Athy__ReturnTypeName());
    }
}