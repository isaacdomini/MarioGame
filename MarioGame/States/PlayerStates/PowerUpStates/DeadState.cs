using MarioGame.Entities;
using MarioGame.Theming;

namespace MarioGame.States
{
    internal class DeadState : MarioPowerUpState
    {
        private int millisecondsDead;
        private const int deadAnimationDuration = 2000;//milliseconds
        public DeadState(Mario entity, MarioPowerUpStateMachine stateMachine) : base(entity, stateMachine)
        {
            PowerUpState = MarioPowerUpStateEnum.Dead;
        }

        public override void Begin(MarioPowerUpState prevState)
        {
            Mario.ChangePowerUpState(StateMachine.DeadState);
            //Entities.Entity.Script.AudioManager.playEffect(GlobalConstants.SFXFiles[AudioManager.SFXEnum.powerdown.GetHashCode()]);
            Mario.SetVelocityToJumping();
            millisecondsDead = 0;
            Entities.Mario.Scoreboard.LoseLife();
        }

        public override void UpdateEntity(int elapsedMilliseconds)
        {
            base.UpdateEntity(elapsedMilliseconds);
            millisecondsDead += elapsedMilliseconds;
            if (millisecondsDead > deadAnimationDuration)
            {
                Mario.RespawnOrGameOver();
                millisecondsDead = 0;
            }

        }
    }
}
