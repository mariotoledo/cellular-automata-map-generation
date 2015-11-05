using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automatumaper.Models;
using Automatumaper.Interfaces;
using System.Diagnostics;

namespace Automatumaper.Controllers
{
    public class PhisicsController
    {
        Map map;

        public PhisicsController(Map map)
        {
            this.map = map;
        }

        public bool IsObjectAbleToMove(XNAGameObject xnaObject, XNAGameObjectDirection direction)
        {
            /*int predictableX = Convert.ToInt32(xnaObject.GetPositon().X / Settings.TILE_WIDTH) + 0;
            int predictableY = Convert.ToInt32(xnaObject.GetPositon().Y / Settings.TILE_HEIGHT) + 0;
            Tile predictTile = null;

            Tile currentTile = null;

            foreach (Tile tile in map.Tiles)
            {
                if (xnaObject.GetCenter().X >= tile.Frame.X &&
                    xnaObject.GetCenter().X <= tile.Frame.X + tile.Frame.Width &&
                    xnaObject.GetCenter().Y >= tile.Frame.Y &&
                    xnaObject.GetCenter().Y <= tile.Frame.Y + tile.Frame.Height)
                {
                    currentTile = tile;
                    break;
                }
            }

            if (currentTile != null)
            {
                if (direction == XNAGameObjectDirection.Down)
                {
                    predictTile = map.Tiles[(int)currentTile.MapPosition.X, (int)currentTile.MapPosition.Y + 1];
                }
                else if (direction == XNAGameObjectDirection.Up)
                {
                    predictTile = map.Tiles[(int)currentTile.MapPosition.X, (int)currentTile.MapPosition.Y - 1];
                }
                else if (direction == XNAGameObjectDirection.Left)
                {
                    predictTile = map.Tiles[(int)currentTile.MapPosition.X - 1, (int)currentTile.MapPosition.Y];
                }
                else if (direction == XNAGameObjectDirection.Right)
                {
                    predictTile = map.Tiles[(int)currentTile.MapPosition.X + 1, (int)currentTile.MapPosition.Y];
                }
            }

            if(predictTile != null)
                Debug.WriteLine("X: " + predictTile.Frame.X + " Y:" + predictTile.Frame.Y + " isWalkable: " + predictTile.IsWalkable);

            return predictTile != null && predictTile.IsWalkable;*/

            return true;
        }
    }
}
