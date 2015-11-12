using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automatumaper.Helpers
{
    public class GameOfLifeHelper
    {
        /// <summary>
        /// Returns the nummber of alive cells around a cell
        /// </summary>
        /// <param name="x">Current cell x position</param>
        /// <param name="y">Ccurrent cel y position</param>
        /// <param name="map"></param>
        public static int GetMooreNeighborsAlive(int x, int y, int [,] map){
            int numberOfAliveNearbyCells = 0;

            for(int i = -1; i < 2; i++){
                for(int j = -1; j < 2; j++){
                    int nearbyX = x + i;
                    int nearbyY = y + j;

                    if(i == 0 && j == 0){
                        break;
                    } else if(nearbyX < 0 || nearbyY < 0 || nearbyX >= map.GetLength(0) || nearbyY >= map.GetLength(1)){
                        numberOfAliveNearbyCells++;
                    } else if(map[nearbyX, nearbyY] == 1){
                        numberOfAliveNearbyCells++;
                    }
                }
            }

            return numberOfAliveNearbyCells;
        }

        public static int[,] DoTransitionFromOldMap(int[,] oldMap)
        {
            int[,] newMap = new int[oldMap.GetLength(0), oldMap.GetLength(1)];
            for (int x = 0; x < oldMap.GetLength(0); x++)
            {
                for (int y = 0; y < oldMap.GetLength(1); y++)
                {
                    int numberOfAliveCells = GetMooreNeighborsAlive(x, y, oldMap);

                    if(oldMap[x, y] == 1){
                        if (numberOfAliveCells < Settings.AUTOMATA_NUMBER_OF_ALIVE_NEIGHBORS_ALLOWED)
                        {
                            newMap[x, y] = 1;
                        }
                        else{
                            newMap[x, y] = 0;
                        }
                    }
                    else{
                        if (numberOfAliveCells > Settings.AUTOMATA_NUMBER_OF_DEAD_NEIGHBORS_ALLOWED)
                        {
                            newMap[x, y] = 0;
                        }
                        else{
                            newMap[x, y] = 1;
                        }
                    }
                }
            }
            return newMap;
        }
    }
}
