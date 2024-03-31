using FormulaOne.Entities.Dtos.Response;
using MediatR;

namespace FormulaOne.API.Queries
{
    public class GetAllDriversQuery:IRequest<IEnumerable<GetDriverResponse>>
    {
    }
}
