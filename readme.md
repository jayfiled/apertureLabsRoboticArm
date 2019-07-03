## Write software to automate the pipetting process in an aperture laboratory

- [ ] 🔥 **Add a TOC here**

## Setup instructions:
1. Make sure dotnet 👇

- For [Windows](https://dotnet.microsoft.com/download/dotnet-core/2.2), [Linux](https://dotnet.microsoft.com/download/linux-package-manager/rhel/sdk-2.2.300) or [MacOSX](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.300-macos-x64-installer)

.. and git ([for Windows](https://git-scm.com/download/win)) or [Linux/OSX](https://git-scm.com/book/en/v2/Getting-Started-Installing-Git) is installed

2. Open up git bash, cmd or powershell then follow these steps to clone the source from GitHub to a folder on your computer.

- `cd ~/`
- `mkdir toy-robot-tech-test-joel-james`
- `cd toy-robot-tech-test-joel-james`
- Clone:
  - HTTPS: `https://github.com/jayfiled/apertureLabsRoboticArm.git` OR 
  - SSH: `git clone git@github.com:jayfiled/apertureLabsRoboticArm.git`
- `cd apertureLabsRoboticArm`

3. To run the program ⏩
- `dotnet run`

4. To run the tests: 🧪
- Make sure you have the most recent version of NuGet (included in Visual Studio, so no need to install if you have this), otherwise, install from [here](https://dist.nuget.org/win-x86-commandline/latest/nuget.exe)
- Then from powershell or cmd run `dotnet test -v:n` wait for the logging output then scroll to the bottom for the test results.

### 📚 Instructions
- The application is a simulation of a laboratory pipetting robot arm moving above a square plate of 25 wells, of dimensions 5 units x 5 units.
- The robot can freely move above the surface of the plate, and has been primed with enough solution to pipette.

- Once started, the application will prompt you for input in the below format:

    - Running `PLACE` will initialize the Robot arm, which will then detect the plate with test tubes.  You can then enter in the starting position X,Y. The origin (0,0) can be considered to be the SOUTH WEST most corner.
    - Running `DETECT` will check if the test tube below the robot arm position is full or empty.
    - Running `DROP` will put some pipetting solution into the test tube if it's empty.
    - Running `MOVE` will prompt you for a direction to move the robot arm by one test tube - N, S, E or W.
    - Running `REPORT` will give you a status of your current position and whether the test tube in that position is empty or full.

### Project To-do ✅
- [x] **Set up project**
- [x] **Git and Github**
- [x] **Readme**
- [x] **Setup from scratch via readme instructions**
- [x] **Plan out project**
- [x] **Set up APP folders and classes**
    - [x] **TDD** 👇
        - [x] **program.cs to init router**
        - [x] **Router class**
- [x] **Model**
        - [x] **Test Tube class**
- [ ] **Application Controllers**
    - [x] **TDD** 👇
        - [ ] ~~**plate class**~~
        - [x] **robot arm**
- [x] **View**
    - [ ] ~~**TDD**~~ 👇
        - [x] **LcdDisplay**
- [ ] **Clean-up**
    - [ ] **Move check for plate ready and grid in own function**
    - [ ] **Rename test functions to convention**
    - [ ] **Clean up if else with ternary operators, or C# equivalent**
    - [ ] **Check to see if C# has implied 'else'**
    - [ ] **Add the control flow logic in the MOVE method to a separate function**
- [ ] **Improvement**
    - [ ] **IsWithinGrid function dynamically checks the grid size allowing for different sized plates to hold more or less test tubes**
    - [ ] **The test tubes can be filled randomly**
    - [ ] **Add a do/while loop to the move method so that the user can quickly navigate around the test tube plate**
   
    
### Project planning 🤔

(<b> This changed dramatically from the end product, but I'll leave here for reflection</b>)

There is a plate that holds 25 test tubes on a 5 by 5 grid.
#### Model
- The plate will be created when the program starts and 5 arrays numbered row-0 to row 4 will be filled with 5 instances of test tubes randomly full or not-full.  The number of the array name will be the Y position and the index will be used as the X position to check the test tube's full status and to move around the board.
- It will have a method that sets the start position in case the start position ever needs to change.  This will also be used to track any 'move' actions.  And also a method  that sets the boundaries of each 'wall' so that the arm doesn't overshoot and could help make the program extensible in case there is need  to fill more than 25 test tubes.

Object: plate

Properties: array x 5, row-0 to row-4, object:positionTracker, object: boundaries.

Actions: Prepare, PackUp, setStartPosition, setBoundaries

A test tube will hold liquid and will be full or not-full

Object: testTube

Property: boolean:full?

#### Controller

Object: robotArm

Properties: none

Actions: Place, Detect, Drop, Move, Report, sensorWithinBoardGrid?, sensorTestTubeFull?

#### View

Reports any output or errors to the person controlling the robot.

#### App

'starts' the interface to the robot arm and initializes all the classes and passes them to the router to start interaction with the person controlling the robot arm


### Design Considerations
- VS vs Visual Studio code. Felt like VS was overkill for something this simple.  Not sure how tests would work with VScode as there is a suite built into VS.
- "MVC" vs a mini class library - went with "MVC" but felt forced.
- While the tests were a great way of planning out my project, I was spending too much time with with very limited time allocated to this project while on holidays overseas.

### Challenges:
- Mapping my knowledge of Ruby to C#
    Mosh Hamedani on Udemy, traversy media and angelSix on youtube helped out here.
- Not much exp with testing, let alone in C#.
    Always wanted to make time for TDD as it allows me to understand what I am actually doing better.
- Setting up .net workspace on windows. Not challenging, just time consuming looking up how things are done in C# and setting up a workflow.
    - NuGet package manager
    - Getting more descriptive test results
- Struggled to think about which Class should hold the method to check the boundaries of the test tube plate. As it's the view that is getting the place position from the user, I'd have to make new instance of the robot arm to use that function. A static method on the robot arm would probably be ideal, but I have no internet and I get a error message that the function is inaccessible.
- Syntax frustrations:
    - "methods" / "functions" are being used interchangeably in all the videos / articles I've read. Not sure which to use.
    - Don't know the concrete naming conventions for Method Names, Variables, instance variables etc.
- Spend a bit of time looking into getting better nUnit outputs, like rSpec in Ruby how each test failure has an 'expected' and 'got instead' errors.
- Testing is challenging because I don't have a 100% confidence that the test I write will be testing the right thing.  My pseudo code often needs refactoring because of logic errors, so TDD will take some getting used to.
- Found LINQpad as a scratch pad for checking C# syntax etc, but missed out on a debugger like byebug.  In retrospect, the debugger in VScode would have probably done the trick if I got too stuck. 
- Not 100% sure if I am testing the right things because of the above issues.
