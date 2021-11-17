﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project.Commands;
using Project.Factory;
using Project.HUD;
using Project.Utilities;

namespace Project.GameState
{
    class ItemSelectionState : IGameState
    {
        private Game1 game;
        private KeyboardController keyboardController;
        private IHUD smallHud, bigHUD;

        public ItemSelectionState(Game1 game)
        {
            this.game = game;
            bigHUD = new BigHUD(game); 

            keyboardController = new KeyboardController();
            keyboardController.RegisterCommand(Keys.F, new ItemSelectionCommand(this.game));
            keyboardController.RegisterCommand(Keys.Escape, new PlayGameCommand(this.game));
            keyboardController.RegisterCommand(Keys.B, new GetAItemCommand(this.game));
            keyboardController.RegisterCommand(Keys.G, new GetBItemCommand(game));
            smallHud = new SmallHUD(true);
        }
        public void Update(GameTime gameTime, Rectangle gameRect)
        {
            keyboardController.Update();

            bigHUD.Update();
        /*
            *
             * Update posDot's position 
             *
            switch (RoomManager.Instance.CurrentRoom.RoomID)
            {
                case 1:
                    dotPos = dotPos = new Vector2(482, 472);
                    break;
                case 2:
                    dotPos = new Vector2(513, 408);
                    break;
                case 3:
                    dotPos = new Vector2(513, 472);
                    break;
                case 4:
                    dotPos = new Vector2(513, 504);
                    break;
                case 5:
                    dotPos = new Vector2(513, 569);
                    break;
                case 6:
                    dotPos = new Vector2(544, 408);
                    break;
                case 7:
                    dotPos = new Vector2(544, 441);
                    break;
                case 8:
                    dotPos = new Vector2(544, 472);
                    break;
                case 9:
                    dotPos = new Vector2(544, 504);
                    break;
                case 10:
                    dotPos = new Vector2(544, 536);
                    break;
                case 11:
                    dotPos = new Vector2(544, 569);
                    break;
                case 12:
                    dotPos = new Vector2(575, 472);
                    break;
                case 13:
                    dotPos = new Vector2(575, 504);
                    break;
                case 14:
                    dotPos = new Vector2(575, 569);
                    break;
                case 15:
                    dotPos = new Vector2(606, 441);
                    break;
                case 16:
                    dotPos = new Vector2(606, 472);
                    break;
                case 17:
                    dotPos = new Vector2(640, 441);
                    break;
            }*/
        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            bigHUD.Draw(spriteBatch);
            /*
             * Display big HUD screen
             *
            itemSelectionScreen.Draw(spriteBatch);
            itemSelector.Draw(spriteBatch);
            /*
             * Displays Items in the Selected box 
             *
            if (game.ItemIdx == 0 && player.Inventory.GetItemCount(ItemType.Blue_Boomerang) > 0)
            {
                blueBoomerang.Draw(spriteBatch, itemSelectedPosition);
                Game1.Instance.getItem = ItemType.Blue_Boomerang;
            }

            if (game.ItemIdx == 1 && player.Inventory.GetItemCount(ItemType.Blue_Candle) > 0)
            {
                blueCandle.Draw(spriteBatch, itemSelectedPosition);
                Game1.Instance.getItem = ItemType.Blue_Candle;
            }

            if (game.ItemIdx == 2 && player.Inventory.GetItemCount(ItemType.Bow) > 0)
            {
                bow.Draw(spriteBatch, itemSelectedPosition);
                Game1.Instance.getItem = ItemType.Bow;
            }

            if (game.ItemIdx == 3 && player.Inventory.GetItemCount(ItemType.Boomerang) > 0)
            {
                boomerang.Draw(spriteBatch, itemSelectedPosition);
                Game1.Instance.getItem = ItemType.Boomerang;
            }

            if (game.ItemIdx == 4 && player.Inventory.GetItemCount(ItemType.Sword) > 0)
            {
                sword.Draw(spriteBatch, itemSelectedPosition);
                Game1.Instance.getItem = ItemType.Sword;
            }
           /*
            * Displays Items in the inventory box          
            *
            if (player.Inventory.GetItemCount(ItemType.Bomb) > 0)
                blueBoomerang.Draw(spriteBatch, new Vector2(500, 180));

            if (player.Inventory.GetItemCount(ItemType.Blue_Candle) > 0)
                blueCandle.Draw(spriteBatch, new Vector2(600, 180));

            if (player.Inventory.GetItemCount(ItemType.Bow) > 0)
                bow.Draw(spriteBatch, new Vector2(700, 180));

            if (player.Inventory.GetItemCount(ItemType.Boomerang) > 0)
                boomerang.Draw(spriteBatch, new Vector2(800, 180));

            if (player.Inventory.GetItemCount(ItemType.Sword) > 0)
                sword.Draw(spriteBatch, new Vector2(500, 250));

            if (player.Inventory.GetItemCount(ItemType.Map) > 0)
                map.Draw(spriteBatch, new Vector2(165, 440));

            if (player.Inventory.GetItemCount(ItemType.Compass) > 0)
                compass.Draw(spriteBatch, new Vector2(165, 600));
            /*
             * Display small HUD screen on the bottom
             */
            smallHud.Draw(spriteBatch);
           /*
            * Display orange map
            *
            foreach (var room in game.PassedRoom)
            {
                switch (room)
                {
                    case 1:
                        mapTile1.Draw(spriteBatch, new Vector2(468, 464 + heightOffset), Color.White);
                        break;
                    case 2:
                        mapTile2.Draw(spriteBatch, new Vector2(500, 400 + heightOffset), Color.White);
                        break;
                    case 3:
                        mapTile3.Draw(spriteBatch, new Vector2(500, 464 + heightOffset), Color.White);
                        break;
                    case 4:
                        mapTile4.Draw(spriteBatch, new Vector2(500, 496 + heightOffset), Color.White);
                        break;
                    case 5:
                        mapTile5.Draw(spriteBatch, new Vector2(500, 560 + heightOffset), Color.White);
                        break;
                    case 6:
                        mapTile6.Draw(spriteBatch, new Vector2(532, 400 + heightOffset), Color.White);
                        break;
                    case 7:
                        mapTile7.Draw(spriteBatch, new Vector2(532, 432 + heightOffset), Color.White);
                        break;
                    case 8:
                        mapTile8.Draw(spriteBatch, new Vector2(532, 464 + heightOffset), Color.White);
                        break;
                    case 9:
                        mapTile9.Draw(spriteBatch, new Vector2(532, 496 + heightOffset), Color.White);
                        break;
                    case 10:
                        mapTile10.Draw(spriteBatch, new Vector2(532, 528 + heightOffset), Color.White);
                        break;
                    case 11:
                        mapTile11.Draw(spriteBatch, new Vector2(532, 560 + heightOffset), Color.White);
                        break;
                    case 12:
                        mapTile12.Draw(spriteBatch, new Vector2(564, 464 + heightOffset), Color.White);
                        break;
                    case 13:
                        mapTile13.Draw(spriteBatch, new Vector2(564, 496 + heightOffset), Color.White);
                        break;
                    case 14:
                        mapTile14.Draw(spriteBatch, new Vector2(564, 560 + heightOffset), Color.White);
                        break;
                    case 15:
                        mapTile15.Draw(spriteBatch, new Vector2(596, 432 + heightOffset), Color.White);
                        break;
                    case 16:
                        mapTile16.Draw(spriteBatch, new Vector2(596, 464 + heightOffset), Color.White);
                        break;
                    case 17:
                        mapTile17.Draw(spriteBatch, new Vector2(628, 432 + heightOffset), Color.White);
                        break;
                }
            }
                posDot.Draw(spriteBatch, dotPos, Color.White);*/
        }
    }
}
