using MarioGame.Entities;
using MarioGame.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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
    static class LevelLoader
    {
        static private int blockWidth = 30; // each intereger in location is a multiple of blockWidth. e.g. each block in our scene may be 20 pixels width. So if we have a block at an x location of 10, that block's x position would actually be at pixel 200
        public static Entity createEntity(string klass, Vector2 location, ContentManager content)
        {
            Type type = Type.GetType(typeof(Entity).Namespace + "." + klass);
            return (Entity)Activator.CreateInstance(type, location * blockWidth, content);
        }

        public static void addTileMapToScript(String tileMapFile, Script script, ContentManager content)
        {

            string json = File.ReadAllText(tileMapFile);
            Level level = JsonConvert.DeserializeObject<Level>(json);

            level.entities.FindAll(e => e.rowColumns != null).ForEach(e =>
            {
                e.rowColumns.ForEach(rc =>
                {
                rc.columns.ForEach(c => {
                    Entity entity = createEntity(e.type, new Vector2(c, rc.row), content);
                    script.AddEntity(entity);
                    if (e.actionState != null)
                    {
                        //TODO: make it so that we dont have to check what type each entity is 
                        if (entity is Block)
                        {
                            ((Block)entity).SetBlockActionState(e.actionState);
                        }
                    }
                    if (e.powerUpState != null)
                    {
                        if (entity is Block)
                        {
                            ((Block)entity).SetBlockPowerUpState(e.powerUpState);
                        }
                    }
                    });
                });
            });

            level.entities.FindAll(e => e.rowColumnWithHiddenItems != null).ForEach(e =>
            {
                e.rowColumnWithHiddenItems.ForEach(instance =>
                {
                    Entity entity = createEntity(e.type, new Vector2(instance.column, instance.row), content);
                    script.AddEntity(entity);
                    instance.hiddenItems.ForEach(h =>
                    {
                        while (h.amount-- > 0)
                        {
                            ContainableHidableEntity hiddenItem = (ContainableHidableEntity)createEntity(h.type, new Vector2(instance.column, instance.row), content);
                            hiddenItem.Hide();
                            ((IContainer)entity).AddContainedItem(hiddenItem);
                        }
                    });

                });
            });

        }
    }

    public class RowColumn
    {
        public float row { get; set; }
        public List<float> columns { get; set; }
    }

    public class HiddenItem
    {
        public string type { get; set; }
        public int amount { get; set; }
    }

    public class RowColumnWithHiddenItem
    {
        public float row { get; set; }
        public float column { get; set; }
        public List<HiddenItem> hiddenItems { get; set; }
    }

    public class JEntity
    {
        public string type { get; set; }
        public List<RowColumn> rowColumns { get; set; }
        public List<RowColumnWithHiddenItem> rowColumnWithHiddenItems { get; set; }
        public string powerUpState { get; set; }
        public string actionState { get; set; }
    }

    public class Level
    {
        public int width { get; set; }
        public int height { get; set; }
        public List<int> checkpoints { get; set; }
        public List<JEntity> entities { get; set; }
    }
}
