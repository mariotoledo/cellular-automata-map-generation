using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automatumaper.Interfaces
{
    public interface InputControllable
    {
        void OnDownArrowWasPressed();
        void OnUpArrowWasPressed();
        void OnRightArrowWasPressed();
        void OnLeftArrowWasPressed();
        void OnNoneKeyWasPressed();
        void OnPageUpWasPressed();
        void OnPageDownWasPressed();
    }
}
