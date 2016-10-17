using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.Entities
{
    //Blocks that can contain other elements (e.g. a coin or powerup) will implement this interface
    public interface IContainer
    {
        void addHiddenItem();
        IContainable popHiddenItem();

    }
}
