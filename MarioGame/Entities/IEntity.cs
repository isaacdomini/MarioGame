using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.States.PlayerStates;
using Microsoft.Xna.Framework;

namespace MarioGame.Entities
{
    public interface IEntity
    {
        void Update();
        void ChangeState(MarioState newstate);

        Vector2 getPosition();
    }
}
