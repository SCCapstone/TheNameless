# TheNameless
# Selene

This first paragraph should be a short description of the app. You can add links
to your wiki pages that have more detailed descriptions.

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

In order to set up this file locally in the Unity Editor, the file must be loaded through
the Unity Hub application. On the projects screen, press the `Add` button and select
the Repository which contains the project.

## Running

Selene does not run through a command line. Instead, the app can be run with the help of the
Unity Editor. In order to test the app, one can press the play button at the top of the editor
window after opening the project through Unity. A Windows build (which will be included at
a later date) can be made by going to File -> Build Settings and pressing `Build & Run`.

# Deployment

Webapps need a deployment section that explains how to get it deployed on the 
Internet. These should be detailed enough so anyone can re-deploy if needed
. Note that you **do not put passwords in git**. 

Mobile apps will also sometimes need some instructions on how to build a
"release" version, maybe how to sign it, and how to run that binary in an
emulator or in a physical phone.

# Testing

With the Unity editor open, navigate through the Window menu, under the General section, and open the Test Runner window.

![Test Runner Location](https://github.com/SCCapstone/TheNameless/assets/59749228/586e0673-e483-4837-8bb2-ee13505fd07b)

From the Test Runner window, unit and behavioral tests can be run.

Select the EditMode tab to access unit tests where you can select "Run All." You may also run each test individually by selecting the specific test and clicking the "Run Selected" option.

Select the PlayMode tab to access behavioral tests where you can select "Run All." You may also run each test individually by selecting the specific test and clicking the "Run Selected" option.

Test files are accessed under `/Assets/Tests/EditMode/` and `/Assets/Tests/PlayMode/`.

## Testing Technology

In some cases you need to install test runners, etc. Explain how.

## Running Tests

Explain how to run the automated tests.

# Authors

Robbie Clark: RMC4@email.sc.edu

Caleb Martin: cam63@email.sc.edu

Ethan Coarr: ecoarr@email.sc.edu

Spencer Beaumont: beaumons@email.sc.edu

Jason Tran: jhtran@email.sc.edu
