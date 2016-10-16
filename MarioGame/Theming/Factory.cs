using MarioGame.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.Theming
{
    class Factory
    {
        static private int blockWidth = 30; // each intereger in location is a multiple of blockWidth. e.g. each block in our scene may be 20 pixels width. So if we have a block at an x location of 10, that block's x position would actually be at pixel 200
        public IEntity createEntity(String folderAndClass, Vector2 location)
        {
            Console.WriteLine(typeof(Entity).Namespace + "." + folderAndClass);
            Type type = Type.GetType(typeof(Entity).Namespace + "." + folderAndClass);
            return (Entity)Activator.CreateInstance(type, location * blockWidth);
        }
        public void addTileMapToScript(String tileMapFile, Script script)
        {
            script.AddEntity(new Coin(new Vector2(150, 100), new CoinsSprite(Stage.Game1.Content)));
            _script.AddItem(new FireFlower(new Vector2(200, 100), new FireFlowerSprite(Stage.Game1.Content)));
            _script.AddItem(new Mushroom1Up(new Vector2(250, 100), new Mushroom1UpSprite(Stage.Game1.Content)));
        }
    }
}
