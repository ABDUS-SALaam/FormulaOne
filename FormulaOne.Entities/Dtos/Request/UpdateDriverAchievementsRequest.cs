using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.Entities.Dtos.Request
{
    public class UpdateDriverAchievementsRequest
    {
        public Guid DriverId { get; set; }
        public int Wins { get; set; }

        public int PolePosition { get; set; }

        public int FastestLap { get; set; }

        public int WorldChampionship { get; set; }
    }
}
