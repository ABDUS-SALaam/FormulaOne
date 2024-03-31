using FormulaOne.Entities.Dtos.Request;
using FormulaOne.Entities.Dtos.Response;
using MediatR;

namespace FormulaOne.API.Command
{
    public class CreateDriverCommand:IRequest<GetDriverResponse>
    {
        public CreateDriverRequest DriverRequest { get; }
        public CreateDriverCommand(CreateDriverRequest _driverRequest)
        {
            DriverRequest = _driverRequest;
        }
    }
}
