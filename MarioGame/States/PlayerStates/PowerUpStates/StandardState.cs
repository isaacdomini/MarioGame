using MarioGame.Entities.Players;

namespace MarioGame.States.PlayerStates.PowerUpStates
{
    class StandardState : MarioPowerUpState
    {
        public StandardState(Mario entity) : base(entity)
        {
            powerUpState = MarioPowerUpStateEnum.Standard;
            entity.boundingBox.Width = 20;
            entity.boundingBox.Height = 20;
            marioEntity.isCollidable = true;
        }
        public override void ChangeToFire()
        {
            MarioPowerUpState fire = new FireState(mario);
            mario.ChangePowerUpState(fire);
            fire.Begin(this);

        }
        public override void ChangeToDead()
        {
            MarioPowerUpState dead = new DeadState(mario);
            mario.ChangePowerUpState(dead);
            dead.Begin(this);
        }
        public override void ChangeToSuper()
        {
            MarioPowerUpState super = new SuperState(mario);
            mario.ChangePowerUpState(super);
            super.Begin(this);
        }
    }
}
