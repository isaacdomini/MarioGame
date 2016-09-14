using MarioGame.Theming.Scenes;

namespace MarioGame.Commands
{
    public class SwitchToStaticStillCommand : ICommand
    {
        public SwitchToStaticStillCommand(Scene scene)
        {
            Scene = scene;
        }

        public Scene Scene { get; }

        public void Execute()
        {
            Scene.ChangeSprite(Scene.SpriteTypes.StaticStill.GetHashCode());
        }
    }
}