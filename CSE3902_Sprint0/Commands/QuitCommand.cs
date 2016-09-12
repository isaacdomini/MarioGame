using CSE3902_Sprint0.Core;

namespace CSE3902_Sprint0.Commands
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