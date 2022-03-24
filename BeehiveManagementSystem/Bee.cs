using System;
using System.Collections.Generic;
using System.Text;

namespace BeehiveManagementSystem
{
    abstract class Bee
    {
        public abstract float CostPerShift { get; } 

        public string Job { get; private set; } // read only property

        public Bee (string job) // not sure where this works in the Queen class...gonna figure it out someday
        {
            Job = job;
        }

        public void WorkTheNextShift()
        {
            if (HoneyVault.ConsumeHoney(CostPerShift)) // if the this returns false (see ConsumeHoney method in HoneyVault class), then nothing happens
            {
                DoJob();
            }
        }

        protected abstract void DoJob(); 

    }
}
