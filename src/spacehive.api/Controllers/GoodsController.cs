namespace spacehive.api.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using spacehive.domain;
using spacehive.interfaces;

[ApiController]
[Route("[controller]")]
public class GoodsController : ControllerBase
{
    private readonly ILogger<GoodsController> _logger;
    private readonly IGoodsService _service;

    public GoodsController(
        ILogger<GoodsController> logger,
        IGoodsService service)
    {
        _logger = logger;
        _service = service;
    }

    [HttpGet]
    public GetGoodsResponse Get(string selectedCurrency)
    {
        var request = new GetGoodsRequest()
        {
            SelectedCurrency = selectedCurrency
        };

        return new GetGoodsResponse(){
            Goods = _service.GetAllGoods(request)
        };
    }
}
