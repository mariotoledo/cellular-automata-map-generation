using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Automatumaper.Models
{
    public abstract class XNAGameObject
    {
        public Texture2D texture;
        public Rectangle frame;
        public Vector2 position;

        public XNAGameObject(Rectangle frame, Vector2 position)
        {
            this.frame = frame;
            this.position = position;
        }

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime);
        public abstract Vector2 GetPositon();
    }
}
