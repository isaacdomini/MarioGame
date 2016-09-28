﻿using MarioGame.Entities;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.Sprites.ItemSprites
{
    class UsedBlock : AnimatedSprite
    {

        public enum Frames
        {
            Used = 0,
        }
        public UsedBlock(ContentManager content) : base(content)
        {
            _assetName = "usedblock.png";
            _numberOfFramesPerRow = Enum.GetNames(typeof(Frames)).Length;

            _frameSets = new Dictionary<int, List<int>> {
                { 0, new List<int> { Frames.Used.GetHashCode() } },
            };
        }
    }
}
