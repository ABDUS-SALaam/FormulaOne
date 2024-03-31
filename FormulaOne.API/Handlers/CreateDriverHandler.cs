using AutoMapper;
using FormulaOne.API.Command;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.DbSet;
using FormulaOne.Entities.Dtos.Response;
using MediatR;

namespace FormulaOne.API.Handlers
{
    public class CreateDriverHandler : IRequestHandler<CreateDriverCommand, GetDriverResponse>
    {

        protected readonly IUnitOfWork _unitOfWork;

        protected readonly IMapper _mapper;
        public CreateDriverHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetDriverResponse> Handle(CreateDriverCommand request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<Driver>(request.DriverRequest);

            await _unitOfWork.DriverRepository.Add(result);
            await _unitOfWork.CompleteAsync();

            var driverResult = _mapper.Map<GetDriverResponse>(result);
            return driverResult;
        }
    }
}
