using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Automatumaper.Interfaces;

namespace Automatumaper.Models
{
    public class Camera2D : InputControllable
    {
        protected float _zoom;
        public Matrix _transform;
        public Vector2 _position;
        protected float _rotation;

        public float Zoom
        {
            get { return _zoom; }
            set { _zoom = value; }
        }

        public float Rotation
        {
            get { return _rotation; }
            set { _rotation = value; }
        }

        public void Move(Vector2 amount)
        {
            _position += amount;
        }

        public Vector2 Position
        {
            get { return _position; }
            set { _position = value; }
        }
 
        public Camera2D()
        {
            _zoom = 1.0f;
            _rotation = 0.0f;
            _position = Vector2.Zero;
        }

        public Matrix getTransformation(GraphicsDevice graphicsDevice, int viewportWidth, int viewportHeight)
        {
            _transform =
              Matrix.CreateTranslation(new Vector3(-_position.X, -_position.Y, 0)) *
                                         Matrix.CreateRotationZ(Rotation) *
                                         Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) *
                                         Matrix.CreateTranslation(new Vector3(viewportWidth * 0.5f, viewportHeight * 0.5f, 0));
            return _transform;
        }

        public void OnDownArrowWasPressed()
        {
        }

        public void OnUpArrowWasPressed()
        {
        }

        public void OnRightArrowWasPressed()
        {
        }

        public void OnLeftArrowWasPressed()
        {
        }

        public void OnNoneKeyWasPressed()
        {
        }

        public void OnPageUpWasPressed()
        {
            Zoom += 0.01f;
        }

        public void OnPageDownWasPressed()
        {
            Zoom -= 0.01f;
        }
    }
}
