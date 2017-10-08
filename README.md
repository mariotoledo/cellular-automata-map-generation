# Cellular Automata Map Generation
> A Cellular Automata usage to generate a random map in a dungeon crawler game made with XNA

This project uses Moore's Game of Life to generate random maps in a dungeon crawler game using cellular automata. The game was developed using Microsoft's XNA by it's facility to make a 2D game and the usage of OOP.

## A brief introduction
While fantasy RPGs are already a genre division in the eletronic gaming universe, there are sub-genres that greatly changes the mechanics of a game. Among them, dungeon crawlers, which consists of controlling heroes through a maze inside a dungeon made of rooms connected by corridors.

[![Android camera with the project running](http://mariotoledo.github.io/cellular-automata-map-generation/docs/chocobodungeon.jpg)]
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

[![Android camera with the project running](http://mariotoledo.github.io/cellular-automata-map-generation/docs/jogoDaVida.jpg)]
*Cells evolving in an implementation of the Game of Life*

The evolution of a cell into a cellular automaton depends on its neighborhood, composed of cells adjacent to the current cell and the cell itself. The Game of Life uses the model of Moore, in which the neighboring cells are always the 8 cells are around a certain cell.

[![Android camera with the project running](http://mariotoledo.github.io/cellular-automata-map-generation/docs/jogoDaVida.jpg)]
*Moore's model*
