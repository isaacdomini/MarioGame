using MarioGame.States.BlockStates;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities
{
    public class Block : Entity
    {
        // Could be useful for casting in certain circumstances
        public StandardState bState;
        public Block(Vector2 position, ContentManager content) : base(position, content)
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
