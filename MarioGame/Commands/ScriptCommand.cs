using MarioGame.Theming;

namespace MarioGame.Commands
{
    class ScriptCommand : ICommand
    {
        protected Script Script { get; set; }

        protected ScriptCommand()
        {
            
        }

        protected ScriptCommand(Script script)
        {
            Script = script;
        }

        public virtual void Execute()
        {
            
        }
    }
}
