using MarioGame.Theming;
using Microsoft.Xna.Framework.Content.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelContentLoader
{
    [ContentProcessor(DisplayName = "Level Processor - MonoGame.Extended")]
    public class LevelProcessor : ContentProcessor<Level, Level>
    {
        public override Level Process(Level input, ContentProcessorContext context)
        {
            return input;
        }
    }
}
