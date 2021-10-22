﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Project.Entities;
using Project.Factory;
using Project.Sprites.BlockSprites;
using Project.Sprites.ItemSprites;
using Project.Utilities;
using System;
using System.Collections.Generic;

namespace Project
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private IPlayer player;
        public IPlayer Player { get => player; set => player = value; }
        private List<IController> controllers;

        //List of sprites to cycle thru
        private List<IItems> items;
        private List<ISprite> blocks;
        private List<INPC> npcsList;
        private IEnemy enemy;
        private List<IEnemy> enemies;
        private List<INPC> npcs;
        private List<(IItems, Vector2)> itemAndPos;

        public int ItemsListLength => items.Count;
        public int BlocksListLength => blocks.Count;
        public int NPCSListLength => npcsList.Count;
        public int CurrentBlockSpriteIndex { get; set; }
        public int CurrentItemIndex { get; set; }
        public int CurrentNPCIndex { get; set; }

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            controllers = new List<IController>();
            Utilities.Sprint2Utilities.SetKeyboardControllers(controllers, this);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //Load Link Sprites
            LinkSpriteFactory.Instance.LoadAllTextures(Content);
            player = new GreenLink(this); // must be done AFTER LinkSpriteFactory load

            //Load block sprites
            BlockSpriteFactory.Instance.LoadAllTextures(Content);

            //Load item sprites
            ItemSpriteFactory.Instance.LoadAllTextures(Content);

            //Load NPC sprites
            NPCSpriteFactory.Instance.LoadAllTextures(Content);

            //Load Enemy sprites
            EnemySpriteFactory.Instance.LoadAllTextures(Content);

            //Set List for blocks, items, and NPCs
            blocks = new List<ISprite>();
            Utilities.Sprint2Utilities.SetBlockList(blocks);
            CurrentBlockSpriteIndex = 0;

            items = new List<IItems>();
            Utilities.Sprint2Utilities.SetItemList(items);
            CurrentItemIndex = 0;

            npcsList = new List<INPC>();
            Utilities.Sprint2Utilities.SetNPCList(npcsList);
            CurrentNPCIndex = 0;

            Vector2 pos = new Vector2(400, 100);
            enemy = new WallMaster(pos);

            enemies = XMLParser.instance.GetEnemiesFromRoom("Room3");
            npcs = XMLParser.instance.GetNPCSFromRoom("Room1");
            itemAndPos = XMLParser.instance.GetItemsFromRoom("Room5");
        }

        protected override void Update(GameTime gameTime)
        {

            foreach (IController controller in controllers)
            {
                controller.Update();
            }
            foreach (IEnemy n in enemies)
            {
                n.Update(_graphics.GraphicsDevice.Viewport.Bounds, gameTime);
            }
            foreach (INPC n in npcs)
            {
                n.Update(gameTime);
            }
            foreach (var i in itemAndPos)
            {
                i.Item1.Update(gameTime);
            }

            npcsList[CurrentNPCIndex].Update(gameTime);
            enemy.Update(new Rectangle(200, 50, 400, 200), gameTime);

            items[CurrentItemIndex].Update(gameTime);

            player.Update(_graphics.GraphicsDevice.Viewport.Bounds, gameTime);
   
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Tan);

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp); // PointClamp fixes sprite blurriness
            blocks[CurrentBlockSpriteIndex].Draw(_spriteBatch, new Vector2(200, 100));
            player.Draw(_spriteBatch, gameTime);

            items[CurrentItemIndex].Draw(_spriteBatch, new Vector2(200, 300));
            npcsList[CurrentNPCIndex].Draw(_spriteBatch);
            enemy.Draw(_spriteBatch, gameTime);
            foreach (IEnemy n in enemies)
            {
                n.Draw(_spriteBatch, gameTime);
            }
            foreach (INPC n in npcs)
            {
                n.Draw(_spriteBatch);
            }
            foreach (var i in itemAndPos)
            {
                i.Item1.Draw(_spriteBatch, i.Item2);
            }
            _spriteBatch.End();

            base.Draw(gameTime);
        }


    }
}
