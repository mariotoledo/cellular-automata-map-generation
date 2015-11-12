using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automatumaper
{
    public class Settings
    {
        public static int FPS = 60;
        public static int NUMBER_OF_FRAMES_PER_SHEET = 4;

        public static int WINDOW_WIDTH = 640;
        public static int WINDOW_HEIGHT = 480;

        public static int TILE_WIDTH = 64;
        public static int TILE_HEIGHT = 64;

        public static float AUTOMATA_CHANCE_TO_STAY_ALIVE = 0.45f;
        public static int AUTOMATA_NUMBER_OF_ALIVE_NEIGHBORS_ALLOWED = 3;
        public static int AUTOMATA_NUMBER_OF_DEAD_NEIGHBORS_ALLOWED = 3;
        public static int GAME_OF_LIFE_NUMBER_OF_STEPS = 6;
    }
}
