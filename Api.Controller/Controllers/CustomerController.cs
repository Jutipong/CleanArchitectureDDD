using Application.Customer.Create;
using Application.Customer.Dapper;
using Application.Customer.Delete;
using Application.Customer.GetById;
using Application.Customer.Inquiry;
using Application.Customer.Update;

namespace Api.Controller.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpPost]
    [Route("Create")]
    public async Task<ActionResult> CreateAsync(CustomerCreateCommand req, CancellationToken token)
    {
        var result = await _sender.Send(req, token);
        return Ok(result);
    }

    [HttpPost]
    [Route("Update")]
    public async Task<ActionResult> UpdateAsync(CustomerUpdateCommand req, CancellationToken token)
    {
        var result = await _sender.Send(req, token);
        return Ok(result);
    }

    [HttpDelete]
    [Route("Delete")]
    public async Task<ActionResult> DeleteAsync(Guid id, CancellationToken token)
    {
        var result = await _sender.Send(new CustomerDeleteCommand(id), token);
        return Ok(result);
    }

    [HttpGet]
    [Route("GetById/{id}")]
    public async Task<ActionResult> GetByIdAsync(Guid id, CancellationToken token)
    {
        var result = await _sender.Send(new CustomerGetByIdQuery(id), token);
        return Ok(result);
    }

    [HttpPost]
    [Route("Inquiry")]
    public async Task<ActionResult> InquiryAsync(CustomerInquiryQuery req, CancellationToken token)
    {
        var result = await _sender.Send(req, token);
        return Ok(result);
    }

    [HttpPost]
    [Route("Demo_EfCore_Dapper")]
    public async Task<ActionResult> DemoEfCoreDapperAsync(CustomerDapperHandlerQuery req, CancellationToken token)
    {
        var result = await _sender.Send(req, token);
        return Ok(result);
    }
}
