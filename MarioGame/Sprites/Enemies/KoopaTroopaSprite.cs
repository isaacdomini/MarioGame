using MarioGame.Entities;
using MarioGame.Theming.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace MarioGame.Sprites
{
    public class KoopaTroopaSprite : AnimatedSprite
    {
        public enum Frames
        {
            //frames are all facing left. 
            MidWings = 0,
            Wings = 1,
            Walk = 2,
            Walk2 =3,
            DeadLegs =8,
            Dead=9
        }
        public KoopaTroopaSprite (ContentManager content) : base(content)
        {
            _assetName = "regularkoopa";
            _numberOfFramesPerRow = Enum.GetNames(typeof(Frames)).Length;

            _frameSets = new Dictionary<int, List<int>> {
                { 0, new List<int>{Frames.MidWings.GetHashCode(), Frames.Wings.GetHashCode(), Frames.Walk.GetHashCode(), Frames.Walk2.GetHashCode(), Frames.DeadLegs.GetHashCode(), Frames.Dead.GetHashCode() } },
            };
            _frameSet = _frameSets[0];
            _frameSetPosition = 0;
            _rowSetPosition = 0;
            _numberOfFramesPerRow = 10;
        }
        public override void Update(float elapsed)
        {
            base.Update(elapsed);
        }
    }
}