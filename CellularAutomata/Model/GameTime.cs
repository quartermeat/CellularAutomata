using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellularAutomata.Model
{
    class GameTime
    {
        private int _ticksInHour;
        private int _hours;
        private int _days;
        private int _years;
        private int _scale;

        public GameTime()
        {
            _ticksInHour = 120;
            _scale = 1;//the higher the number, the faster time goes by
            _hours = 0;
            _days = 0;
            _years = 0;
        }
        
    }
}
