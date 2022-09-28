using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using Microsoft.AspNetCore.Mvc;
using RidSample.BL.Service.BE;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace RidSample.WebAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class JsonSerializeController : ControllerBase
{
    [HttpPost]
    [Route("UseCjkRange")]
    public async Task<string> UseCjkRange(StringRequestEntity entity)
    {
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.CjkUnifiedIdeographs)
        };
        return JsonSerializer.Serialize(entity.Value, options);
    }   
    
    [HttpPost]
    [Route("UseUnicodeAll")]
    public async Task<string> UseUnicodeAll(StringRequestEntity entity)
    {
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.Create(UnicodeRanges.All)
        };
        return JsonSerializer.Serialize(entity.Value, options);
    }
}