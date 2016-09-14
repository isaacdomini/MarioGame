using MarioGame.Theming.Scenes;

namespace MarioGame.Commands
{
    public class SwitchToAnimatedStillCommand : ICommand
    {
        public SwitchToAnimatedStillCommand(Scene scene)
        {
            Scene = scene;
        }

        public Scene Scene { get; }

        public void Execute()
        {
            Scene.ChangeSprite(Scene.SpriteTypes.AnimatedStill.GetHashCode());
        }
    }
}