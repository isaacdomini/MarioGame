﻿using System;
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
    public abstract class ContainableHidableEntity : HidableEntity, IContainable
    {
        int _tickCount;
        protected bool Revealing { get; private set; }

        internal ContainableHidableEntity(Vector2 position, ContentManager content, Action<Entity> addToScriptEntities) : base(position, content, addToScriptEntities)
        {
        }
        public abstract void LeaveContainer();
        public override void Hide()
        {
            base.Hide();
            Revealing = false;
        }

        public override void Show()
        {
            _tickCount = 10;
            Revealing = true;
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
            } else if (_tickCount == 0 && Revealing == true)
            {
                _isVisible = true;
                Revealing = false;
            }
        }
        public override void OnCollide(IEntity otherObject, Sides ownSide, Sides otherSide)
        {
            if (IsVisible)
            base.OnCollide(otherObject, ownSide, otherSide);
        }
    }
}
