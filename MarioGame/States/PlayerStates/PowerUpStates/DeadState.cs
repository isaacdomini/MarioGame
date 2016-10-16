using MarioGame.Entities;

namespace MarioGame.States.PlayerStates.PowerUpStates
{
    class DeadState : MarioPowerUpState
    {
        public DeadState(Mario entity) : base(entity)
        {
            powerUpState = MarioPowerUpStateEnum.Dead;
            entity.boundingBox.Width = 20;
            entity.boundingBox.Height = 20;
        }
        public override void ChangeToFire()
        {
            MarioPowerUpState fire = new FireState(mario);
            mario.ChangePowerUpState(fire);
            fire.Begin(this);
        }
        public override void ChangeToStandard()
        {
            MarioPowerUpState standard = new StandardState(mario);
            mario.ChangePowerUpState(standard);
            standard.Begin(this);
        }
        public override void ChangeToSuper()
        {
            MarioPowerUpState super = new SuperState(mario);
            mario.ChangePowerUpState(super);
            super.Begin(this);
        }
    }
}
