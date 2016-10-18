using MarioGame.Theming;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevelContentLoader
{
    public class LevelReader : ContentTypeReader<Level>
    {
        protected override Level Read(ContentReader input, Level existingInstance)
        {
            return existingInstance;
        }
    }
}
