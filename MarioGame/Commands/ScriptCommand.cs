using MarioGame.Theming;

namespace MarioGame.Commands
{
    internal class ScriptCommand : ICommand
    {
        protected Script Script { get; set; }

        public ScriptCommand()
        {

        }

        public ScriptCommand(Script script)
        {
            Script = script;
        }

        public virtual void Execute()
        {

        }
    }
}
