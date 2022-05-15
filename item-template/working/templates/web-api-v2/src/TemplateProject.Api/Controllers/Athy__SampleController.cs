using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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
    [Athy__SwaggerResponse]
    public async Task<ActionResult<Athy__ReturnTypeName>> Athy__EndpointMethodName(Athy__EndpointSignature athy__EndpointSignatureParam)
    {
        return Athy__ReturnExpression;
    }
}