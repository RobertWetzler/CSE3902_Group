﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;

namespace Project
{
    class WallMaster : IEnemy
    {
        private const int timeToSpawn = 600;
        private const int timeToDespawn = 200;
        private int startTime;
        private int endTime;
        private IEnemyState currentState;
        private Vector2 pos;
        private ISprite sprite;
        private float velocity;
        private EnemyMovement movement;
        private Health health;
        private bool isFinished = false;

        public ISprite EnemySprite { get => this.sprite; set => this.sprite = value; }
        public float Velocity { get => this.velocity; }
        public Vector2 Position { get => pos; set => pos = value; }
        public Rectangle BoundingBox => sprite.DestRectangle;
        public CollisionType CollisionType => CollisionType.Enemy;
        public Health Health { get => health; }

        public bool IsFinished => isFinished;

        public WallMaster(Vector2 pos)
        {
            this.pos = pos;
            this.velocity = 50f;
            startTime = 0;
            movement = new EnemyMovement(this);
            currentState = new EnemySpawning(this);
            health = new Health(2);
        }

        public void ChangeDirection(EnemyDirections direction)
        {
            currentState.ChangeDirection(direction);
        }

        public void UseWeapon()
        {
            //No weapon
        }

        public void SetState(IEnemyState state)
        {
            currentState = state;
        }

        public void TakeDamage(int damage)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Rectangle windowBounds, GameTime gameTime)
        {
            sprite.Update(gameTime);
            if (currentState is EnemySpawning)
            {
                startTime += gameTime.ElapsedGameTime.Milliseconds;
                if (startTime > timeToSpawn)
                {
                    currentState = new WallMasterWalkEast(this);
                }
            }

            if(currentState is EnemyDespawning)
            {
                endTime += gameTime.ElapsedGameTime.Milliseconds;
                if(endTime > timeToDespawn)
                {
                    isFinished = true;
                }
            }

            movement.MoveWASDOnly(windowBounds, gameTime);
            currentState.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, Color color)
        {
            sprite.Draw(spriteBatch, pos);
        }
    }

}