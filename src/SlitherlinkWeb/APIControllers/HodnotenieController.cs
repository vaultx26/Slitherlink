using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Slitherlink.SlitherlinkCore.SlitherlinkEntity;
using Slitherlink.SlitherlinkCore.SlitherlinkService.HodnotenieService;

namespace SlitherlinkWeb.APIControllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class HodnotenieController : ControllerBase
    {
        private readonly HodnotenieService _hodnotenieService = new HodnotenieServiceEF();
        [HttpGet]
        public IEnumerable<Hodnotenie> Get()
        {
            return _hodnotenieService.Get_hodnotenie();
        }
        [HttpPost]
        public void Post([FromBody] Hodnotenie hodnotenie)
        {
            _hodnotenieService.Add_hodnotenie(hodnotenie);
        }
    }
}
