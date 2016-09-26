using MarioGame.Entities;
using MarioGame.States.PlayerStates;
using MarioGame.Theming.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;
using System.Collections.Generic;

namespace MarioGame.Sprites
{
    public abstract class AnimatedSprite : Sprite
    {
       
        //each row on the sprite sheet is a different Power up state - e.g. row 1 is large mario, row 2 is regular mario, row 3 is fire mario.
        private int _spriteRowYPosition, _spriteRowHeight;
        protected int _numberOfFrames; //number of frames in the row

        //each action state uses a set of frames (e.g. frame numbers 7, 8, 9 on the specific row on the sprite sheet
        protected List<int> _frameSet;
        protected int _frameSetPosition; //this refers to the position in the frameset. e.g. if our frameSet was <7,8,9> if _frameSetPosition = 1 then _frameSet[_frameSetPosition] would equal 8

        private int _frameWidth;

        protected float _totalElapsed, _timePerFrame;

        public SpriteEffects _flipped {
            get
            {
                switch (((Entity)this._entity).ActionState.direction)
                {
                    case ActionState.Directions.Right:
                        return SpriteEffects.FlipHorizontally;
                        break;
                    case ActionState.Directions.Left:
                    default:
                        return SpriteEffects.None;
                        break;
                }
            }
        }


        protected IDictionary _frameSets;

        public AnimatedSprite(IEntity entity, ContentManager content, Viewport viewport) : base(entity, content, viewport)
        {
        }

        //NOTE: Child class must set _numberOfChildren
        public override void Load(int framesPerSecond = 1)
        {
            _texture = _content.Load<Texture2D>(_assetName);

            _frameWidth = _texture.Width / _numberOfFrames;
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
                _frameSetPosition = _frameSetPosition % _frameSetPosition;

                _totalElapsed -= _timePerFrame;
            }
        }

        public override void Draw(SpriteBatch batch)
        {
            if (Visible)
            {
                return;
            }

            var sourceRect = new Rectangle(_frameSet[_frameSetPosition] * _frameWidth, _spriteRowYPosition, _frameWidth, _spriteRowHeight);
            batch.Draw(texture =_texture, position =_position, sourceRectangle = sourceRect, color = Color.White, effects = _flipped);
        }
    }
}
