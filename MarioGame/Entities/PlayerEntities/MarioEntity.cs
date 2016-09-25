
using MarioGame.Sprites.PlayerSprites;
using MarioGame.States;
using MarioGame.States.PlayerStates;
using Microsoft.Xna.Framework;

namespace MarioGame.Entities.PlayerEntities
{
    public class MarioEntity : Entity
    {
        public MarioEntity()
        {
            _state = new IdleMarioState(this);
        }
        public override void Update()
        {
            
        }
        public override void ChangeState(MarioState marioState)
        {
            _state = marioState;
        }
        public void Jump()
        {
            ((MarioState)_state).Jump();
        }
    }
}
