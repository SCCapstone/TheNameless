# TheNameless
# Selene

Selene is a 2D platformer made in the Unity engine with an emphasis on gravity
changing mechanics.

Your audience for the Readme.md are other developers who are joining your team.
Specifically, the file should contain detailed instructions that any developer
can follow to install, compile, run, and test your project. These are not only
useful to new developers, but also to you when you have to re-install everything
because your old laptop crashed. Also, the teachers of this class will be
following your instructions.

## External Requirements

In order to build this project you first have to install:

* [Unity Hub](https://unity.com/download)
* Unity 2022.3.10f1

Install Unity Hub from the link above. When prompted, choose `Unity 2022.3.10f`
to install. Wait for the installation to complete, then the project can be opened
in the editor.

## Setup

In order to set up this project locally in the Unity Editor, the file must be loaded through
the Unity Hub application. On the projects screen, press the `Add` button and select
the Repository which contains the project.

In order to set up a completed build, download the zip file for the most recent release and unzip
it in the location you want it installed.

## Running

Selene does not run through a command line. Instead, the app can be run with the help of the
Unity Editor. In order to test the app, one can press the play button at the top of the editor
window after opening the project through Unity.

To run the compiled build, open the file you unzipped in setup and run the included executable

## Cheats

Selene has a few included developer cheats if a section proves difficult or if you want to get
back to a section quickly. These cheats are enabled by inputting a specific sequence in non-
minigame levels. Enter "BBA" to toggle invincibility and "BBB" to skip to the next level. If
a code does not seem to work, wait a second befor attempting again, making sure not to press
any other keys.

# Deployment

A Windows build can be made from the project by going to File -> Build Settings and pressing `Build & Run`.

# Testing

Test files are accessed under `/Assets/Tests/EditMode/` and `/Assets/Tests/PlayMode/`.

## Testing Technology

Unity provides a test runner which is installed by default.

With the Unity editor open, navigate through the Window menu, under the General section, and open the Test Runner window.

![Test Runner Location](https://github.com/SCCapstone/TheNameless/assets/59749228/586e0673-e483-4837-8bb2-ee13505fd07b)

From the Test Runner window, unit and behavioral tests can be run.

## Running Tests

Select the EditMode tab to access unit tests where you can select "Run All." You may also run each test individually by selecting the specific test and clicking the "Run Selected" option.

Select the PlayMode tab to access behavioral tests where you can select "Run All." You may also run each test individually by selecting the specific test and clicking the "Run Selected" option.

# Authors

Robbie Clark: RMC4@email.sc.edu

Caleb Martin: cam63@email.sc.edu

Ethan Coarr: ecoarr@email.sc.edu

Spencer Beaumont: beaumons@email.sc.edu

Jason Tran: jhtran@email.sc.edu
