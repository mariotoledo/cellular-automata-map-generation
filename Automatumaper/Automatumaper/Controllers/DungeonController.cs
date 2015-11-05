using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automatumaper.Models;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Automatumaper.Interfaces;

namespace Automatumaper.Controllers
{
    public class DungeonController 
    {
        Map map;
        Hero hero;

        public DungeonController(Map map, Hero hero)
        {
            this.map = map;
            this.hero = hero;
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            foreach (Tile tile in map.Tiles)
            {
                spriteBatch.Draw(tile.Texture, tile.Frame, Color.White);
                hero.Draw(spriteBatch, gameTime);
            }
        }
    }
}
