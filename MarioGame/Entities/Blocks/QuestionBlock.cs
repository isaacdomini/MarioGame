using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities
{
    public class QuestionBlock : Block
    {
        Item _item;
        public QuestionBlock(Vector2 position, ContentManager content) : base(position, content)
        {
            boundingBox = new Rectangle((int)_position.X, (int)_position.Y, 18, 18);
            boxColor = Color.Blue;
            _item = null;
        }
        public QuestionBlock(Vector2 position, ContentManager content, bool visibility) : base(position, content)
        {
            boundingBox = new Rectangle((int)_position.X, (int)_position.Y, 18, 18);
            boxColor = Color.Blue;
            isVisible = visibility;
            _item = null;
        }
        public QuestionBlock(Vector2 position, ContentManager content, Item item) : base(position, content)
        {
            boundingBox = new Rectangle((int)_position.X, (int)_position.Y, 18, 18);
            boxColor = Color.Blue;
            _item = item;
        }
        public QuestionBlock(Vector2 position, ContentManager content, bool visibility, Item item) : base(position, content)
        {
            boundingBox = new Rectangle((int)_position.X, (int)_position.Y, 18, 18);
            boxColor = Color.Blue;
            isVisible = visibility;
            _item = item;
        }
        public override void Bump()
        {
            bState.Bump();
            // TODO: MAKE QUESTION BLOCK BUMP
            if (_item != null)
            {
                _item.Show();
            }
        }
    }
}
