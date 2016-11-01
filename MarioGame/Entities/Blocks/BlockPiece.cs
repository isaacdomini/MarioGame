using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame.Entities
{
    public enum Partitions
    {
        TopLeft, TopRight, BottomLeft, BottomRight
    }

    public class BlockPiece : Entity
    {
        private Partitions _partition;
        private int millisecondsElapsed;
        private int millisecondsUntilDeletion = 550;
        private const float breakSpeed = 1;

       
        public BlockPiece(Vector2 position, ContentManager content, Action<Entity> addToScriptEntities, Partitions partition) : base(position, content, addToScriptEntities)
        {
            _partition = partition;
            switch (partition)
            {
                case Partitions.TopLeft:
                    _velocity.Y = -1 * breakSpeed;
                    _velocity.X = -1*breakSpeed; //TODO: change xVelocity with speed and direction
                    break;
                case Partitions.TopRight:
                    _velocity.Y = -1 * breakSpeed;
                    _velocity.X = 1*breakSpeed;
                    break;
                case Partitions.BottomLeft:
                    _velocity.Y = 1*breakSpeed;
                    _velocity.X = -1 * breakSpeed;
                    break;
                case Partitions.BottomRight:
                    _velocity.Y = 1 * breakSpeed;
                    _velocity.X = 1 * breakSpeed;
                    break;
            }
        }

        public override void Update(Viewport viewport, int elapsedMilliseconds)
        {
            base.Update(viewport, elapsedMilliseconds);
            millisecondsElapsed += elapsedMilliseconds; //TODO: make it so that user doesn't have to know the structure of gameTime
            if (millisecondsElapsed > millisecondsUntilDeletion)
            {
                Delete();
            }
        }

        public override void OnBlockBottomCollision()
        {
            base.OnBlockBottomCollision();
            _velocity.X = 0;
        }
    }
}
