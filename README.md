"# SnakeGame" 
This project is for our Distinction Task for SWE20001 Development Project 1-Tools and Development.
It consist of a Snake Game with enhanced features and has been developed through the agile development process, with 3 iterations.

## Introduction ##

Welcome to our SnakeGame project! 

To get started, open up the MyGame.sln file, using your C# IDE developer tool (such as visual studio or xamarin), and build/run the game!

You can run the MyGame.exe file, located in the bin/Debug folder. First try to do a "rebuild all" from your IDE (under build).

**Note: use 'F4' key to toggle in and out of fullscreen**

### The main menu ###

<p align="center">
<img src="https://github.com/dandynood/SnakeGame/wiki/images/mainmenu.PNG" alt="Main Menu"/>
</p>

Once you upon the game, you will be taken to the main menu. You can go on to click on the play button to immediately start playing, or you can check out the instructions in case you somehow forgotton how to play.

<p align="left">
<img src="https://github.com/dandynood/SnakeGame/wiki/images/settings.PNG" alt="Difficulty settings"/>
<img src="https://github.com/dandynood/SnakeGame/wiki/images/music.PNG" alt="Music room"/>
</p>

Click the Settings button to choose your difficulty, and if you want to listen to the music we have without playing, you can click on the Music button, and listen on, or mute if you prefer.

### How to play ###

- Use the WSAD keys or the arrow keys to move the snake up, down, left and right

- Move around the play area to eat the fruits that pop up from nowhere and get disgustingly fatter

- A counter above, will tell you how many fruits you need to proceed to the next level

- Avoid the walls and yourself when you ~~drive~~ slither

- You can use the open sides to cross over to the other side

- Some powerups are available including X3 randomly places 3 extra fruits on the area, the lightning will make you faster, the turtle will make you slower, and the scissors will make reduce a small part of your length, while a random ? block will appear, which causes random effects.
<p align="left">
<img src="https://github.com/dandynood/SnakeGame/wiki/images/multiplyfruit.png" alt="Multiply fruit powerup"/>
<img src="https://github.com/dandynood/SnakeGame/wiki/images/lightning.png" alt="Speed powerup"/>
<img src="https://github.com/dandynood/SnakeGame/wiki/images/turtle.png" alt="Slow powerup"/>
<img src="https://github.com/dandynood/SnakeGame/wiki/images/scissors.png" alt="Decrease length powerup"/>
<img src="https://github.com/dandynood/SnakeGame/wiki/images/question.png" alt="Random"/>
</p>

- You can pause using the "ESC" key, and end the current game or mute too during the game play.

There are currently 4 levels in the game that can be played through. If you crash into the wall or yourself, you will lose and have to restart again from the first level.

### Some screenshots ###
<p align="center">
<img src="https://github.com/dandynood/SnakeGame/wiki/images/level1.PNG" alt="Level 1"/>
<img src="https://github.com/dandynood/SnakeGame/wiki/images/level2.PNG" alt="Level 2"/>
<img src="https://github.com/dandynood/SnakeGame/wiki/images/level3.PNG" alt="Level 3"/>
</p>

### Notes ###

The game runs using the SwinGame API that was used for this project as everyone in the team is familiar with it.

These are the list of files located in the src folder, and its functionality

1. GameMain: The main class of the game that has a loop to process events and refresh the screen, and call the PlayGame method from the GameController

2. GameController: Holds all the rules, such as checking for fruits, walls, itself, going to the next level when the counter has reach a limit, and handles the game states and what to do on each one, such as drawing the menu, levels, playing music, etc.

3. Snake: Contains the necessary methods to draw and move the snake, and has a list of SnakeParts

4. SnakeParts: The individual objects that make up the snake

5. Fruit: Contains the necessary methods to generated the random locations of the fruit and draw

6. Level: Contains the methods to draw levels, by drawing the level's wall

7. Wall: contains the hardcoded coordinates of each wall for the level to draw

8. DirectionEnum: Contains the Up, Down, Left, Right values for the snake's movement method

9. GameState: Enumeration that contains the states that the game can be in, used by the GameController

10. MenuController: Handles the drawing and user inputs of the main menu and pause menu

11. PowerUp: Contains the necessary methods for the powerup's functionality

There is also a TestSnake class, used for unit testing, left over from our previous iterations.

This was completed using the agile Scrum method, while implementing some practices from Extreme Programming, such as Continuous Integration and Test Driven Development, and has been completed in 3 iterations that lasted from 24/10/2016 to 22/11/16 (less than 3 weeks).

As of 28/11/2016, this project has been completed and submitted for our SWE20001 Development Project 1 Custom Program for Distinction grade.

You may download the game and extend if you like to do so, and Thank You for visiting this repository and looking through.
Hope you enjoy our work!
