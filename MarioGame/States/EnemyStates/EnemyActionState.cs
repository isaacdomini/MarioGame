using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarioGame.Entities;
using MarioGame.Core;

namespace MarioGame.States
{
    public class EnemyActionState : ActionState
    {
        public static int deadGoomba=1;
        public static int deadKoopa = 1;
        public EnemyActionState(IEntity entity) : base(entity)
        {
        }
        public override void Begin(IState prevState)
        {
            base.Begin(prevState);
        }
        public virtual void HitBlock()
        {
            ((Entity)Entity).FlipHorizontalVelocity();
        }
        public virtual void Halt()
        {
            ChangeToDead();
        }
        public virtual void JumpedOn(Sides side)
        {
            if (deadGoomba == 1 || deadKoopa ==1)
            {
                Mario.Scoreboard.AddPoint(200);
                deadGoomba = 0;
                deadKoopa = 0;
            }
            ChangeToDead();
        }
        public virtual void ChangeToDead() { }
    }
}
