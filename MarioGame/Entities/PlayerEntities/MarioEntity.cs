
using MarioGame.Sprites.PlayerSprites;
using MarioGame.States.PlayerStates;
using Microsoft.Xna.Framework;

namespace MarioGame.Entities.PlayerEntities
{
    public class MarioEntity : IEntity
    {
        private MarioState _state;
        public MarioSprite Sprite { get; set; }
        public Vector2 Position { get; set; }

        public MarioEntity()
        {
            _state = new IdleMarioState(this);
        }
        public void Update()
        {
            
        }
        public void ChangeState(MarioState marioState)
        {
            _state = marioState;
        }
        public void Jump()
        {
            _state.Jump();
        }
    }
}
