using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MarioGame.States;

namespace MarioGame.Entities
{
    public interface IEntity
    {
        void Update();
        void ChangeActionState(ActionState newstate);

        Vector2 getPosition();

    }
}
