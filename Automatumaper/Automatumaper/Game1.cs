using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Automatumaper.Controllers;
using Automatumaper.Models;

namespace Automatumaper
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Camera2D camera;
        Hero hero;
        Map map;

        DungeonController dungeonController;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            map = new Map(this.Content);

            hero = new Hero(Settings.TILE_WIDTH, Settings.TILE_HEIGHT, map.starterTile);
            dungeonController = new DungeonController(map, hero);

            camera = new Camera2D();

            InputController.Instance.AddControllable(hero);
            InputController.Instance.AddControllable(camera);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            hero.texture = this.Content.Load<Texture2D>("hero");
        }

        protected override void UnloadContent()
        {
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            InputController.Instance.Update(Keyboard.GetState());

            hero.Update(gameTime);
            camera.Position = hero.position;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.BackToFront,
                        BlendState.AlphaBlend,
                        null,
                        null,
                        null,
                        null,
                        camera.getTransformation(graphics.GraphicsDevice,
                        graphics.GraphicsDevice.Viewport.Width,
                        graphics.GraphicsDevice.Viewport.Height));
            dungeonController.Draw(spriteBatch, gameTime);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
