using MarioGame.Core;

namespace MarioGame.Commands
{
    public class ResetCommand : GameCommand
    {
        public ResetCommand(Game1 game) : base(game)
        {
            
        }

        public override void Execute()
        {
            Game.ResetCommand();
        }
    }
}