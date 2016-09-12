using CSE3902_Sprint0.Theming.Scenes;

namespace CSE3902_Sprint0.Commands
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