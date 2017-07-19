# Xamarin/MvvmCross Guide
This assignment belongs to the "Build your first connected Xamarin mobile app using MvvmCross 5.0 meetup"

## Software needed:
- Xamarin Studio or Visual Studio
- Xamarin framework
- Android SDK
- Mono
- Java
- Xcode

## Optional software
If you're using Visual Studio 2017 you can install our XabluCross extension that provides an easy way to setup your next Xamarin project: https://www.xablucross.com/extension/

## Assignment 
The assignment is divided in big steps. If you need help just ask!

- Create a new Solution
- Add a PCL project to the solution called “YourCodeName”.Core
- Add an Android and / or iOS project to the solution. Name them “YourCodeName”*.Droid or  “YourCodeName”*.iOS
- If on Android set the target framework to Android 7.0. Do this on both the general and the Android build page. Set the minimum Android level to 4.0.4
- Install the necessary MvvmCross packages in the projects
- MvvmCross Starterpack (This will add the other packages as well)
- Add reference to your Core in platform specific projects
- Add ViewModels for Login and Main screen
- Add Views for Login and Main screen, and connect them to the ViewModel
- Add a Command to the Login ViewModel to navigate to the Main screen
- Bind command to a button in the Login screen
- Add a “Hello world” label and textbox to the main screen
- Bind the Label to the Textbox

Ready?
Run the App!

# Bonus assignments
Create a screen with that shows a list of data (ether hardcoded or from an api:https://jsonplaceholder.typicode.com)
On Item click event of a row, open a popup with the text of the row in it

Resources:
http://www.marcbruins.nl/xamarin-ios-list-with-mvvmcross/
http://www.marcbruins.nl/xamarin-android-reyclerview-with-mvvmcross/
