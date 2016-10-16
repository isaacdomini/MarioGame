using MarioGame.Entities;

namespace MarioGame.States.PlayerStates
{
    public class MarioActionState : ActionState
    {
        public MarioActionStateEnum actionState
        {
            get; protected set; //TODO: make this read from some shared enum with Sprites
        }
        protected Mario mario;

        public MarioActionState(Mario entity) : base(entity)
        {
            mario = entity;
        }

        public virtual void Begin(MarioActionState prevState)
        {
            base.Begin(prevState);
            mario.mSprite.changeActionState(this);
        }
        public virtual void Jump() { }

        public virtual void MoveRight() { }

        public virtual void MoveLeft() { }

        public virtual void Crouch() { }
        public void Halt()
        {
            MarioActionState newState = new IdleMarioState(mario);
            newState.setDirection(this.direction);
            mario.ChangeActionState(newState);
            mario.SetVelocityToIdle();
            newState.Begin(this);
        }
    }
}
