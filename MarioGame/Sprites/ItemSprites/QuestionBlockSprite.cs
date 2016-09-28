using MarioGame.Entities;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.Sprites.ItemSprites
{
    class QuestionBlockSprite : AnimatedSprite
    {

        public enum Frames
        {
            //frames are all facing left. Except DeadMario who is facing the computer user.
            Light = 0,
            Med = 1,
            Dark = 2
        }
        public QuestionBlockSprite(IEntity entity, ContentManager content, Viewport viewport) : base(entity, content, viewport)
        {
            _assetName = "questionblock.png";
            _numberOfFramesPerRow = Enum.GetNames(typeof(Frames)).Length;

            _frameSets = new Dictionary<int, List<Frames>> {
                { 0, new List<Frames> { Frames.Light, Frames.Med, Frames.Dark } },
            };
        }
    }
}
