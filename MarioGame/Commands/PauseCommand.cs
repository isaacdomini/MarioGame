using MarioGame.Core;

namespace MarioGame.Commands
{
    public class PauseCommand : GameCommand
    {
        public PauseCommand(Game1 game) : base(game)
        {
            
        }

        public override void Execute()
        {
           // Game.PauseCommand();
        }
    }
}