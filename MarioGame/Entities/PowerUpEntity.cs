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
            pState = state;
        }
    }
}
