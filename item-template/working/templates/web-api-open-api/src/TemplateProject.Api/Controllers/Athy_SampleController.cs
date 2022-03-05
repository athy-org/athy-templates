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

    [HttpGet(Name = "Athy_EndpointRoute")]
    [ProducesResponseType(typeof(Athy_ReturnTypeName), (200), "Athy_ContentType")]
    public async Task<ActionResult<Athy_ReturnTypeName>> Athy_HttpGetMethodName([FromPath] string Athy_PathParam, [FromQuery] string Athy_QueryStringParam)
    {
        return Ok(new Athy_ReturnTypeName());
    }
}
