using AutoMapper;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Request;
using FormulaOne.Entities.Dtos.Response;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.API.Controllers
{
    public class AchievementsController
        : BaseController
    {
        public AchievementsController(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
        {

        }
        [HttpGet]
        [Route("{driverId:guid}")]
        public async Task<IActionResult> GetDriverAchievements(Guid driverId) {
            var driverachievements=await _unitOfWork.AchievementsRepository.GetDriverAchievementsAsync(driverId);
            if (driverachievements == null) return NotFound("Achievements not found");
            var result = _mapper.Map<DriverAchievementResponse>(driverachievements);
            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddAchievement([FromBody]CreateDriverAchievementsRequest achievement) {
            if (!ModelState.IsValid) {
                return BadRequest();
                    }
            var result = _mapper.Map<Achievement>(achievement);
            await _unitOfWork.AchievementsRepository.Add(result);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetDriverAchievements),new {driverId=result.Id},result);
        
        }

        [HttpPut("")]
        public async Task<IActionResult> UpdateAchievements([FromBody] UpdateDriverAchievementsRequest achievement) {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result= _mapper.Map<Achievement>(achievement);
            await _unitOfWork.AchievementsRepository.Update(result);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }
    }
}
