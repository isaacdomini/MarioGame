using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using MarioGame.States;

namespace MarioGame.Entities
{
    public class PowerUpEntity : Entity
    {
        protected PowerUpState pState;
        internal PowerUpState CurrentPowerUpState
        {
            get { return pState; }
        }
        public PowerUpEntity(Vector2 position, ContentManager content, float xVelocity = 0, float yVelocity = 0) : base(position, content, xVelocity, yVelocity)
        {
        }
        public void ChangePowerUpState(PowerUpState state)
        {
            Console.WriteLine("state passed into PowerUpEntity.ChangePowerUpState is DeadState?" + (state is DeadState));
            Console.WriteLine("state passed into PowerUpEntity.ChangePowerUpState is" + state.GetType());
            Console.WriteLine("the type of pState before pState = state is " + pState.GetType());
            pState = state;
            Console.WriteLine("the type of pState after pState = state is " + pState.GetType());
        }
    }
}
