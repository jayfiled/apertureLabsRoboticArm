## Write software to automate the pipetting process in an aperture laboratory

## Setup instructions:
First, make sure dotnet is installed 👇


- Windows: [Install dotnet core 2.2](https://dotnet.microsoft.com/download/dotnet-core/2.2)

- Linux: [Install dotnet core 2.2](https://dotnet.microsoft.com/download/linux-package-manager/rhel/sdk-2.2.300)

- MacOSX [Install dotnet core 2.2](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.300-macos-x64-installer)

Then clone the source from GitHub:

- `cd ~/`
- `mkdir toy-robot-tech-test-joel-james`
- `cd toy-robot-tech-test-joel-james`
- `git clone git@github.com:jayfiled/apertureLabsRoboticArm.git`
- `cd apertureLabsRoboticArm`

### Project To-do
- [] **Set up project**
- [] **Git and Github**
- [] **Readme**
- [] **Plan out project**
- [] **Set up APP folders and classes**
    - [] **TDD** 👇
        - [] **program.cs to init router**
        - [] **Router class**
- [] **Model**
    - [] **TDD** 👇
        - [] **Test Tube class**
- [] **Application Controllers**
    - [] **TDD** 👇
        - [] **plate class**
        - [] **robot arm**
- [] **View**
    - [] **TDD** 👇
        - [] **LcdDisplay**

## Challenges:
- Mapping my knowledge of Ruby to C#
    Mosh Hamedani on Udemy, traversy media and angelSix on youtube helped out here.
- Not much exp with testing, let alone in C#.
    Always wanted to make time for TDD as it allows me to understand what I am actually doing better.
- Setting up .net workspace on windows. Not challenging, just an extra thing I hadn't done that took time.
    
### Class breakdown

There is a plate that holds 25 test tubes on a 5 by 5 grid.

- The plate will be created when the program starts and 5 arrays numbered row-0 to row 4 will be filled with 5 instances of test tubes randomly full or not-full.  The number of the array name will be the Y position and the index will be used as the X position to check the test tube's full status and to move around the board.
- It will have a method that sets the start position in case the start position ever needs to change.  This will also be used to track any 'move' actions.  And also a method  that sets the boundaries of each 'wall' so that the arm doesn't overshoot and could help make the program extensible in case there is need  to fill more than 25 test tubes.

Object: plate

Properties: array x 5, row-0 to row-4, object:positionTracker, object: boundaries.

Actions: Prepare, PackUp, setStartPosition, setBoundaries

A test tube will hold liquid and will be full or not-full

Object: testTube

Property: boolean:full?

Object: robotArm

Properties: none

Actions: Place, Detect, Drop, Move, Report, sensorWithinBoardGrid?, sensorTestTubeFull?

### View

Reports any output or errors to the person controlling the robot.

### App

'starts' the interface to the robot arm and initializes all the classes and passes them to the router to start interaction with the person controlling the robot arm

### Router
