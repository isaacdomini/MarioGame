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
       
        protected int _numberOfFramesPerRow; //number of frames in the row

        //each action state uses a set of frames (e.g. frame numbers 7, 8, 9 on the specific row on the sprite sheet
        protected IDictionary<int, List<int>> _frameSets; //TODO: somehow figure out how to declare the type of the dictionary as <String, Frames> . . .it gave me an error when doing that. This should also get rid of the pesky casting on line 81
        protected List<int> _frameSet;
        protected int _frameSetPosition; //this refers to the position in the frameset. e.g. if our frameSet was <7,8,9> if _frameSetPosition = 1 then _frameSet[_frameSetPosition] would equal 8

        protected IDictionary<int, List<int>> _rowSets;
        protected List<int> _rowSet;
        protected int _rowSetPosition;

        private int _frameWidth;
        protected int _frameHeight;
        public int FrameWidth { get { return _frameWidth; } private set { _frameWidth = value; } }
        public int FrameHeight { get { return _frameHeight; } protected set { _frameHeight = value; } }

        protected float _totalElapsed, _timePerFrame;

        protected SpriteEffects _flipped {
            get; set;
        }
        
        public AnimatedSprite(ContentManager content, Entity entity) : base(content, entity)
        {
            _rowSets = new Dictionary<int, List<int>>
            {
                { 0, new List<int> {0 } }
            };
            _frameSets = new Dictionary<int, List<int>>
            {
                {0, new List<int> {0 } }
            };
            _rowSetPosition = 0;
            _frameSetPosition = 0;

            _rowSet = (List<int>) _rowSets[0];
            _frameSet = (List<int>) _frameSets[0];

            _numberOfFramesPerRow = 1;

        }

        //NOTE: Child class must set _numberOfChildren
        public override void Load(int framesPerSecond = 5)
        {
            _texture = _content.Load<Texture2D>(_assetName);

            FrameHeight = _texture.Height;
            FrameWidth = _texture.Width / _numberOfFramesPerRow;
            _frameSetPosition = 0;

            _totalElapsed = 0;
            _timePerFrame = ((float)1/(float)framesPerSecond);
        }

        public override void Update(float elapsed)
        {
            _totalElapsed += elapsed;
            if (_totalElapsed > _timePerFrame)
            {
                _frameSetPosition++;
                _frameSetPosition = _frameSetPosition % _frameSet.Count;

                _rowSetPosition++;
                _rowSetPosition = _rowSetPosition % _rowSet.Count;

                _totalElapsed -= _timePerFrame;
            }
        }

        public override void Draw(SpriteBatch batch)
        {
            if (Visible)
            {
                return;
            }

            var sourceRect = new Rectangle(((int)_frameSet[_frameSetPosition]) * FrameWidth, ((int)_rowSet[_rowSetPosition]) * _frameHeight, FrameWidth, FrameHeight);
            batch.Draw(texture: _texture, position: Position, sourceRectangle: sourceRect, color: Color.White, effects : _flipped);
     
        }
        public void changeDirection(Directions newDirection)
        {
            if (newDirection == Directions.Left)
            {
                _flipped = SpriteEffects.None;
            }
            else if (newDirection == Directions.Right)
            {
                _flipped = SpriteEffects.FlipHorizontally;
            }
        }

        public void changeActionState(ActionState actionState)
        {
            _frameSetPosition = 0;
        }
        public void changePowerUp(PowerUpState powerUpState)
        {
            _rowSetPosition = 0;
        }
    }
}
