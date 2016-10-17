using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities
{
    public abstract class BumpableContainerBlock : BumpableBlock, IContainer
    {
        List<IContainable> containedItems = new List<IContainable>();
        public BumpableContainerBlock(Vector2 position, ContentManager content) : base(position, content)
        {
        }

        public virtual void addContainedItem(IContainable containedItem)
        {
            containedItems.Add(containedItem);
        }

        public bool hasItems()
        {
            return this.containedItems.Count > 0;
        }

        public virtual IContainable popContainedItem()
        {
            if (!this.hasItems())
            {
                throw new IndexOutOfRangeException();
            }
            IContainable containedItem = containedItems[0];
            containedItems.RemoveAt(0);
            return containedItem;
        }
    }
}
