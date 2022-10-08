using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Interanet.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppControllerBase : ControllerBase
    {
        //protected readonly string AddErrorMesaage = "Some Thing Wrong Happened while Adding";
        //protected readonly string UpdateErrorMesaage = "Some Thing Wrong Happened while Updating";
        //protected readonly string DeleteErrorMesaage = "Some Thing Wrong Happened while Deleteing";
        public AppControllerBase()
        {
           
        }
    }
}
