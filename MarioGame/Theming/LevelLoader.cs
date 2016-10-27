using MarioGame.Entities;
using MarioGame.States;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.Theming
{
    internal static class LevelLoader
    {
        private static int _blockWidth = 30; // each intereger in location is a multiple of blockWidth. e.g. each block in our scene may be 20 pixels width. So if we have a block at an x location of 10, that block's x position would actually be at pixel 200
        public static Entity CreateEntity(string klass, Vector2 location, ContentManager content)
        {
            var type = Type.GetType(typeof(Entity).Namespace + "." + klass);
            Debug.Assert(type != null, "type != null");
            return (Entity)Activator.CreateInstance(type, location * _blockWidth, content);
        }

        public static void AddTileMapToScript(String tileMapFile, Script script, ContentManager content)
        {

            var json = File.ReadAllText(tileMapFile);
            var level = JsonConvert.DeserializeObject<Level>(json);

            level.entities.FindAll(e => e.position != null).ForEach(e =>
            {
                e.position.ForEach(rc =>
                {
                rc.columns.ForEach(c => {
                    var entity = CreateEntity(e.type, new Vector2(c, rc.row), content);
                    script.AddEntity(entity);
                    if (e.actionState != null)
                    {
                        //TODO: make it so that we dont have to check what type each entity is 
                        if (entity is Block)
                        {
                            ((Block)entity).SetBlockActionState(e.actionState);
                        }
                    }
                    if (e.visibility != null)
                    {
                        if (entity is Block)
                        {//TODO: get rid of check for block in case we want to init mario to a certain power up state. also get rid of block power up states.
                            if (e.visibility == "Hidden")
                            {
                                ((Block)entity).Hide();
                            }
                            else
                            {
                                ((Block)entity).Show();
                            }

                        }
                    }
                    });
                });
            });

            level.entities.FindAll(e => e.positionWithHiddenItems != null).ForEach(e =>
            {
                e.positionWithHiddenItems.ForEach(instance =>
                {
                    var entity = CreateEntity(e.type, new Vector2(instance.column, instance.row), content);
                    script.AddEntity(entity);
                    if (e.actionState != null)
                    {
                        //TODO: make it so that we dont have to check what type each entity is 
                        if (entity is Block)
                        {
                            ((Block)entity).SetBlockActionState(e.actionState);
                        }
                    }
                    if (e.visibility != null)
                    {
                        if (entity is Block)
                        {//TODO: get rid of check for block in case we want to init mario to a certain power up state. also get rid of block power up states.
                            if (e.visibility == "Hidden")
                            {
                                ((Block)entity).Hide();
                            }
                            else
                            {
                                ((Block)entity).Show();
                            }
                        }
                    }
                    instance.hiddenItems.ForEach(h =>
                    {
                        while (h.amount-- > 0)
                        {
                            var hiddenItem = (ContainableHidableEntity)CreateEntity(h.type, new Vector2(instance.column, instance.row), content);
                            hiddenItem.Hide();
                            ((IContainer)entity).AddContainedItem(hiddenItem);
                        }
                    });

                });
            });

        }
    }

    public class position
    {
        public float row { get; set; }
        public List<float> columns { get; set; }
    }

    public class HiddenItem
    {
        public string type { get; set; }
        public int amount { get; set; }
    }

    public class positionWithHiddenItem
    {
        public float row { get; set; }
        public float column { get; set; }
        public List<HiddenItem> hiddenItems { get; set; }
    }

    public class JEntity
    {
        public string type { get; set; }
        public List<position> position { get; set; }
        public List<positionWithHiddenItem> positionWithHiddenItems { get; set; }
        public string visibility { get; set; }
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
