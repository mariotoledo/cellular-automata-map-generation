using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Automatumaper.Interfaces;

namespace Automatumaper.Models
{
    public class Hero : XNAGameObject, InputControllable
    {
        private XNAGameObjectDirection direction;
        private Tile currentTile;
        private Tile desiredTile;

        bool isMoving;

        public Hero(int frameWidth, int frameHeight, Tile initialTile)
            : base(new Rectangle(0, 0, frameWidth, frameHeight), new Vector2((int)initialTile.Frame.X, (int)initialTile.Frame.Y))
        {
            isMoving = false;
            currentTile = initialTile;
        }

        int timeSizeLastFrame = 0;
        public override void Update(GameTime gameTime)
        {
            timeSizeLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            if (isMoving)
            {
                if (timeSizeLastFrame > Settings.FPS)
                {
                    timeSizeLastFrame = 0;
                    this.frame.X += this.frame.Width;
                    if (this.frame.X >= this.frame.Width * Settings.NUMBER_OF_FRAMES_PER_SHEET)
                    {
                        this.frame.X = 0;
                    }
                }

                if (position.X == desiredTile.Frame.X && position.Y == desiredTile.Frame.Y)
                {
                    currentTile = desiredTile;
                    isMoving = false;
                }
                else
                {
                    if (position.Y != desiredTile.Frame.Y)
                    {
                        if (direction == XNAGameObjectDirection.Up)
                        {
                            position.Y--;
                        }

                        if (direction == XNAGameObjectDirection.Down)
                        {
                            position.Y++;
                        }
                    }

                    if (position.X != desiredTile.Frame.X)
                    {
                        if (direction == XNAGameObjectDirection.Left)
                        {
                            position.X--;
                        }

                        if (direction == XNAGameObjectDirection.Right)
                        {
                            position.X++;
                        }
                    }
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(texture, position, frame, Color.White);
        }

        public void OnDownArrowWasPressed()
        {
            if(!isMoving) {
                direction = XNAGameObjectDirection.Down;
                desiredTile = currentTile.NearbyTiles[direction];

                if (desiredTile.IsWalkable)
                {
                    frame.Y = 0;
                    isMoving = true;
                }
            }
        }

        public void OnUpArrowWasPressed()
        {
            if (!isMoving)
            {
                direction = XNAGameObjectDirection.Up;
                desiredTile = currentTile.NearbyTiles[direction];

                if (desiredTile.IsWalkable)
                {
                    frame.Y = frame.Height * 3;
                    isMoving = true;
                }
            }
        }

        public void OnRightArrowWasPressed()
        {
            if (!isMoving)
            {
                direction = XNAGameObjectDirection.Right;
                desiredTile = currentTile.NearbyTiles[direction];

                if (desiredTile.IsWalkable)
                {
                    frame.Y = frame.Height * 2;
                    isMoving = true;
                }
            }
        }

        public void OnLeftArrowWasPressed()
        {
            if (!isMoving)
            {
                direction = XNAGameObjectDirection.Left;
                desiredTile = currentTile.NearbyTiles[direction];

                if (desiredTile.IsWalkable)
                {
                    frame.Y = frame.Height;
                    isMoving = true;
                }
            }
        }

        public void OnNoneKeyWasPressed()
        {
            
        }

        public override Vector2 GetPositon()
        {
            return position;
        }
    }
}
