using MarioGame.Core;
using MarioGame.Entities;
using MarioGame.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;
using static MarioGame.Entities.Entity;

namespace MarioGame.Sprites
{
    public abstract class AnimatedSprite : Sprite
    {
       
        protected int NumberOfFramesPerRow; //number of frames in the row

        //each action state uses a set of frames (e.g. frame numbers 7, 8, 9 on the specific row on the sprite sheet
        protected IDictionary<int, List<int>> FrameSets; //TODO: somehow figure out how to declare the type of the dictionary as <String, Frames> . . .it gave me an error when doing that. This should also get rid of the pesky casting on line 81
        protected List<int> FrameSet;
        protected int FrameSetPosition; //this refers to the position in the frameset. e.g. if our frameSet was <7,8,9> if _frameSetPosition = 1 then _frameSet[_frameSetPosition] would equal 8

        protected IDictionary<int, List<int>> RowSets;
        protected List<int> RowSet;
        protected int RowSetPosition;

        public int FrameWidth { get; private set; }

        public int FrameHeight { get; protected set; }

        protected float TotalElapsed, TimePerFrame;

        protected Directions Direction => Entity.Direction;
        protected SpriteEffects Flipped => Direction == Directions.Right ? SpriteEffects.FlipHorizontally : SpriteEffects.None;

        public AnimatedSprite(ContentManager content, Entity entity) : base(content, entity)
        {
            RowSets = new Dictionary<int, List<int>>
            {
                { 0, new List<int> {0 } }
            };
            FrameSets = new Dictionary<int, List<int>>
            {
                {0, new List<int> {0 } }
            };
            RowSetPosition = 0;
            FrameSetPosition = 0;

            RowSet = (List<int>) RowSets[0];
            FrameSet = (List<int>) FrameSets[0];

            NumberOfFramesPerRow = 1;

        }

        //NOTE: Child class must set _numberOfChildren
        public override void Load(int framesPerSecond = 5)
        {
            Texture = Content.Load<Texture2D>(AssetName);

            FrameHeight = Texture.Height;
            FrameWidth = Texture.Width / NumberOfFramesPerRow;
            FrameSetPosition = 0;

            TotalElapsed = 0;
            TimePerFrame = ((float)1/(float)framesPerSecond);
        }

        public override void Update(float elapsed)
        {
            TotalElapsed += elapsed;

            if (!(TotalElapsed > TimePerFrame)) return;
            FrameSetPosition++;
            FrameSetPosition = FrameSetPosition % FrameSet.Count;

            RowSetPosition++;
            RowSetPosition = RowSetPosition % RowSet.Count;

            TotalElapsed -= TimePerFrame;
        }

        public override void Draw(SpriteBatch batch)
        {
            if(!Entity._isVisible)
            {
                return;
            }
            var sourceRect = new Rectangle(((int)FrameSet[FrameSetPosition]) * FrameWidth, ((int)RowSet[RowSetPosition]) * FrameHeight, FrameWidth, FrameHeight);
            batch.Draw(texture: Texture, position: Position, sourceRectangle: sourceRect, color: Color.White, effects : Flipped);
     
        }
        public void ChangeDirection(Directions newDirection)
        {
        }

        public void ChangeActionState(ActionState actionState)
        {
            FrameSetPosition = 0;
        }
        public void ChangePowerUp(PowerUpState powerUpState)
        {
            RowSetPosition = 0;
        }
    }
}
