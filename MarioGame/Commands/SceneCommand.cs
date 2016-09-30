using MarioGame.Theming.Scenes;

namespace MarioGame.Commands
{
    class SceneCommand : ICommand
    {
        protected Scene Scene { get; set; }

        protected SceneCommand()
        {
            
        }

        protected SceneCommand(Scene scene)
        {
            Scene = scene;
        }

        public virtual void Execute()
        {
            
        }
    }
}
