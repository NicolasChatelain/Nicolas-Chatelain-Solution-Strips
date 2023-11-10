using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StripsBL.Exceptions;
using StripsBL.Managers;
using StripsBL.Model;
using StripsREST.Mapper;

namespace StripsREST.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class StripsController : ControllerBase
    {
        private StripsManager stripsManager;
        private string url = "http://localhost:5044/api/Strips/beheer";

        public StripsController(StripsManager stripsManager)
        {
            this.stripsManager = stripsManager;
        }

        [HttpGet]
        [Route("beheer/reeks/{Id}")]
        public ActionResult<Reeks> GetReeksOnID(int Id)
        {
            try
            {
                Reeks r = stripsManager.GetReeksOnID(Id);

                if (r is null)
                {
                    return NotFound();
                }

                return Ok(MapReeks.MapFromDomain(url, r, Id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
