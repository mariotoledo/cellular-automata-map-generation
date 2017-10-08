# Cellular Automata Map Generation
> A Cellular Automata usage to generate a random map in a dungeon crawler game made with XNA

This project uses Moore's Game of Life to generate random maps in a dungeon crawler game using cellular automata. The game was developed using Microsoft's XNA by it's facility to make a 2D game and the usage of OOP.

## A brief introduction
While fantasy RPGs are already a genre division in the eletronic gaming universe, there are sub-genres that greatly changes the mechanics of a game. Among them, dungeon crawlers, which consists of controlling heroes through a maze inside a dungeon made of rooms connected by corridors.

![In the left: Diablo 1, one of the successful games of its kin. In the right: Chobobo's Dungeon, for Playstation 1](http://mariotoledo.github.io/cellular-automata-map-generation/docs/chocobodungeon.jpg)
*In the left: Diablo 1, one of the successful games of its kin. In the right: Chobobo's Dungeon, for Playstation 1*

It is common that in Dungeon Crawler games, the player is unaware of the map that he is entering for the first time. The dungeons have several levels, and at each level, the player must become familiar with the place.
Usually, dungeons are created by a level design team, that changes the environment to their liking. However, this limits the levels to a restricted number, and also ensures that the player easily gets used to the other levels of the dungeon, making their game easier.

To improve the player's experience and to ensure an unlimited number of levels, it is suggested to use random map generation. But how to do this in a way that the player can identify small patterns and proceed through the stages from the learning of previous levels?

### Cellular Automata and The Game of Life
According (AGUIAR; COSTA, 2000) Cellular Automata are simple mathematical models of natural systems. They are made up of a mesh, or reticulated, of identical and discrete cells, where each cell has its value over a finite set, for example, of integer values. The values ​​evolve in discrete time steps according to deterministic rules that specify the values ​​of each cell in terms of the values ​​of neighboring cells.

For two-dimensional cellular automata, the best known model was the one developed by John Conway, in the so-called "Game of Life", where cells evolve from an initial state based on rules that simulate their birth, survival and death: [2]:
1. Any living cell with less than two living neighbors dies of loneliness;
2. Any living cell with more than three living neighbors dies of over-population;
3. Any dead cell with exactly three living neighbors becomes a living cell;

![Cells evolving in an implementation of the Game of Life](http://mariotoledo.github.io/cellular-automata-map-generation/docs/jogoDaVida.jpg)
*Cells evolving in an implementation of the Game of Life*

The evolution of a cell into a cellular automaton depends on its neighborhood, composed of cells adjacent to the current cell and the cell itself. The Game of Life uses the model of Moore, in which the neighboring cells are always the 8 cells are around a certain cell.

![Moore's model](http://mariotoledo.github.io/cellular-automata-map-generation/docs/moore.jpg)
*Moore's model*

## The Project
In this project, we created the basic structure of a dungeon crawler game, where a hero can be controlled by the keyboard, respecting the laws of the map, which contains spaces that can not be advanced. [You may fork this version at the "basic_project" branch](https://github.com/mariotoledo/cellular-automata-map-generation/tree/basic_project).

For the generation of the map, the class Tile was created to store information of each square of the Dungeon, considering that it has a format of an array. In general, a Tile represents the smallest space in a dungeon, storing not only its relative position on the map, but also its texture and other states.

The Map class is responsible for generating the Dungeon Map and loading information for each Tile. The primary structure of the map is composed of an array of integers, which indicates the state of each Tile. This will allow to identify if a Tile is "walkable" or not (in the future, we can assign other states).

`
    public class Map
    {
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

        public Tile[,] Tiles { get; private set; 

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
        }
	}
`