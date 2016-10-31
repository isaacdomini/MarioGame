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
        public BumpableContainerBlock(Vector2 position, ContentManager content) : base(position, content)
        {
            _tickCount = 0;

        }
        public override void Update(Viewport viewport, GameTime gameTime)
        {
            base.Update(viewport, gameTime);
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
            if (AState is UsedBlockState)
            {
                return;
            }
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
                // TODO: Make poppedItem appear and pop out
            }
            else
            {
                ((BlockActionState)AState).ChangeToUsed();
            }
            _isVisible = true;

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
