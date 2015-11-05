using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automatumaper.Interfaces;
using Microsoft.Xna.Framework.Input;

namespace Automatumaper.Controllers
{
    public class InputController
    {
        private static InputController _instance;
        public static InputController Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new InputController();
                }

                return _instance;
            }
        }

        private InputController()
        {
            controllables = new List<InputControllable>();
            lastKeyboardState = new KeyboardState();
        }

        private List<InputControllable> controllables;

        public void AddControllable(InputControllable controllable)
        {
            controllables.Add(controllable);
        }

        public void RemoveControllable(InputControllable controllable)
        {
            controllables.Remove(controllable);
        }

        private KeyboardState lastKeyboardState;

        public void Update(KeyboardState currentKeybordState){
            if (currentKeybordState.IsKeyDown(Keys.Down))
            {
                foreach (InputControllable controllable in controllables)
                {
                    controllable.OnDownArrowWasPressed();
                }
            }
            else if (currentKeybordState.IsKeyDown(Keys.Left))
            {
                foreach (InputControllable controllable in controllables)
                {
                    controllable.OnLeftArrowWasPressed();
                }
            }
            else if (currentKeybordState.IsKeyDown(Keys.Up))
            {
                foreach (InputControllable controllable in controllables)
                {
                    controllable.OnUpArrowWasPressed();
                }
            }
            else if (currentKeybordState.IsKeyDown(Keys.Right))
            {
                foreach (InputControllable controllable in controllables)
                {
                    controllable.OnRightArrowWasPressed();
                }
            }
            else
            {
                foreach (InputControllable controllable in controllables)
                {
                    controllable.OnNoneKeyWasPressed();
                }
            }
                
            lastKeyboardState = currentKeybordState;
        }
    }
}
