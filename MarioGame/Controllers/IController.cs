﻿using MarioGame.Commands;

namespace MarioGame.Controllers
{
    public interface IController
    {
        void UpdateInput();

        void AddCommand(int key, ICommand command);
        void AddPauseScreenKeys(int key, ICommand command);
        void AddHeldCommand(int key, ICommand command);
        void CheckForResume();
    }
}