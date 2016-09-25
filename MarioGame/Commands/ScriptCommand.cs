using MarioGame.Theming;

namespace MarioGame.Commands
{
    class ScriptCommand : ICommand
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
