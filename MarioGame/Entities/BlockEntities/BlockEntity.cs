
using MarioGame.Sprites;
using MarioGame.Sprites.PlayerSprites;
using MarioGame.States;
using MarioGame.States.BlockStates;
using Microsoft.Xna.Framework;

namespace MarioGame.Entities.BlockEntities
{
    public class BlockEntity : Entity
    {
        // Could be useful for casting in certain circumstances
        public StandardState bState;
        public BlockEntity(Vector2 position, Sprite sprite) : base(position, sprite)
        {
            bState = new StandardBlockState(this);
        }
        public void ChangeBrickState(StandardState state)
        {
            bState = state;
        }

        public void Standard()
        {
            bState.Standard();
        }
        public void Used()
        {
            bState.Used();
        }
    }
}
