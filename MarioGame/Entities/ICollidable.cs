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
        //side = the side of `this` that was hit by otherObject
        void OnCollide(IEntity otherObject, Sides side, Sides otherSide);
    }
}
