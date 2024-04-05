[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/Ow0_BDFJ)

# Portfolio Of Evidence (POE) Part 1 by ST10042763 (Cameron Stocks)

## Whats the Code?

### MainClass.cs

Our MainClass.cs File holds the main method for the program 

### Application.cs

Our Application.cs Contains all the necessary methods for the app loop and lifespan of 
the application

### Recipe.cs

This Is a class to hold an entire recipe in one class and make it a callable object with non-static members

### UnitOfMeasurement.cs

This is just a class that contains the unit of measurement to allow for standardised measurement 
and easy conversion in the [Recipe.cs](#recipecs)


## How does it work?

1. [noRecipe](#appstatenorecipe)
2. [hasRecipe](#appstatenorecipe)

These states govern the mainloop of our application and determine the output menus and event handling for the program

These 2 states are important as the decide which part of the menu to run

### AppState.noRecipe

This state makes a menu giving the user 2 options
1. Add Recipe
2. Exit

The "Add Recipe" option allows the user to enter a recipe
<hr>
The "Exit" option allows the user to exit the application

### AppState.hasRecipe

This state gives the user more options based on the recipe they have entered.

1. View Recipe
2. Adjust Recipe Quantities
3. Reset Quantities
4. Clear Data
5. Exit
<hr>
The "View Recipe" option allows for the user to view the recipe
<hr>
The "Adjust Recipe Quantites" option allows for the user to scale their recipe with the following options
1. Half
2. Double
3. Triple
This allows the user tp do the necessary scaling for their recipe.
<hr>
The "Reset Quantities" option allows the user to reset their recipe to the default quantities they provided at the beginning
<hr>
The "Clear Data" option deletes the recipe and allows for the user to add a new recipe (Also note the app has no persistance thus there will only
ever be 1 recipe at a time)
<hr>
The "Exit" option does: You guessed it! It exits the application...

## Final Thoughts. 

The application is made in such a way that you can use CLI arguments to run the application in the necessary state
If you wish to run it from Visual Studio with the debug Class you need to go to:

`Project > Properties > Debug` 

And in the "Commmand Line Arguments" box add: `init-class-debug` and the default recipe class will be loaded

Otherwise to run from the terminal make sure you are in the correct directory
` SolutionDir\bin\ ` 

in the `command prompt` or `powershell` cli run the following command `POE init-class-debug`

This will run the application with the default loaded class 


Otherwise just run the application without the cla (Command Line Arguments) to run the application from the beginning
