﻿using Microsoft.Xna.Framework;

namespace Project
{
    class TrapStill : IEnemyState
    {
        private Trap trap;

        public TrapStill(Trap trap)
        {
            this.trap = trap;
        }

        public void ChangeDirection(EnemyDirections direction)
        {
            switch (direction)
            {
                case EnemyDirections.West:
                    trap.SetState(new TrapMoveLeft(trap));
                    break;
                case EnemyDirections.South:
                    trap.SetState(new TrapMoveDown(trap));
                    break;
                case EnemyDirections.East:
                    trap.SetState(new TrapMoveRight(trap));
                    break;
                case EnemyDirections.North:
                    trap.SetState(new TrapMoveUp(trap));
                    break;
            }
        }

        public void Update(GameTime gameTime)
        {
            //no animation or movement
        }

        public void UseWeapon()
        {
            //No weapon
        }
    }
}
