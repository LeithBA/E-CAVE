# E-CAVE : Easy Cave Like System
### Documentation

## Introduction:

E-CAVE is a unity package facilitating the use of a Microsoft Kinect to create a CAVE like effect in an existing Unity 3D project. The package helps to align the virtual space with real space by modifying the official Kinect for Unity package by microsoft and adding utilities to reposition, rotate and adjust the field of view of the unity camera to match the point of view of the user in real space.

## Pre Requirements:
### Software
Unity version 2017 or higher
Kinect for Windows SDK 2.0
Kinect for Windows Unity Package 2.0

### Hardware
Computer running Windows 10
Kinect for Xbox One (with USB3.0/AC adapter) or Kinect 2 for Windows
One or multiple displays

## Setting Up:
After installing the Kinect SDK and test that your kinect is correctly plugged using Kinect Studio v2.0. Click on the CONNECT icon . If Kinect Studio is acting as a webcam, you can proceed to the next step.

Import the folder KinectView folder and Kinect.2.0 unity package found in the Kinect for Windows Unity Package 2.0

Download the E-CAVE ZIP file from the release page. Import E-CAVE.unitypackage or manually drag and drop the files contained inside the Package folder to your Unity project. The script BodySourceView.cs is meant to replace the one previously imported for KinectView.

## Create a CAVE like experience:
The idea behind this technology is to align the real space you are in to the unity environment of your choice.
Add the E-CAVE prefab to your unity scene. This object will serve as an anchor point between the real space and the virtual one. Wherever the prefab is placed in the scene will correspond to where the kinect is placed in the real space. Take your time rotating and positioning the root prefab accurately but do not re-scale it.

For each display you will use, create an empty game object, child to the Screens object. It is important to create these objects in the same order as you see your monitors in the Windows Display Settings.
Position and rotate each of the objects in your scene, relative to the E-CAVE root object the same way the real displays are positioned relative to the Kinect you are using.
In the X and Y scale of each of these objects input the width and height of your displays in meters.

Remove all cameras from your scene as the E-CAVE prefab will generate its own cameras to use.

You can test your setup by pressing the play button but will not be able to use in full screen until you build.

## Demo:
The demos that are provided inside the release package are meant to work with one display 23.6 inch display with the kinect located directly under it.
