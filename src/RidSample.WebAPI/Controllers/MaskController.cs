using Microsoft.AspNetCore.Mvc;
using RidSample.BL.Service.BL.Interfaces;

namespace RidSample.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MaskController : ControllerBase
{
    private readonly IMaskService _maskService;

    public MaskController(IMaskService maskService)
    {
        this._maskService = maskService;
    }

    [HttpPost]
    [Route("MaskNameByStringLength")]
    public string MaskNameFail(string name)
    {
        return this._maskService.MaskNameFail(name);
    }

    [HttpPost]
    [Route("MaskNameByRune")]
    public string MaskNameByRune(string name)
    {
        return this._maskService.MaskNameByRune(name);
    }

    [HttpPost]
    [Route("MaskNameByChar")]
    public string MaskNameByChar(string name)
    {
        return this._maskService.MaskNameByChar(name);
    }
}