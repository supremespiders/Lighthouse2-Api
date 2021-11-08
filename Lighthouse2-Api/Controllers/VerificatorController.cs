using System;
using System.Threading.Tasks;
using Lighthouse2_Api.Models;
using Lighthouse2_Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Lighthouse2_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerificatorController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EbmInput input)
        {
            if (input?.Signature == null) return StatusCode(400, "input invalid");
            var client = new EbmClient();
            try
            {
                var output = await client.Work(input.Signature);
                return Ok(output);
            }
            catch (MyException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.ToString());
            }
        }
    }
}