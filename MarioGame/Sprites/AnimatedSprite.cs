using MarioGame.Entities;
using MarioGame.States.PlayerStates;
using MarioGame.Theming.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;
using System.Collections.Generic;
using static MarioGame.Sprites.PlayerSprites.MarioSprite;

namespace MarioGame.Sprites
{
    public abstract class AnimatedSprite : Sprite
    {
       
        protected int _numberOfFramesPerRow; //number of frames in the row

        //each action state uses a set of frames (e.g. frame numbers 7, 8, 9 on the specific row on the sprite sheet
        protected IDictionary _frameSets; //TODO: somehow figure out how to declare the type of the dictionary as <String, Frames> . . .it gave me an error when doing that. This should also get rid of the pesky casting on line 81
        protected List<Frames> _frameSet;
        protected int _frameSetPosition; //this refers to the position in the frameset. e.g. if our frameSet was <7,8,9> if _frameSetPosition = 1 then _frameSet[_frameSetPosition] would equal 8

        protected IDictionary _powerUpRowSets;
        protected List<Rows> _rowSet;
        protected int _rowSetPosition;

        private int _frameWidth;
        protected int _frameHeight;

        protected float _totalElapsed, _timePerFrame;

        protected SpriteEffects _flipped {
            get
            {
                switch (((Entity)this._entity).ActionState.direction)
                {
                    case ActionState.Directions.Right:
                        return SpriteEffects.FlipHorizontally;
                    case ActionState.Directions.Left:
                    default:
                        return SpriteEffects.None;
                }
            }
        }




        public AnimatedSprite(IEntity entity, ContentManager content, Viewport viewport) : base(entity, content, viewport)
        {
        }

        //NOTE: Child class must set _numberOfChildren
        public override void Load(int framesPerSecond = 1)
        {
            _texture = _content.Load<Texture2D>(_assetName);

            _frameWidth = _texture.Width / _numberOfFramesPerRow;
            _frameSetPosition = 0;

            _totalElapsed = 0;
            _timePerFrame = (float) 1/framesPerSecond;
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

            var sourceRect = new Rectangle( ((int)_frameSet[_frameSetPosition]) * _frameWidth, ((int)_rowSet[_rowSetPosition]) * _frameHeight, _frameWidth, _frameHeight);
            batch.Draw(texture: _texture, position: _position, sourceRectangle: sourceRect, color: Color.White, effects : _flipped);
        }
        public void changeFrameSet(MarioActionStates marioActionState)
        {
            _frameSet = (List <Frames>) _frameSets[marioActionState];
        }

        public void changePowerUp(MarioPowerUpStates marioPowerUpState)
        {
            _rowSet = (List<Rows>) _powerUpRowSets[marioPowerUpState];
        }
    }
}
