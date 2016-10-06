using MarioGame.Entities;
using MarioGame.Entities.BlockEntities;
using MarioGame.Entities.EnemyEntities;
using MarioGame.Entities.ItemEntities;
using MarioGame.Entities.PlayerEntities;
using MarioGame.States.PlayerStates;
using MarioGame.Theming.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using static MarioGame.Sprites.PlayerSprites.MarioSprite;

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

        protected float _totalElapsed, _timePerFrame;

        protected SpriteEffects _flipped {
            get; set;
        }
        
        public AnimatedSprite(ContentManager content) : base(content)
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

            _frameHeight = _texture.Height;
            _frameWidth = _texture.Width / _numberOfFramesPerRow;
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

            var sourceRect = new Rectangle( ((int)_frameSet[_frameSetPosition]) * _frameWidth, ((int)_rowSet[_rowSetPosition]) * _frameHeight, _frameWidth, _frameHeight);
            batch.Draw(texture: _texture, position: Position, sourceRectangle: sourceRect, color: Color.White, effects : _flipped);
            drawRectangleBorder(batch, MarioEntity.boundingBox, 1, MarioEntity.boxColor);
            drawRectangleBorder(batch, GoombaEntity.boundingBox, 1, GoombaEntity.boxColor);
            drawRectangleBorder(batch, KoopaTroopaEntity.boundingBox, 1, KoopaTroopaEntity.boxColor);
            drawRectangleBorder(batch, QuestionBlockEntity.boundingBox, 1, QuestionBlockEntity.boxColor);
            drawRectangleBorder(batch, BrickBlockEntity.boundingBox, 1, BrickBlockEntity.boxColor);
            drawRectangleBorder(batch, CoinEntity.boundingBox, 1, CoinEntity.boxColor);
            drawRectangleBorder(batch, FireFlowerEntity.boundingBox, 1, FireFlowerEntity.boxColor);
            drawRectangleBorder(batch, Mushroom1UpEntity.boundingBox, 1, Mushroom1UpEntity.boxColor);
            drawRectangleBorder(batch, MushroomSuperEntity.boundingBox, 1, MushroomSuperEntity.boxColor);
            drawRectangleBorder(batch, StarEntity.boundingBox, 1, StarEntity.boxColor);


        }
        public void drawRectangleBorder (SpriteBatch batch, Rectangle toDraw, int borderThickness, Color borderColor)
        {
            // Draw top line
            batch.Draw(Scene.rectanglePixel, new Rectangle((toDraw.X), toDraw.Y, toDraw.Width, 1), borderColor);
            // Draw left line
            batch.Draw(Scene.rectanglePixel, new Rectangle(toDraw.X, toDraw.Y, 1, toDraw.Height), borderColor);
            // Draw right line
            batch.Draw(Scene.rectanglePixel, new Rectangle((toDraw.X + toDraw.Width - 1), toDraw.Y,1, toDraw.Height), borderColor);
            // Draw bottom line
            batch.Draw(Scene.rectanglePixel, new Rectangle(toDraw.X, toDraw.Y + toDraw.Height - 1, toDraw.Width,1), borderColor);
        }
    }
}
