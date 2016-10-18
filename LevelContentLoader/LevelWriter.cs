using MarioGame.Theming;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Content.Pipeline;

namespace LevelContentLoader
{
    [ContentTypeWriter]
    public class BitmapFontWriter : ContentTypeWriter<Level>
    {
        protected override void Write(ContentWriter output, Level value)
        {
            output.Write(value.ToString());
        }

        public override string GetRuntimeType(TargetPlatform targetPlatform)
        {
            return typeof(Level).AssemblyQualifiedName;
        }

        public override string GetRuntimeReader(TargetPlatform targetPlatform)
        {
            return "MonoGame.Extended.BitmapFonts.Level, MonoGame.Extended";
        }

    }
}
