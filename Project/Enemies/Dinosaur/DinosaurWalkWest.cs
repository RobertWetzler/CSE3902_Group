﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;

namespace Project
{
    class DinosaurWalkWest : IEnemyState
    {

        private Dinosaur dinosaur;



        public DinosaurWalkWest(Dinosaur dinosaur)
        {
            this.dinosaur = dinosaur;
            this.dinosaur.EnemySprite = EnemySpriteFactory.Instance.CreateDinosaurLeftRightSprite();

        }

        public void ChangeDirection(EnemyDirections direction)
        {
            switch (direction)
            {
                case EnemyDirections.East:
                    dinosaur.SetState(new DinosaurWalkEast(dinosaur));
                    break;
            }
        }

        public void Update(GameTime gametime)
        {
            dinosaur.Position = new Vector2((float)(-1 * gametime.ElapsedGameTime.TotalSeconds * dinosaur.Velocity) + dinosaur.Position.X,
                                            dinosaur.Position.Y);
        }

        public void UseWeapon()
        {

        }
    }
}