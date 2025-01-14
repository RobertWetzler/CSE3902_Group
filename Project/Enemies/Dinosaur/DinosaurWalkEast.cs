﻿using Microsoft.Xna.Framework;
using Project.Factory;

namespace Project
{
    class DinosaurWalkEast : IEnemyState
    {

        private Dinosaur dinosaur;

        public DinosaurWalkEast(Dinosaur dinosaur)
        {
            this.dinosaur = dinosaur;
            this.dinosaur.EnemySprite = EnemySpriteFactory.Instance.CreateDinosaurWalkRightSprite();
        }

        public void ChangeDirection(EnemyDirections direction)
        {
            switch (direction)
            {
                case EnemyDirections.South:
                    dinosaur.SetState(new DinosaurWalkSouth(dinosaur));
                    break;
                case EnemyDirections.North:
                    dinosaur.SetState(new DinosaurWalkNorth(dinosaur));
                    break;
                case EnemyDirections.West:
                    dinosaur.SetState(new DinosaurWalkWest(dinosaur));
                    break;
            }
        }

        public void Update(GameTime gameTime)
        {
            dinosaur.Position = new Vector2((float)(gameTime.ElapsedGameTime.TotalSeconds * dinosaur.Velocity) + dinosaur.Position.X,
                                            dinosaur.Position.Y);
        }

        public void UseWeapon()
        {

        }
    }
}