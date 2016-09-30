using MarioGame.Entities;
using MarioGame.Theming.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace MarioGame.Sprites
{
    public enum Frames
    {
        //frames are all facing left. 
        Walk = 0,
        Walk1 = 1,
        Dead = 2,
    }

    public class GoombaSprite : AnimatedSprite
    {
        public GoombaSprite(ContentManager content) : base(content)
        {
            _assetName = "regulargoomba";
            _numberOfFramesPerRow = Enum.GetNames(typeof(Frames)).Length;

            _frameSets = new Dictionary<int, List<int>> {
                { 0, new List<int>{Frames.Walk.GetHashCode(), Frames.Walk1.GetHashCode(), Frames.Dead.GetHashCode()} },
            };
            _frameSet = _frameSets[Frames.Walk.GetHashCode()];
            _frameSetPosition = 0;
            _rowSetPosition = 0;
            _numberOfFramesPerRow = 3;
        }
        public override void Update(float elapsed)
        {
            base.Update(elapsed);
        }
    }
}