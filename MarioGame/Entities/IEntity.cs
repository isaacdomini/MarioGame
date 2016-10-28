using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MarioGame.States;
using Microsoft.Xna.Framework.Graphics;
using MarioGame.Sprites;

namespace MarioGame.Entities
{
    public interface IEntity 
    {
        void Update(Viewport viewport, GameTime gameTime);
        void ChangeActionState(ActionState newstate);
        Vector2 Position { get; }
        ActionState CurrentActionState { get; }
        AnimatedSprite Sprite { get; }

    }
}
