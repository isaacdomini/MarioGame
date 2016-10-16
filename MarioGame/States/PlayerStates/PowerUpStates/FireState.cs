using MarioGame.Entities;

namespace MarioGame.States.PlayerStates.PowerUpStates
{
    class FireState : MarioPowerUpState
    {
        public FireState(Mario entity) : base(entity)
        {
            powerUpState = MarioPowerUpStateEnum.Fire;
            entity.boundingBox.Width = 30;
            entity.boundingBox.Height = 40;

        }
        public override void ChangeToDead()
        {
            ChangeToStandard();
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
