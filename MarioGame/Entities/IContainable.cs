using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.Entities
{
    //Items (e.g. a coin or powerup, that are contained by other elementsp (e.g. a block)) implement this interface
    public interface IContainable
    {
        void leaveContainer(); // should give the Containable object a different location (e.g. one block immediately above) and/or velocity than its container object).
    }
}
