using Microsoft.AspNetCore.Mvc;

namespace Api.Controller.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    [HttpPost(Name = "Inquiry")]
    public ActionResult Inquiry()
    {
        return Ok("dddddddddddddddd");
    }
}
