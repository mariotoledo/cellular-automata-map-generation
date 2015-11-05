using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Automatumaper.Models
{
    public class Map
    {
        public Tile starterTile { get; set; }

        private int[,] map = {
          {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
          {0, 0, 2, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
          {0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
          {0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
          {0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0,},
          {0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0,},
          {0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0,},
          {0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0,},
          {0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0,},
          {0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0,},
          {0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0,},
          {0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 9, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0,},
          {0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0,},
          {0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0,},
          {0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0,},
          {0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0,},
          {0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0,},
          {0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0,},
          {0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0,},
          {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
          {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},
          {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0,},};

        public Tile[,] Tiles { get; private set; }

        public Map(ContentManager contentManager)
        {
            Tiles = new Tile[map.GetLength(1), map.GetLength(0)];

            for (int y = 0; y < map.GetLength(0); y++)
            {
                for (int x = 0; x < map.GetLength(1); x++)
                {
                    Tile tile = new Tile()
                    {
                        Frame = new Rectangle(x * Settings.TILE_WIDTH, y * Settings.TILE_HEIGHT, Settings.TILE_WIDTH, Settings.TILE_HEIGHT),
                        IsWalkable = map[y, x] == 0 || map[y, x] == 2,
                        Texture = contentManager.Load<Texture2D>(map[y, x] == 0 || map[y, x] == 2  ? "tile1" : "tile2"),
                        MapPosition = new Vector2(x, y)
                    };

                    if (map[y, x] == 2)
                        starterTile = tile;

                    Tiles[x, y] = tile;
                }
            }

            for (int x = 0; x < Tiles.GetLength(0); x++)
            {
                for (int y = 0; y < Tiles.GetLength(1); y++)
                {
                    Tile tile = Tiles[x, y];

                    if (tile != null)
                    {
                        if (y > 0 && Tiles[x, y - 1] != null)
                            tile.NearbyTiles.Add(XNAGameObjectDirection.Up, Tiles[x, y - 1]);

                        if (x > 0 && Tiles[x - 1, y] != null)
                            tile.NearbyTiles.Add(XNAGameObjectDirection.Left, Tiles[x - 1, y]);

                        if (x + 1 < Tiles.GetLength(0) && Tiles[x + 1, y] != null)
                            tile.NearbyTiles.Add(XNAGameObjectDirection.Right, Tiles[x + 1, y]);

                        if (y + 1 < Tiles.GetLength(1) && Tiles[x, y + 1] != null)
                            tile.NearbyTiles.Add(XNAGameObjectDirection.Down, Tiles[x, y + 1]);
                    }
                }
            }
        }
    }
}
