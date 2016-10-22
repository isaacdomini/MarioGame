using MarioGame.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MarioGame.Entities.Entity;

namespace MarioGame.Entities
{
    public interface ICollidable
    {
        void onCollide(IEntity otherObject, Sides otherObjectsSide);
    }
}
