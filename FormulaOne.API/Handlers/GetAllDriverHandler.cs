using AutoMapper;
using FormulaOne.API.Queries;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.Dtos.Response;
using MediatR;

namespace FormulaOne.API.Handlers
{
    public class GetAllDriverHandler : IRequestHandler<GetAllDriversQuery, IEnumerable<GetDriverResponse>>
    {

        protected readonly IUnitOfWork _unitOfWork;

        protected readonly IMapper _mapper;
        public GetAllDriverHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetDriverResponse>> Handle(GetAllDriversQuery request, CancellationToken cancellationToken)
        {
            var drivers = await _unitOfWork.DriverRepository.All();
            var driverResult = _mapper.Map<IEnumerable<GetDriverResponse>>(drivers);
            return driverResult;
        }
    }
}
