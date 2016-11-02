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
        private PowerUpState _pState;
        protected PowerUpState PState { get { return _pState; } set { _pState = value; } }
        internal PowerUpState CurrentPowerUpState => PState;

        public PowerUpEntity(Vector2 position, ContentManager content, Action<Entity> addToScriptEntities, float xVelocity = 0, float yVelocity = 0) : base(position, content, addToScriptEntities, xVelocity: xVelocity, yVelocity: yVelocity)
        {
        }
        public void ChangePowerUpState(PowerUpState state)
        {
            PState = state;
        }
    }
}
