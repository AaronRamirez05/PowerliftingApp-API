using Microsoft.AspNetCore.Mvc;
using Powerlifting.Service;
using Powerlifting.Service.Models;

namespace PowerLifter.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PowerliftingController : ControllerBase
    {
        private readonly ILogger<PowerliftingController> _logger;  //Used for keeping track of logs, can comprise of actions,errors, or data
        private readonly IServiceFunctions _service;

   

        public PowerliftingController(ILogger<PowerliftingController> logger, IServiceFunctions serviceFunctions)
        {
            _logger = logger;
            _service = serviceFunctions;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserPrograms()
        {
            var userPrograms = await _service.GetUserPrograms();
            if (userPrograms == null)
            {
                return NotFound();
            }
            return Ok(userPrograms);


        }

        [HttpGet("{userid}")]
        public async Task<IActionResult> GetUserPrograms(string userid)
        {
            var userPrograms = await _service.GetSpecificUserProgram(userid);
            if (userPrograms == null)
            {
                return NotFound();
            }
            return Ok(userPrograms);


        }

        [HttpGet("{userid}/{pname}/workouts")]
        public async Task<IActionResult> GetUserWorkouts(string userid, string pname)
        {
            var userPrograms = await _service.GetSpecificUserWorkouts(userid,pname);
            if (userPrograms == null)
            {
                return NotFound();
            }
            return Ok(userPrograms);


        }

        [HttpPost("user/create")]
        public async Task<IActionResult> CreateProgram([FromBody] UserXProgramId request)
        {
            var userPrograms = _service.InsertUserandProgram(request);
            if (userPrograms == null)
            {
                return NotFound();
            }
            return Ok(true);


        }

        [HttpPost("user/createWorkout")]
        public async Task<IActionResult> CreateWorkout([FromBody] WorkoutDetails request)
        {
            var userPrograms = _service.InsertWorkoutDetails(request);
            if (userPrograms == null)
            {
                return NotFound();
            }
            return Ok(true);

        }

        //Populates specific program page
        [HttpGet("/user/userprograms/lesson/{lessonPlan}")]
        public async Task<IActionResult> GetUserProgramDetails(int lessonPlan)
        {
            var userPrograms = await _service.GetSpecificProgramId(lessonPlan);
            return Ok(userPrograms);


        }

        //Populates the general programs
        [HttpGet("/user/userprograms/user/{userid}")]
        public async Task<IActionResult> GetUserProgramBasedOnGuid(string userid)
        {
            var userPrograms = await _service.GetSpecificUserProgram(userid);
            if (userPrograms == null)
            {
                return NotFound();
            }
            return Ok(userPrograms);


        }


    }
}