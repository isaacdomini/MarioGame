
using MarioGame.Sprites.PlayerSprites;
using MarioGame.States;
using MarioGame.States.PlayerStates;
using Microsoft.Xna.Framework;

namespace MarioGame.Entities.PlayerEntities
{
    public class MarioEntity : Entity
    {
        protected MarioState state;


        public MarioEntity()
        {
            state = new IdleMarioState(this);
        }
        public override void Update()
        {
            
        }
        public void Jump()
        {
            state.Jump();
        }
    }
}
