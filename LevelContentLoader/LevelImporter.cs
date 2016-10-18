using Microsoft.Xna.Framework.Content.Pipeline;
using MarioGame.Theming;
using Newtonsoft.Json;
using System.IO;

namespace LevelContentLoader
{
    [ContentImporter(".json", DefaultProcessor = "LevelProcessor",
        DisplayName = "Level Importer - MonoGame.Extended")]
    public class LevelImporter : ContentImporter<Level>
    {
        public override Level Import(string filename, ContentImporterContext context)
        {
            context.Logger.LogMessage("Importing JSON file: {0}", filename);
            string json = File.ReadAllText(filename);
            return JsonConvert.DeserializeObject<Level>(json);
        }
    }
}
