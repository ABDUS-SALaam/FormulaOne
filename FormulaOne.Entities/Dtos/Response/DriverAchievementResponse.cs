﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaOne.Entities.Dtos.Response
{
    public class DriverAchievementResponse
    {
        public int RaceWins { get; set; }

        public int PolePosition { get; set; }

        public int FastestLap { get; set; }

        public int WorldChampionship { get; set; }

        public Guid DriverId { get; set; }

        public Guid Id { get; set; }
    }
}
