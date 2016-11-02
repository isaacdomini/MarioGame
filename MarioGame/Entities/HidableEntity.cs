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
        private bool _IsVisible;
        protected bool _isVisible { get { return _IsVisible; }set { _IsVisible = value; } }
        public bool IsVisible => _isVisible;
        private bool _isOnCurrentScreen;
        protected bool IsOnCurrentScreen { get { return _isOnCurrentScreen; } set { _isOnCurrentScreen = value; } }
        public bool OnCurrentScreen => _isOnCurrentScreen;

        public HidableEntity(Vector2 position, ContentManager content, Action<Entity> addToScriptEntities) : base(position, content, addToScriptEntities)
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