﻿using MarioGame.Theming.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.Commands
{
    class DisplayCoins : ICommand
    {
        public DisplayCoins(Scene scene)
        {
            Scene = scene;
        }

        public Scene Scene { get; }

        public void Execute()
        {
        }
    }
}