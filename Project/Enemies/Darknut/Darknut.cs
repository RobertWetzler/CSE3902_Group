﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Collision;
using Project.Entities;
using Project.Projectiles;
using Project.Utilities;

namespace Project
{
    class Darknut : IEnemy
    {
        private int timeToSpawn;
        private int startTime;
        private IEnemyState currentState;
        private ISprite sprite;
        private float velocity;
        private EnemyMovement movement;
        private Facing facingDirection;
        private Vector2 position;
        private Health health;

        public Facing FacingDirection { get => facingDirection; set => facingDirection = value; }
        public ISprite EnemySprite { get => this.sprite; set => this.sprite = value; }
        public float Velocity { get => this.velocity; }
        public Vector2 Position { get => position; set => position = value; }
        public Rectangle BoundingBox => sprite.DestRectangle;
        public CollisionType CollisionType => CollisionType.Darknut;
        public Health Health { get => health; }

        public Darknut(Vector2 position)
        {
            this.position = position;
            this.velocity = 50f;
            this.facingDirection = Facing.Right;
            startTime = 0;
            timeToSpawn = 600;
            movement = new EnemyMovement(this);
            currentState = new EnemySpawning(this);
            health = new Health(4);
        }
        public void ChangeDirection(EnemyDirections direction)
        {
            facingDirection = EnemyUtilities.GetFacingFromEnemyDirection(direction);
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
                    switch (this.facingDirection)
                    {
                        case Facing.Down:
                            currentState = new DarknutWalkSouth(this);
                            break;
                        case Facing.Left:
                            currentState = new DarknutWalkWest(this);
                            break;
                        case Facing.Right:
                            currentState = new DarknutWalkEast(this);
                            break;
                        case Facing.Up:
                            currentState = new DarknutWalkNorth(this);
                            break;
                    }
                }
            }
            movement.MoveWASDOnly(windowBounds, gameTime);
            currentState.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, Color color)
        {
            sprite.Draw(spriteBatch, position);
        }
    }
}