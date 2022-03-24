using System;
using System.Collections.Generic;
using System.Text;

namespace BeehiveManagementSystem
{
    class Bee
    {
        public virtual float CostPerShift { get; } // virtual allows this property to be overridden by derived classes 

        public string Job { get; private set; } // read only property

        public Bee (string job)
        {
            Job = job;
        }

        public void WorkTheNextShift()
        {
            if (HoneyVault.ConsumeHoney(CostPerShift))
            {
                DoJob();
            }
        }

        protected virtual void DoJob() { } // virtual allows this method to be overridden by derived classes

    }
}
