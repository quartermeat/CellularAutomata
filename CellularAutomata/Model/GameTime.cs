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

        //calculate time
        public int ChangeTimeBasedOnTimeCounter(int timerCounter)
        {
            //get hours from timerCounter
            _hours = timerCounter % _ticksInHour;
            //if hours gets to 24
            if (_hours == 24)
            {
                //reset timer counter
                timerCounter = 0;
                //increment days
                _days++;
                //if days gets to 365
                if (_days == 365)
                {
                    //increment years
                    _years++;
                    //reset days
                    _days = 0;
                }
            }
        }
    }
}
