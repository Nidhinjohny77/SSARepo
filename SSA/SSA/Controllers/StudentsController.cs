using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SSA.Controllers
{
    [Authorize(Policy =GlobalConstant.StudentCreatorPolicy)]
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMapper mapper;

        public StudentsController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StudentModel student=null)
        {
            student.UID = 34875638476;
            return Ok(student);
        }
    }
}
