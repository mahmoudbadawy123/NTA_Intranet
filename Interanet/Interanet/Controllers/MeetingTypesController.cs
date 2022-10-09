using AutoMapper;
using Interanet.Business.Interfaces;
using Interanet.Model.View.LookUps;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Interanet.API.Controllers
{

    public class MeetingTypesController : AppControllerBase
    {
        private readonly IMeetingTypesService _MeetingTypesService;
        private readonly IMapper _mapper;
        public MeetingTypesController(IMeetingTypesService MeetingTypesService, IMapper mapper)
        {
            _MeetingTypesService = MeetingTypesService;
            _mapper = mapper;

        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllMeetingTypes()
        {
            try
            {
                var Data = _MeetingTypesService.GetAllMeetingTypes().Result;
                var DataMapped = _mapper.Map<List<VmMeetingTypes>>(Data);
                return Ok(DataMapped);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException);
            }
        }


    }
}
