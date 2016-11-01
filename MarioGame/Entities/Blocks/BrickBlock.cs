using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using MarioGame.States;
using MarioGame.Core;

namespace MarioGame.Entities
{
    class BrickBlock : BumpableContainerBlock
    {
        private List<BlockPiece> blockPieces;
        private int _width = 16, _height = 16; //TODO somehow calculate this width via the sprite and not hardcode. Or maybe at least from a global constants variable.
        public BrickBlock(Vector2 position, ContentManager content) : base(position, content)
        {
        }

        private void CreateBlockPieces(ContentManager content)
        {
            //blockPieces.Add(new BlockPiece(_position,content, Partitions.TopLeft));
            //blockPieces.Add(new BlockPiece(_position + new Vector2(_width / 2, 0),content, Partitions.TopRight));
            //blockPieces.Add(new BlockPiece(_position + new Vector2(0, _width /2),content, Partitions.BottomLeft));
            //blockPieces.Add(new BlockPiece(_position + new Vector2(_width/2, _width / 2),content, Partitions.BottomRight));
        }

        public override void OnCollide(IEntity otherObject, Sides side, Sides otherSide)
        {
            var mario = otherObject as Mario;
            if (mario == null || side != Sides.Bottom) return;

            if (mario.CanBreakBricks)
            {
                Break();
            }
            else
            {
                Bump();
            }
        }
        public override void Break()
        {
            base.Break();
            ((BlockActionState)AState).Break();
        }
    }
}
