using MarioGame.Entities;

namespace MarioGame.States.PlayerStates.PowerUpStates
{
    class SuperState : MarioPowerUpState
    {
        public SuperState(Mario entity) : base(entity)
        {
            powerUpState = MarioPowerUpStateEnum.Super;
            entity.boundingBox.Width = 30;
            entity.boundingBox.Height = 40;

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
        public override void ChangeToDead()
        {
            ChangeToStandard();
        }
    }
}
