using AutoMapper;
using Loge.Application.Contracts;
using Loge.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Loge.WebApi.Controllers;

// [Authorize]
[Route("api/[controller]")]
[ApiController]
public class TransportOrdersController : ControllerBase
{
    private readonly ITransportOrderService _transportOrderService;

    private readonly IMapper _mapper;

    public TransportOrdersController(ITransportOrderService transportOrderService, IMapper mapper)
    {
        _transportOrderService = transportOrderService;
        _mapper = mapper;
    }

    /// <summary>
    /// Get the historical list of transport orders 
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    public async Task<IActionResult> GetTransportOrdersList()
    {
        var transportOrders = await _transportOrderService.GetAll();

        return Ok(transportOrders);
    }

    /// <summary>
    /// Get transport order by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var transportOrder = await _transportOrderService.GetById(id);

        if (transportOrder != null)
        {
            return Ok(_mapper.Map<TransportOrderDto>(transportOrder));
        }

        return NotFound();
    }

    /// <summary>
    /// Create a new transport order.
    /// </summary>
    /// <param name="request">The TransportOrder to be created.</param>
    /// <returns>Boolean representing if the TransportOrder was created or not.</returns>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TransportOrderDto request)
    {
        var isCreated = await _transportOrderService.Create(request);

        if (isCreated)
        {
            return Created();
        }

        return BadRequest();
    }

    /// <summary>
    /// Update the transport order
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] TransportOrderDto request)
    {
        if (request != null)
        {
            var isUpdated = await _transportOrderService.Update(request);

            if (isUpdated)
            {
                return Ok(isUpdated);
            }
        }

        return BadRequest();
    }

    /// <summary>
    /// Delete transport order by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var isDeleted = await _transportOrderService.Delete(id);

        if (isDeleted)
        {
            return Ok(isDeleted);
        }

        return BadRequest();
    }
}