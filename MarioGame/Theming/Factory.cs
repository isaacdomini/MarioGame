using MarioGame.Entities;
using Microsoft.Xna.Framework;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.Theming
{
    static class Factory
    {
        static private int blockWidth = 30; // each intereger in location is a multiple of blockWidth. e.g. each block in our scene may be 20 pixels width. So if we have a block at an x location of 10, that block's x position would actually be at pixel 200
        public static Entity createEntity(string folderAndClass, Vector2 location)
        {
            Console.WriteLine(typeof(Entity).Namespace + "." + folderAndClass);
            Type type = Type.GetType(typeof(Entity).Namespace + "." + folderAndClass);
            return (Entity)Activator.CreateInstance(type, location * blockWidth);
        }
        public static void addTileMapToScript(String tileMapFile, Script script)
        {
            string json = File.ReadAllText(tileMapFile);
            Level level = JsonConvert.DeserializeObject<Level>(json);

            level.entities.FindAll(e => e.rowColumns != null).ForEach(e =>
            {
                e.rowColumns.ForEach(rc =>
                {
                    rc.columns.ForEach(c => script.AddEntity(createEntity(e.type, new Vector2(rc.row, c))));
                });
            });
            
            level.entities.FindAll(e => e.rowColumnWithHiddenItems != null).ForEach(e =>
            {
                e.rowColumnWithHiddenItems.ForEach(instance =>
                {
                    Entity entity = createEntity(e.type, new Vector2(instance.row, instance.column));
                    script.AddEntity(entity);
                    instance.hiddenItems.ForEach(h =>
                    {
                        while (h.amount-- > 0)
                        {
                            IHidable hidden = createEntity(h.type, new Vector2(instance.row, instance.column));

                        }
                    })

                });
                script.AddEntity(createEntity(e.type, new Vector2(e.row)))
            })
        }
    }

    public class RowColumn
    {
        public int row { get; set; }
        public List<int> columns { get; set; }
    }

    public class HiddenItem
    {
        public string type { get; set; }
        public int amount { get; set; }
    }

    public class RowColumnWithHiddenItem
    {
        public int row { get; set; }
        public int column { get; set; }
        public List<HiddenItem> hiddenItems { get; set; }
    }

    public class JEntity
    {
        public string type { get; set; }
        public List<RowColumn> rowColumns { get; set; }
        public List<RowColumnWithHiddenItem> rowColumnWithHiddenItems { get; set; }
    }

    public class Level
    {
        public int width { get; set; }
        public int height { get; set; }
        public List<int> checkpoints { get; set; }
        public List<JEntity> entities { get; set; }
    }
}
