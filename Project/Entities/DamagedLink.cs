﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Sound;
using Project.Utilities;
using System;
using System.Collections.Generic;

namespace Project.Entities
{
    public class DamagedLink : PlayerDecorator
    {
        private double totalFlashTime = 1000;
        private double totalKnockbackTime = 100;
        private double remainingFlashTime;
        private double remainingKnockbackTime;
        private double knockbackVelocity = 300;
        private Color color;
        public DamagedLink(IPlayer decoratedPlayer, Game1 game)
        {
            // inherited from PlayerDecorator
            this.decoratedPlayer = decoratedPlayer;
            this.game = game;
            remainingFlashTime = totalFlashTime;
            remainingKnockbackTime = totalKnockbackTime;
            SoundManager.Instance.CreateLinkHurtSound();
            lightScale = 1.5f;
            lightIntensity = 0.7f;
        }
        public override void TakeDamage(int damage)
        {
            // No damage is taken
        }

        public override void Update(Rectangle windowBounds, GameTime gameTime)
        {
            remainingFlashTime -= (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            remainingKnockbackTime -= (int)gameTime.ElapsedGameTime.TotalMilliseconds;

            // Update color if timer is still running
            if (remainingFlashTime > 0)
            {
                UpdateColor();
                this.lightColor = color;
            }
            // Update knockback position if timer is still runnning, else do normal update
            if (remainingKnockbackTime > 0)
            {
                UpdateKnockback(gameTime, windowBounds);
            }
            else
            {
                this.decoratedPlayer.Update(windowBounds, gameTime);
            }
            // If both timers depleted, remove decorator
            if (Math.Max(remainingFlashTime, remainingKnockbackTime) <= 0)
            {
                RemoveDecorator();
            }
        }
        private void UpdateColor()
        {
            List<float> hues = new List<float>() { 140f, 180f, 260f, 340f };
            double t = totalFlashTime - remainingFlashTime;
            int i = (int)(t / totalFlashTime * hues.Count * 10) % hues.Count; // cycle through list
            color = ColorUtils.HSVToRGB(hues[i], 1, 1);
        }
        private void UpdateKnockback(GameTime gameTime, Rectangle windowBounds)
        {
            int x_dir = 0, y_dir = 0;
            switch (this.decoratedPlayer.StateMachine.facing)
            {
                case Facing.Left:
                    x_dir = 1;
                    break;
                case Facing.Right:
                    x_dir = -1;
                    break;
                case Facing.Up:
                    y_dir = 1;
                    break;
                case Facing.Down:
                    y_dir = -1;
                    break;
            }
            float newX = this.decoratedPlayer.Position.X + (float)(x_dir * gameTime.ElapsedGameTime.TotalSeconds * knockbackVelocity);
            float newY = this.decoratedPlayer.Position.Y + (float)(y_dir * gameTime.ElapsedGameTime.TotalSeconds * knockbackVelocity);
            if (x_dir == 1)
            {
                newX = (int)(newX + decoratedPlayer.BoundingBox.Width) < windowBounds.Right ? newX : windowBounds.Right - (decoratedPlayer.BoundingBox.Width);
            }
            else if (x_dir == -1)
            {
                newX = (int)newX > windowBounds.Left ? newX : windowBounds.Left;
            }
            else if (y_dir == 1)
            {
                newY = (int)(newY + decoratedPlayer.BoundingBox.Height) < windowBounds.Bottom ? newY : windowBounds.Bottom - (decoratedPlayer.BoundingBox.Height);
            }
            else
            {
                newY = (int)(newY) > windowBounds.Top ? newY : windowBounds.Top;
            }
            this.decoratedPlayer.Position = new Vector2(newX, newY);

        }
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            this.decoratedPlayer.Draw(spriteBatch, gameTime, color);
        }
        // If move during knockback, stop knockback (similar to real game)
        public override void MoveUp()
        {
            remainingKnockbackTime = 0;
            base.MoveUp();
        }
        public override void MoveDown()
        {
            remainingKnockbackTime = 0;
            base.MoveDown();
        }
        public override void MoveLeft()
        {
            remainingKnockbackTime = 0;
            base.MoveLeft();
        }
        public override void MoveRight()
        {
            remainingKnockbackTime = 0;
            base.MoveRight();
        }
        // only allow weapon after knockback (change later if not desired behavior)
        public override void UseWeapon(WeaponTypes weaponType)
        {
            if (remainingKnockbackTime <= 0)
            {
                base.UseWeapon(weaponType);
            }
        }
    }
}
