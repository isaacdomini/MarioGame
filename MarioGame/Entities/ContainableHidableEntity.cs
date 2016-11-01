using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame.Entities
{
    public abstract class ContainableHidableEntity : Entity, IContainable, IHidable
    {
        int _tickCount;
        protected bool revealing { get; private set; }
        public ContainableHidableEntity(Vector2 position, ContentManager content, Action<Entity> addToScriptEntities, float xVelocity = 0, float yVelocity = 0) : base(position, content, addToScriptEntities, xVelocity: xVelocity, yVelocity: yVelocity)
        {
        }
        protected bool _isVisible;

        public bool IsVisible
        {
            get
            {
                return _isVisible;
            }
        }
        
        public abstract void LeaveContainer();
        public void Hide()
        {
            _isVisible = false;
            revealing = false;
        }

        public void Show()
        {
            _tickCount = 10;
            revealing = true;
        }
        public override void Update(Viewport viewport, int elapsedMilliseconds)
        {
            if (IsVisible)
            {
                base.Update(viewport, elapsedMilliseconds);
            }
            else if (_tickCount > 0)
            {
                _tickCount--;
            } else if (_tickCount == 0 && revealing == true)
            {
                _isVisible = true;
                revealing = false;
            }
        }
        public override void OnCollide(IEntity otherObject, Sides ownSide, Sides otherSide)
        {
            if (IsVisible)
            base.OnCollide(otherObject, ownSide, otherSide);
        }
    }
}
