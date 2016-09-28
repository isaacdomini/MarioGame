using MarioGame.Entities;
using MarioGame.Theming.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace MarioGame.Sprites
{
    public class FireFlower : AnimatedSprite //TODO: refactor this class to use either ANimated Sprite or Sprite
    {

        public enum Frames
        {
            //frames are all facing left. Except DeadMario who is facing the computer user.
            FullCoin = 1,
            PartialCoin = 2
            // ??? === ???
        }
        //power up states - standard(small), super(big), fire ,start (invincible), Dead

        public FireFlower(ContentManager content) : base(content)
        {
            _assetName = "ItemSheet2";
            // _numberOfFramesPerRow = 15;
            // _frameHeight = 40;
            //Each state has a frameSet
            /* _frameSets = new Dictionary<MarioActionStates, List<Frames>> {
             };

             _powerUpRowSets = new Dictionary<MarioPowerUpStates, List<Rows>>
             {
                 {MarioPowerUpStates.Standard, new List<Rows> {Rows.Standard } },
                 {MarioPowerUpStates.Super, new List<Rows> {Rows.Super } },
                 {MarioPowerUpStates.Fire, new List<Rows> {Rows.Fire } },
                 {MarioPowerUpStates.Invincible, new List<Rows> {Rows.Standard, Rows.Fire, Rows.Luigi } },  //Cycle between various types of mario sprite to give the flashing feel of invincibility
                 {MarioPowerUpStates.Dead, new List<Rows> {Rows.Standard} }
             }; */
        }

    }
}

