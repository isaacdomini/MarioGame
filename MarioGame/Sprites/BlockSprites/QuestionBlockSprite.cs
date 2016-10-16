using MarioGame.Entities;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.Sprites
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
        public QuestionBlockSprite(ContentManager content) : base(content)
        {
            _assetName = "questionblock";
            _numberOfFramesPerRow = Enum.GetNames(typeof(Frames)).Length;

            _frameSets = new Dictionary<int, List<int>> {
                { 0, new List<int> { Frames.Light.GetHashCode(), Frames.Med.GetHashCode(), Frames.Dark.GetHashCode() } },
            };
            _frameSet = _frameSets[Frames.Light.GetHashCode()];

        }
    }
}
