using Microsoft.AspNetCore.Mvc;

namespace Loge.WebApi;

public class TransportOrderController : Controller
{
    // GET
    public IActionResult GetAll()
    {
        return Ok();
    }
}