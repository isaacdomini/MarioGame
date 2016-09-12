using CSE3902_Sprint0.Theming.Scenes;

namespace CSE3902_Sprint0.Commands
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