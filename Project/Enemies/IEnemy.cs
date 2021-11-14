﻿using Microsoft.Xna.Framework;
using Project.Collision;
using Project.Factory;
using Project.Utilities;

namespace Project
{
    /*
     * Represent an enemy. 
     * Enemy can move and take damage (extends IEntity),
     * has a sprite and position, and can use a weapon
     */
    public interface IEnemy : IEntity, ICollidable
    {
        public Vector2 Position { get; set; }
        public ISprite EnemySprite { get; set; }
        public float Velocity { get; }
        void ChangeDirection(EnemyDirections direction);
        void SetState(IEnemyState state);
        void UseWeapon();
        public void Despawn()
        {
            RoomManager.Instance.CurrentRoom.RemoveEnemy(this);
            SoundFactory.Instance.CreateEnemyDeath();
        }

        public void DropItem (IItems item)
        {
            RoomManager.Instance.CurrentRoom.AddItem(item);
        }
    }
}
