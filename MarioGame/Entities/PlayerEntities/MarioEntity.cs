
using MarioGame.Sprites.PlayerSprites;
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
        public void Update()
        {
            
        }
        public void Jump()
        {
            _state.Jump();
        }
    }
}
