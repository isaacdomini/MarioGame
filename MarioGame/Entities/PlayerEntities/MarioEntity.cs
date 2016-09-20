
using MarioGame.Sprites.PlayerSprites;
using MarioGame.States.PlayerStates;

namespace MarioGame.Entities.PlayerEntities
{
    public class MarioEntity : IEntity
    {
        private MarioState _state;
        public MarioSprite Sprite { get; set; }

        public MarioEntity()
        {
            _state = new IdleMarioState(this);
        }
        public void Update()
        {
            
        }
    }
}
