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
        public static Entity CreateEntity(string klass, Vector2 location, ContentManager content, Action<Entity> addToEntities)
        {
            var type = Type.GetType(typeof(Entity).Namespace + "." + klass);
            Debug.Assert(type != null, "type != null");
            return (Entity)Activator.CreateInstance(type, location * GlobalConstants.GridWidth, content, addToEntities);
        }

        public static void AddTileMapToScript(string tileMapFile, Script script, ContentManager content)
        {

            var json = File.ReadAllText(tileMapFile);
            var level = JsonConvert.DeserializeObject<Level>(json);
            script.LevelWidth = level.Width;
            level.Entities.FindAll(e => e.Position != null).ForEach(e =>
            {
                e.Position.ForEach(rc =>
                {
                rc.Columns.ForEach(c => {
                    var entity = CreateEntity(e.Type, new Vector2(c, rc.Row), content, script.AddEntity);
                    script.AddEntity(entity);
                    if(entity is Mario)
                    {
                        ((Mario)entity).LevelWidth = level.Width*GlobalConstants.GridWidth;
                    }
                    if(entity is BackgroundItem)
                    {
                        ((BackgroundItem)entity).Layer = e.BackgroundLayer;
                    }
                    if (e.ActionState != null)
                    {
                        //TODO: make it so that we dont have to check what type each entity is 
                        if (entity is Block)
                        {
                            ((Block)entity).SetBlockActionState(e.ActionState);
                        }
                    }
                    if (e.Visibility != null)
                    {
                        if (entity is Block)
                        {//TODO: get rid of check for block in case we want to init mario to a certain power up state. also get rid of block power up states.
                            if (e.Visibility == "Hidden")
                            {
                                ((Block)entity).Hide();
                            }
                            else
                            {
                                ((Block)entity).Show();
                            }

                        }
                    }
                    else
                    {
                        if (entity is Block)
                        {
                            ((Block)entity).Show();
                        }
                    }
                });
                });
            });

            level.Entities.FindAll(e => e.PositionWithHiddenItems != null).ForEach(e =>
            {
                e.PositionWithHiddenItems.ForEach(instance =>
                {
                    var entity = CreateEntity(e.Type, new Vector2(instance.Column, instance.Row), content, script.AddEntity);
                    script.AddEntity(entity);
                    if (e.ActionState != null)
                    {
                        //TODO: make it so that we dont have to check what type each entity is 
                        if (entity is Block)
                        {
                            ((Block)entity).SetBlockActionState(e.ActionState);
                        }
                    }
                    if (e.Visibility != null)
                    {
                        if (entity is Block)
                        {//TODO: get rid of check for block in case we want to init mario to a certain power up state. also get rid of block power up states.
                            if (e.Visibility == "Hidden")
                            {
                                ((Block)entity).Hide();
                            }
                            else
                            {
                                ((Block)entity).Show();
                            }
                        }
                    }
                    else
                    {
                        if (entity is Block)
                        {
                            ((Block)entity).Show();
                        }
                    }
                    instance.HiddenItems.ForEach(h =>
                    {
                        while (h.Amount-- > 0)
                        {
                            var hiddenItem = (ContainableHidableEntity)CreateEntity(h.Type, new Vector2(instance.Column, instance.Row), content, script.AddEntity);
                            ((IContainer)entity).AddContainedItem(hiddenItem);
                            script.AddEntity(hiddenItem);
                            hiddenItem.Hide();
                        }
                    });

                });
            });

        }
    }

    internal class Position
    {
        internal float Row { get; set; }
        internal List<float> Columns { get; set; }
    }

    internal class HiddenItem
    {
        internal string Type { get; set; }
        internal int Amount { get; set; }
    }

    internal class PositionWithHiddenItem
    {
        internal float Row { get; set; }
        internal float Column { get; set; }
        internal List<HiddenItem> HiddenItems { get; set; }
    }

    internal class JEntity
    {
        internal string Type { get; set; }
        internal List<Position> Position { get; set; }
        internal List<PositionWithHiddenItem> PositionWithHiddenItems { get; set; }
        internal string Visibility { get; set; }
        internal string ActionState { get; set; }
        internal string Backgroundtype { get; set; }
        internal int BackgroundLayer { get; set; }
    }

    internal class Level
    {
        internal int Width { get; set; }
        internal int Height { get; set; }
        internal List<int> Checkpoints { get; set; }
        internal List<JEntity> Entities { get; set; }
    }
}
