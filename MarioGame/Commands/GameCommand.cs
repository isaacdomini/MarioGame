﻿using MarioGame.Core;

namespace MarioGame.Commands
{
    public class GameCommand : ICommand
    {

        protected Game1 Game { get; set; }

        protected GameCommand(Game1 game)
        {
            Game = game;
        }

        public virtual void Execute()
        {
            
        }
    }
}
