using MarioGame.Core;
using MarioGame.Entities;
using MarioGame.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.NetworkInformation;
using static MarioGame.Entities.Entity;

namespace MarioGame.Sprites
{
    public abstract class AnimatedSprite : Sprite
    {
        protected IDictionary<int, Collection<int>> FrameSets { get; set; }

        //TODO: somehow figure out how to declare the type of the dictionary as <String, Frames> . . .it gave me an error when doing that. This should also get rid of the pesky casting on line 81
        protected Collection<int> FrameSet { get; set; }

        protected IDictionary<int, Collection<int>> RowSets { get; set; }

        protected Collection<int> RowSet { get; set; }

        protected int RowSetPosition { get; set; }

        //each action state uses a set of frames (e.g. frame numbers 7, 8, 9 on the specific row on the sprite sheet
        protected int FrameSetPosition { get; set; }
        protected int NumberOfFramesPerRow { get; set; }
        public int FrameWidth { get; private set; }

        public int FrameHeight { get; protected set; }

        protected float TotalElapsed { get; set; }

        protected float TimePerFrame { get; set; }

        protected Directions Direction => Entity.Direction;
        protected SpriteEffects Flipped => Direction == Directions.Right ? SpriteEffects.FlipHorizontally : SpriteEffects.None;

        protected virtual void DefineFrameSets()
        {
            RowSets = new Dictionary<int, Collection<int>>
            {
                { 0, new Collection<int> {0 } }
            };
            FrameSets = new Dictionary<int, Collection<int>>
            {
                {0, new Collection<int> {0 } }
            };
            NumberOfFramesPerRow = 1;
        }

        protected virtual void SwitchToInitialFrameSet()
        {
            RowSetPosition = 0;
            FrameSetPosition = 0;
            RowSet = (Collection<int>) RowSets[0];
            FrameSet = (Collection<int>) FrameSets[0];
        }
        internal AnimatedSprite(ContentManager content, Entity entity) : base(content, entity)
        {
           DefineFrameSets();
            SwitchToInitialFrameSet(); 
        }

        //NOTE: Child class must set _numberOfChildren
        public override void Load(int framesPerSecond)
        {
            base.Load(framesPerSecond);
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
            var sourceRect = new Rectangle(((int)FrameSet[FrameSetPosition]) * FrameWidth, ((int)RowSet[RowSetPosition]) * FrameHeight, FrameWidth, FrameHeight);
            batch.Draw(texture: Texture, position: Position, sourceRectangle: sourceRect, color: Color.White, effects: Flipped);
        }

        public virtual void ChangeActionState()
        {
            FrameSetPosition = 0;
        }
        public virtual void ChangePowerUp()
        {
            RowSetPosition = 0;
        }
    }
}
