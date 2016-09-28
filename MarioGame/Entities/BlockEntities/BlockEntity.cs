
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
        public MarioSprite mSprite;
        public StandardState bState;
        public BlockEntity(Vector2 position, ISprite sprite) : base(position, sprite)
        {
            bState = new StandardBlockState(this);
            // Now only cast once
            mSprite = (MarioSprite)_sprite;
        }
        public override void Update(){}
        public void ChangeBrickState(StandardState state)
        {
            bState = state;
        }
        public void Bump()
        {
            bState.Bump();
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
