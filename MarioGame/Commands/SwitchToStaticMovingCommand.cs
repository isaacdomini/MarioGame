using MarioGame.Theming.Scenes;

namespace MarioGame.Commands
{
    public class SwitchToStaticMovingCommand : ICommand
    {
        public SwitchToStaticMovingCommand(Scene scene)
        {
            Scene = scene;
        }

        public Scene Scene { get; }

        public void Execute()
        {
            Scene.ChangeSprite(Scene.SpriteTypes.StaticMoving.GetHashCode());
        }
    }
}