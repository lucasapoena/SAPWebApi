using Api.Temp;
using Application.Extensions;
using Dbosoft.YaNco;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SAPWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompanyController : ControllerBase
    {
        private readonly IRfcContext _rfcContext;


        public CompanyController(IRfcContext rfcContext)
        {
            _rfcContext = rfcContext;
        }

        [HttpGet]
        public Task<IActionResult> GetAll()
        {

            return _rfcContext.GetCompanies()
                    .ToActionResult();
        }
    }
}
