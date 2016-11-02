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
       
        private int _numberOfFramesPerRow; //number of frames in the row
        protected int NumberOfFramesPerRow { get { return _numberOfFramesPerRow; } set { _numberOfFramesPerRow = value; } }
        //each action state uses a set of frames (e.g. frame numbers 7, 8, 9 on the specific row on the sprite sheet
        private int _frameSetPosition; //this refers to the position in the frameset. e.g. if our frameSet was <7,8,9> if _frameSetPosition = 1 then _frameSet[_frameSetPosition] would equal 8
        protected int FrameSetPosition { get { return _frameSetPosition; } set { _frameSetPosition = value; } }

        private IDictionary<int, Collection<int>> _frameSets;

        protected IDictionary<int, Collection<int>> FrameSets
        {
            get { return _frameSets; }
            set { _frameSets = value; }
        }

        //TODO: somehow figure out how to declare the type of the dictionary as <String, Frames> . . .it gave me an error when doing that. This should also get rid of the pesky casting on line 81
        private Collection<int> _frameSet;
        protected Collection<int> FrameSet { get { return _frameSet; } set { _frameSet = value; } }

        private IDictionary<int, Collection<int>> _rowSets;
        protected IDictionary<int, Collection<int>> RowSets { get { return _rowSets; } set { _rowSets = value; } }
        private Collection<int> _rowSet;
        protected Collection<int> RowSet { get { return _rowSet; } set { _rowSet = value; } }
        private int _rowSetPosition;
        protected int RowSetPosition { get { return _rowSetPosition; } set { _rowSetPosition = value; } }
        public int FrameWidth { get; private set; }

        public int FrameHeight { get; protected set; }

        private float _totalElapsed, _timePerFrame;
        protected float TotalElapsed { get { return _totalElapsed; } set { _totalElapsed = value; } }
        protected float TimePerFrame { get { return _timePerFrame; } set { _timePerFrame = value; } }
        protected Directions Direction => Entity.Direction;
        protected SpriteEffects Flipped => Direction == Directions.Right ? SpriteEffects.FlipHorizontally : SpriteEffects.None;

        internal AnimatedSprite(ContentManager content, Entity entity) : base(content, entity)
        {
            RowSets = new Dictionary<int, Collection<int>>
            {
                { 0, new Collection<int> {0 } }
            };
            FrameSets = new Dictionary<int, Collection<int>>
            {
                {0, new Collection<int> {0 } }
            };
            RowSetPosition = 0;
            FrameSetPosition = 0;

            RowSet = (Collection<int>) RowSets[0];
            FrameSet = (Collection<int>) FrameSets[0];

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
