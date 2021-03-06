﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace CellularAutomata.Model
{
    class GameTime : Timer
    {
        //timer only stuff
        private int _timerCounter;
        private readonly int _ticksInHour;
        private int _hours;
        private int _days;
        private int _years;
        private int _scale;
        
        //game state stuff
        public bool IsDayLight;
        public string TimeString;

        //timer tick event handler
        public event EventHandler TimerTicked;

        public GameTime() : base()
        {
            //setup timer
            _timerCounter = 0;
            _ticksInHour = 120;
            _scale = 1;//the higher the number, the faster time goes by
            _hours = 0;
            _days = 0;
            _years = 0;
            Interval = 1000/_scale;
            IsDayLight = false;
            Tick += TimerTick;
        }

        //do stuff on the timer tick
        private void TimerTick(object cvsender, EventArgs e)
        {
            //update counter
            _timerCounter++;
            //get hours from timerCounter
            _hours = _timerCounter%_ticksInHour;
            
            //handle daylight//////////////////////
            //if hours is divisible by 6
            if (_hours == 6 || _hours==18)
            {
                IsDayLight = IsDayLight == false;
            }
            /////////////////////////////////////

            //if hours gets to 24
            if (_hours == 24)
            {
                //reset timer counter
                _timerCounter = 0;
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

            //update timer label
            TimeString = _years + "y " + _days + "d " + _hours + "h";
            
            if (TimerTicked != null) TimerTicked(this, e);
        }

        //change speed of the game
        public void SetTimeScale(int timeScale)
        {
            _scale = timeScale;
            Interval = 1000 / _scale;
        }

    }
}
