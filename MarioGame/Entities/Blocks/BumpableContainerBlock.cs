using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities.Blocks
{
    class BumpableContainerBlock : Block, IBumpable
    {
        public BumpableContainerBlock(Vector2 position, ContentManager content) : base(position, content)
        {
        }
        public override void Bump()
        {
            if (_tickCount == 0)
            {
                _tickCount = 10;
                _velocity.Y = -1;
            }
            if (HasItems())
            {
                IContainable poppedItem = PopContainedItem();
                poppedItem.LeaveContainer();
                // TODO: Make poppedItem appear and pop out
            }
            _isVisible = true;
        }
    }
}
