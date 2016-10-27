using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.Entities
{
    //items that start off as hidden - e.g. hidden question blocks that don't show until you bump them (or press the cheat code button) or items (e.g. powerups, coins) that are contained in blocks that are hidden inside of the block until some event occurs that makes the item visible and moves the items y-coordinate up by the height of one block
    public interface IHidable
    {
        bool IsVisible
        {
            get;
        }
        void Hide();
        void Show();
    }
}
