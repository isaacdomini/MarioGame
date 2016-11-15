using MarioGame.Commands;

namespace MarioGame.Controllers
{
    public interface IController
    {
        void UpdateInput();

        void AddCommand(int key, ICommand command);
        void AddPauseScreenCommand(int key, ICommand command);
        void AddHeldCommand(int key, ICommand command);
        void AddGameOverScreenCommand(int key, ICommand command);
        void UpdatePauseInput();
        void UpdateGameOverInput();
    }
}