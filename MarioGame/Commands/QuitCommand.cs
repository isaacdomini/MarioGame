using MarioGame.Core;

namespace MarioGame.Commands
{
    public class QuitCommand : ICommand
    {
        public QuitCommand(Game1 game)
        {
            Game = game;
        }

        private Game1 Game { get; }

        public void Execute()
        {
            Game.ExitCommand();
        }
    }
}