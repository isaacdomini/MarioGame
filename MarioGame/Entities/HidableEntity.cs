using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace MarioGame.Entities
{
    public class HidableEntity : Entity, IHidable
    {
        protected bool _isVisible;
        public bool IsVisible => _isVisible;
        protected bool _isOnCurrentScreen;
        public bool OnCurrentScreen => _isOnCurrentScreen;

        public HidableEntity(Vector2 position, ContentManager content, Action<Entity> addToScriptEntities, float xVelocity = 0, float yVelocity = 0) : base(position, content, addToScriptEntities, xVelocity, yVelocity)
        {
        }

        public virtual void Hide()
        {
            _isVisible = false;
        }

        public virtual void OffScreen()
        {
            _isOnCurrentScreen = false;
        }

        public virtual void OnScreen()
        {
            _isOnCurrentScreen = true;
        }

        public virtual void Show()
        {
            _isVisible = true;
        }
    }
}