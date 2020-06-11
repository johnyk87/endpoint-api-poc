namespace API.Endpoints.Values
{
    using API.Attributes;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [ApiRoute("values")]
    [ApiExplorerSettings(GroupName = "Values")]
    public abstract class ValuesEndpoint : ControllerBase
    {
    }
}
