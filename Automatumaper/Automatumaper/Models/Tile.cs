using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Automatumaper.Models
{
    public class Tile
    {
        public Vector2 MapPosition { get; set; }

        public Texture2D Texture { get; set; }
        public Rectangle Frame {get; set;}
        public bool IsWalkable { get; set; }

        public Dictionary<XNAGameObjectDirection, Tile> NearbyTiles { get; set; }

        public Tile()
        {
            NearbyTiles = new Dictionary<XNAGameObjectDirection, Tile>();
        }
    }
}
