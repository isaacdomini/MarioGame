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
        private int millisecondsUntilDeletion = 500;

       
        public BlockPiece(Vector2 position, ContentManager content, Action<Entity> addToScriptEntities, Partitions partition) : base(position, content, addToScriptEntities)
        {
            _partition = partition;
            switch (partition)
            {
                case Partitions.TopLeft:
                    _velocity.Y = -3;
                    _velocity.X = -3; //TODO: change xVelocity with speed and direction
                    break;
                case Partitions.TopRight:
                    _velocity.Y = -3;
                    _velocity.X = 3;
                    break;
                case Partitions.BottomLeft:
                    _velocity.Y = 3;
                    _velocity.X = -3;
                    break;
                case Partitions.BottomRight:
                    _velocity.Y = 3;
                    _velocity.X = 3;
                    break;
            }
        }

        public override void Update(Viewport viewport, int elapsedMilliseconds)
        {
            base.Update(viewport, elapsedMilliseconds);
            Console.WriteLine("Block pieces update called");
            millisecondsElapsed += elapsedMilliseconds; //TODO: make it so that user doesn't have to know the structure of gameTime
            if (millisecondsElapsed > millisecondsUntilDeletion)
            {
                Delete();
            }
        }
    }
}
