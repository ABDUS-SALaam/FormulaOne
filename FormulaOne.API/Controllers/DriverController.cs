using AutoMapper;
using FormulaOne.API.Command;
using FormulaOne.API.Queries;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Request;
using FormulaOne.Entities.Dtos.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FormulaOne.API.Controllers
{
    public class DriverController : BaseController
    {
        private readonly IMediator _mediator;
        public DriverController(IUnitOfWork unitOfWork, IMapper mapper, IMediator mediator) : base(unitOfWork, mapper)
        {
            _mediator=mediator;
        }
        [HttpGet]
        [Route("{driverId:Guid}")]
        public async Task<IActionResult> GetDriver(Guid driverId)
        {
            /*var driver = await _unitOfWork.DriverRepository.GetById(driverId);
            if (driver == null)
                return NotFound();
            var result = _mapper.Map<GetDriverResponse>(driver);

            return Ok(result);*/
            var query = new GetDriverQuery(driverId);
            var result = await _mediator.Send(query);
            return result == null ? NotFound() : Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDrivers()
        {
           /* var drivers = await _unitOfWork.DriverRepository.All();
            if (drivers == null)
                return NotFound();
            var result = _mapper.Map<IEnumerable<GetDriverResponse>>(drivers);

            return Ok(result);*/
           var query =new GetAllDriversQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("")]
        public async Task<IActionResult> AddDriver([FromBody]CreateDriverRequest driver )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
           /* var result = _mapper.Map<Driver>(driver);
            await _unitOfWork.DriverRepository.Add(result);
            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetDriver),new { driverId=result.Id},result);*/

            var command =new CreateDriverCommand(driver);
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetDriver), new { driverId = result.DriverId }, result);
        }

        [HttpPut("")]
        public async Task<IActionResult> updateDriver([FromBody] UpdateDriverRequest driver)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var result = _mapper.Map<Driver>(driver);
            await _unitOfWork.DriverRepository.Update(result);
            await _unitOfWork.CompleteAsync();
            return NoContent();
        }

        [HttpDelete]
        [Route("{driverId:Guid}")]
        public async Task<IActionResult> DeleteDriver(Guid driverId) {
            var matchedResult= await _unitOfWork.DriverRepository.GetById(driverId);
            if (matchedResult == null)
                return NotFound();
            await _unitOfWork.DriverRepository.Delete(driverId);
            await _unitOfWork.CompleteAsync();

            return NoContent();

        }
    }
}
