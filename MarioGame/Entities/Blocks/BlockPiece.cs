using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame.Entities
{
    public enum Partitions
    {
        TopLeft, TopRight, BottomLeft, BottomRight
    }

    public class BlockPiece : Entity
    {
        public BlockPiece(Vector2 position, ContentManager content) : base(position, content)
        {
        }
    }
}
