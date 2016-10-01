
using System;
using MarioGame.Entities.PlayerEntities;
using MarioGame.Entities;
using MarioGame.Sprites;

namespace MarioGame.States.PlayerStates
{
    public class ActionState : State
    {
        public Directions direction
        {
            get; private set;
        }
        public enum Directions
        {
            Left = 1,
            Right = 2
        }
        public void setDirection(Directions newDir)
        {
            direction = newDir;
        }
        public bool isFacingLeft()
        {
            return direction == Directions.Left;
        }
        public bool isFacingRight()
        {
            return direction == Directions.Right;
        }
        public void turnLeft()
        {
            direction = Directions.Left;
        }
        public void turnRight()
        {
            direction = Directions.Right;
        }
        public ActionState(IEntity entity) : base(entity)
        {

        }
        public override void Begin(IState prevState)
        {
            base.Begin(prevState);
        }


    }
}
