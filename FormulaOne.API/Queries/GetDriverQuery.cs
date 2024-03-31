using FormulaOne.Entities.Dtos.Response;
using MediatR;

namespace FormulaOne.API.Queries
{
    public class GetDriverQuery:IRequest<GetDriverResponse?>
    {
        public Guid DriverId { get; }

        public GetDriverQuery(Guid driverId)
        {
            DriverId = driverId;
        }
    }

}
