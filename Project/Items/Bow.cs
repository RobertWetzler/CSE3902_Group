﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Factory;
using Project.Sprites.ItemSprites;

namespace Project.Items
{
    class Bow : IItem
    {

        private ISprite sprite;
        private Vector2 position;
        public Rectangle BoundingBox => sprite.DestRectangle;

        public Bow(Vector2 position)
        {
            this.position = position;
            sprite = ItemSpriteFactory.Instance.CreateItemSprite(0, 7);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch, this.position);
        }

        public void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
        }
    }
}
