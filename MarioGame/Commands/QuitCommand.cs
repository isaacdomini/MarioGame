using MarioGame.Core;

namespace MarioGame.Commands
{
    public class QuitCommand : GameCommand
    {
        public QuitCommand(Game1 game) : base(game)
        {
            
        }

        public override void Execute()
        {
            Game.ExitCommand();
        }
    }
}