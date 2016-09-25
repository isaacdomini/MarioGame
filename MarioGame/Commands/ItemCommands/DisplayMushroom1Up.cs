using MarioGame.Theming.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.Commands
{
    class DisplayMushroom1Up : ICommand
    {
        public DisplayMushroom1Up(Scene scene)
        {
            Scene = scene;
        }

        public Scene Scene { get; }

        public void Execute()
        {
            Scene.ShowItems(Scene.ItemTypes.Mushroom1Up.GetHashCode());
        }
    }
}
