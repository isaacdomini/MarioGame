using MarioGame.Collisions;
using MarioGame.Core;
using MarioGame.Sprites;
using MarioGame.States.EnemyStates;
using MarioGame.States.PlayerStates;
using MarioGame.Theming;
using MarioGame.Theming.Scenes;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarioGame.Entities.EnemyEntities
{
    public class KoopaTroopaEntity : Entity
    {
        public KoopaTroopaSprite eSprite;
        private KoopaActionState eState;
        public readonly static Vector2 idleVelocity = new Vector2(0, 0);
        public readonly static Vector2 movingVelocity = new Vector2(20, 0);

        public KoopaTroopaEntity(Vector2 position, Sprite sprite) : base(position, sprite)
        {
            aState = new WalkingKoopaState(this);
            eSprite = (KoopaTroopaSprite)_sprite;
            int _height = 40;
            int _width = 20;
            boundingBox = new Rectangle((int)_position.X + 3, (int)_position.Y + 5, _width / 2, _height / 3);
            boxColor = Color.Red;

        }

        internal void SetVelocityToMoving()
        {
            this.setVelocity(movingVelocity);
        }

        public void ChangeActionState(ActionState state)
        {
            aState = state;
            aState.setDirection(state.direction);
        }
        public override void Halt()
        {
            _position -= _velocity;
            ((KoopaActionState)aState).Halt();
        }
        public void SetVelocityToIdle()
        {
            this.setVelocity(idleVelocity);
        }
        public override void Update()
        {
            _position += _velocity;
            boundingBox.X = (int)_position.X + 3;
            boundingBox.Y = (int)_position.Y + 5;
        }
        public void ChangeToDeadState()
        {
            eState.ChangeToDead();
        }
    }
}
