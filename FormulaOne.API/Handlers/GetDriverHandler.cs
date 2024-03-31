using AutoMapper;
using FormulaOne.API.Queries;
using FormulaOne.DataService.Repositories.Interfaces;
using FormulaOne.Entities.Dtos.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace FormulaOne.API.Handlers
{
    public class GetDriverHandler : IRequestHandler<GetDriverQuery, GetDriverResponse>
    {

        protected readonly IUnitOfWork _unitOfWork;

        protected readonly IMapper _mapper;
        public GetDriverHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetDriverResponse?> Handle(GetDriverQuery request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.DriverRepository.GetById(request.DriverId);
            return result == null ? null : _mapper.Map<GetDriverResponse>(result);
        }
    }
}
