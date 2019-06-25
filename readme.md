## Write software to automate the pipetting process in an aperture laboratory

- [ ] 🔥 **Add a TOC here**

## Setup instructions:
1. Make sure dotnet is installed 👇


- Windows: [Install dotnet core 2.2](https://dotnet.microsoft.com/download/dotnet-core/2.2)

- Linux: [Install dotnet core 2.2](https://dotnet.microsoft.com/download/linux-package-manager/rhel/sdk-2.2.300)

- MacOSX [Install dotnet core 2.2](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.300-macos-x64-installer)

2. Open up git bash, cmd or powershell then follow these steps to clone the source from GitHub to a folder on your computer.

- `cd ~/`
- `mkdir toy-robot-tech-test-joel-james`
- `cd toy-robot-tech-test-joel-james`
- `git clone git@github.com:jayfiled/apertureLabsRoboticArm.git`
- `cd apertureLabsRoboticArm`

3. To run the program ⏩

4. Program operator manual 

4. To run the tests 🧪


### 📚 Description
- The application is a simulation of a laboratory pipetting robot arm moving above a square plate of 25 wells, of dimensions 5 units x 5 units.
- The robot is free to roam above the surface of the plate, but must be prevented from moving beyond the boundaries of the plate. Any movement that would result in the robot arm overshooting the plate must be prevented, however further valid movement commands must still be allowed.
- Assume that the robot has been primed with enough solution to pipette.

- Create an application that can read in commands of the following form -
    `PLACE X,Y`
    `DETECT`
    `DROP`
    `MOVE N, S, E or W`
    `REPORT`

- PLACE will place the robot above the plate in position X,Y.
- The origin (0,0) can be considered to be the SOUTH WEST most corner.
- The first valid command to the robot is a PLACE command, after that, any sequence of commands may be issued, in any order, including another PLACE command. The application should discard all commands in the sequence until a valid PLACE command has been executed.
- MOVE will move the toy robot one well in the direction specified by the command.
- DETECT will sense whether the well directly below is FULL, EMPTY or ERR (if the robot cannot detect the plate)
- DROP place a drop of liquid into the well directly below the robot
- REPORT will announce the X,Y,FULL/EMPTY (the status of the detection of the well below) of the robot arm. This can be in any form, but standard output is sufficient.

- A robot that is not over the plate can choose the ignore the MOVE and REPORT commands.
- **Input can be from a file, or from standard input, as the developer chooses.**
- Provide test data to exercise the application. Test data should include priming the plate with wells that are EMPTY or FULL.

Constraints:
The **toy** robot must not overshoot the table during movement. This also includes the initial placement of the toy robot.
Any move that would cause the robot to fall must be ignored.

Example Input and Output:
a)
PLACE 0,0
MOVE N
REPORT
Output: 1,0,EMPTY

b)
PLACE 0,0
MOVE E
REPORT
Output: 0,1,FULL

c)
PLACE 1,2
MOVE N
MOVE E
REPORT
Output: 2,3,EMPTY


### Project To-do
- [ ] **Set up project**
- [ ] **Git and Github**
- [ ] **Readme**
- [ ] **Plan out project**
- [ ] **Set up APP folders and classes**
    - [ ] **TDD** 👇
        - [ ] **program.cs to init router**
        - [ ] **Router class**
- [ ] **Model**
    - [ ] **TDD** 👇
        - [ ] **Test Tube class**
- [ ] **Application Controllers**
    - [ ] **TDD** 👇
        - [ ] **plate class**
        - [ ] **robot arm**
- [ ] **View**
    - [ ] **TDD** 👇
        - [ ] **LcdDisplay**

    
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

## Design Considerations
- VS vs Visual Studio code. Felt like VS was overkill for something this simple.  Not sure how tests would work with VScode as there is a suite built into VS.
- "MVC" vs a mini class library - went with "MVC" but felt forced.

## Challenges:
- Mapping my knowledge of Ruby to C#
    Mosh Hamedani on Udemy, traversy media and angelSix on youtube helped out here.
- Not much exp with testing, let alone in C#.
    Always wanted to make time for TDD as it allows me to understand what I am actually doing better.
- Setting up .net workspace on windows. Not challenging, just an extra thing I hadn't done that took time.