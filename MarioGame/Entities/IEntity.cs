﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MarioGame.States;
using Microsoft.Xna.Framework.Graphics;

namespace MarioGame.Entities
{
    public interface IEntity
    {
        void Update(Viewport viewport);
        void ChangeActionState(ActionState newstate);

        Vector2 Position { get; }

    }
}
