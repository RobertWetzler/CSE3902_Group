﻿using Microsoft.Xna.Framework;
using Project.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Project.NPC;
using Project.Items;
using Project.Collision.CollisionHandlers;
using Project.Sprites.BlockSprites;
using Project.Blocks;
using Project.Projectiles;

namespace Project.Collision
{
    class AllCollisionHandler
    {
        private Dictionary<Tuple<Type, Type>, ICollisionHandler> commandMap;
        public AllCollisionHandler()
        {
            commandMap = new Dictionary<Tuple<Type, Type>, ICollisionHandler>();
            BuildDictionary();
        }

        private void BuildDictionary()
        {
            Type playerType = typeof(GreenLink);

            //Enemy Types
            Type batType = typeof(Bat);
            Type bossType = typeof(Dragon);
            Type gelType = typeof(SmallJelly);
            Type goriyaType = typeof(Goriya);
            Type skeletonType = typeof(Skeleton);
            Type[] enemyTypes = { batType, bossType, gelType, goriyaType, skeletonType };

            // Projectile Types
            Type[] projectileTypes = { typeof(Arrow), typeof(BlueArrow), typeof(BlueBoomerang), typeof(Boomerang), 
                typeof(Bomb), typeof(Flame), typeof(Sword)};

            //Block Types
            Type[] blockTypes = { typeof(BlackBlock), typeof(BlueBlock), typeof(BrickBlock), 
            typeof(DottedBlock), typeof(LayeredBlock), typeof(LeftFacingDragonBlock), typeof(MoveableBlock), 
            typeof(PlainBlock), typeof(PyramidBlock), typeof(Rectangle1), typeof(Rectangle2), typeof(RightFacingDragonBlock)};
            foreach (Type blockType in blockTypes)
            {
                commandMap.Add(new Tuple<Type, Type>(playerType, blockType), new PlayerBlockCollisionHandler());
            }
            
            foreach (Type enemyType in enemyTypes)
            {
                commandMap.Add(new Tuple<Type, Type>(playerType, enemyType), new PlayerEnemyCollisionHandler());
            }

            foreach (Type projectileType in projectileTypes)
            {
                commandMap.Add(new Tuple<Type, Type>(playerType, projectileType), new PlayerProjectileCollisionHandler());
                commandMap.Add(new Tuple<Type, Type>(projectileType, playerType), new ProjectileAnyCollisionHandler());
                foreach (Type enemyType in enemyTypes)
                {
                    commandMap.Add(new Tuple<Type, Type>(projectileType, enemyType), new ProjectileAnyCollisionHandler());
                }
                foreach (Type blockType in blockTypes)
                {
                    commandMap.Add(new Tuple<Type, Type>(projectileType, blockType), new ProjectileAnyCollisionHandler());
                }
            }
        }


        public void HandleCollision(ICollidable subject, ICollidable target, CollisionSide side)
        {
            Tuple<Type, Type> key = new Tuple<Type, Type>(subject.GetType(), target.GetType());
            if (commandMap.ContainsKey(key))
            {
                ICollisionHandler handler = commandMap[key];
                handler.HandleCollision(subject, target, side);
            }
        }
    }
}