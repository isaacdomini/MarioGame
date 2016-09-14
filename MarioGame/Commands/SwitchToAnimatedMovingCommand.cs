using MarioGame.Theming.Scenes;

namespace MarioGame.Commands
{
    public class SwitchToAnimatedMovingCommand : ICommand
    {
        public SwitchToAnimatedMovingCommand(Scene scene)
        {
            Scene = scene;
        }

        public Scene Scene { get; }

        public void Execute()
        {
            Scene.ChangeSprite(Scene.SpriteTypes.AnimatedMoving.GetHashCode());
        }
    }
}