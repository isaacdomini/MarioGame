
namespace MarioGame.States
{
    public interface IState
    {
        void Begin(IState previousState);
        void EndState();
    }
}
