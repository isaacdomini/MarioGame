using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using MarioGame.States;
using Microsoft.Xna.Framework.Graphics;
using MarioGame.States.BlockStates.ActionStates;

namespace MarioGame.Entities
{
    class BumpableContainerBlock : Block, IBumpable, IContainer
    {
        Queue<IContainable> _containedItems = new Queue<IContainable>();
        protected int _tickCount;
        public BumpableContainerBlock(Vector2 position, ContentManager content, Action<Entity> addToScriptEntities) : base(position, content, addToScriptEntities)
        {
            _tickCount = 0;

        }
        public override void Update(Viewport viewport, int elapsedMilliseconds)
        {
            base.Update(viewport, elapsedMilliseconds);
            if (_tickCount > 1)
            {
                _tickCount--;
            }
            else if (_tickCount == 1)
            {
                _tickCount = -10;
                _velocity.Y = 1;
            }
            else if (_tickCount < -1)
            {
                _tickCount++;
            }
            else if (_tickCount == -1)
            {
                _tickCount = 0;
                _velocity.Y = 0;
                if (AState is BumpingState) ChangeToStandard();
            }
        }
        public override void Bump()
        {
            if (!(AState is UsedBlockState) && !(AState is BumpingState))
            {
                ((BlockActionState)AState).Bump();
                if (_tickCount == 0)
                {
                    _tickCount = 10;
                    _velocity.Y = -1;
                }
                if (HasItems())
                {
                    IContainable poppedItem = PopContainedItem();
                    poppedItem.LeaveContainer();
                    if(poppedItem is Coin)
                    {
                        Mario.Scoreboard.AddCoin();
                    }
                    
                }
                if (!HasItems() && IsVisible) ((BlockActionState)AState).ChangeToUsed();
                _isVisible = true;
            }
        }
        public override void ChangeToStandard()
        {
            ((BlockActionState)AState).ChangeToStandard();
        }
        public override void ChangeToUsed()
        {
            ((BlockActionState)AState).ChangeToUsed();
        }
        public void AddContainedItem(IContainable containedItem)
        {
            _containedItems.Enqueue(containedItem);
        }

        public IContainable PopContainedItem()
        {
            return _containedItems.Dequeue();
        }

        public bool HasItems()
        {
            return _containedItems.Count > 0;
        }
    }
}
