# DT228/DT211/DT282/DT508 Games Engines 1 2018-2019

## Resources
- [Class Facebook page](https://www.facebook.com/groups/2228012700814097/)
- [Course Notes](https://drive.google.com/open?id=1CeMUWjCUa1Ere2fMmtLz5TCL4O136mxj)
- [Previous lab tests](https://1drv.ms/u/s!Ak7y2552PWCrkNACJ7n8qiU8UPRs9w)
- [Assignment](assignment.md)
- [A build of Infinite Forms](https://drive.google.com/open?id=1-uQZ4sXe51rlda7OPd3M6NyeTsrte2b6)
- [A spotify playlist of music to listen to while coding](https://open.spotify.com/user/1155805407/playlist/5NYFsIFTgNOI93hONLbqNI)
- [Exploring the Psychedelic Experience through Virtual Reality](https://www.facebook.com/askdirectdublin/videos/10155614575684395/)
- [Unity Tutorials](https://unity3d.com/learn/tutorials) 
- [GDC Vault](http://www.gdcvault.com/)
- [Game maths tutorials](http://www.wildbunny.co.uk/blog/vector-maths-a-primer-for-games-programmers/)

## Contact me
* Email: bryan.duggan@dit.ie
* Twitter: [@skooter500](http://twitter.com/skooter500)
* [My website & other ways to contact me](http://bryanduggan.org)


## Previous years courses
- 2017-2018
    - http://github.com/skooter500/GE2-2017-2018
- 2016-2017
	- http://github.com/skooter500/GAI-2017
	- https://github.com/skooter500/GE2-Supplemental-2017
	- https://github.com/skooter500/GE2-LabTest2-2017
	- https://github.com/skooter500/OrbitalRingsSolution
- 2015-2016
    - https://github.com/skooter500/gameengines2015
    - https://github.com/skooter500/BGE4Unity
- 2014-2015
    - https://github.com/skooter500/BGE
    - https://github.com/skooter500/UnitySteeringBehaviours 
- 2013-2014
    - https://github.com/skooter500/XNA-3D-Steering-Behaviours-for-Space-Ships
	
## Assessment Schedule	
- Week 5 - CA proposal & Git repo - 10%
- Week 13 - CA Submission & Demo - 40%

## Week 2 - Unity Maths - Trigonometry & Vectors
## Lecture
- [Slides](https://drive.google.com/file/d/14pWZNf2Z-FX096wCLHt9t6tLorS323-k/view?usp=sharing)
- Solution to last weeks lab is in scene1

## Lab
### Learning Outcomes
- Build a simple agent with perception
- Develop computation thinking
- Use trigonometry
- Use vectors
- Use the Unity API
- Practice C#

### Instructions

Today you will be making this:

[![YouTube](http://img.youtube.com/vi/kC_W1WBB7uY/0.jpg)](http://www.youtube.com/watch?v=kC_W1WBB7uY)

What is happening:
- The red tank has a script attached that has radius and numWaypoints fields that control the generation of waypoints in a circle around it. It draws sphere gizmos so you can see where the waypoints will be.
- The red tank will follow the waypoints starting at the 0th one and looping back when it reaches the last waypoint.
- The red tank prints the messages using the Unity GUI system to indicate:
    - Whether the blue tank is in front or behind
    - Whether the front tank is inside a 45 degree FOV

Things to try:

Try to recreate or improve upon one of the following systems in Infinite Forms:

- Sway/Harmonic rotator
- Spine animator
- FishAnimator
- CreatureGenerator
- TentacleCreatureGenereator

Clone/get the repo for the course and create a new branch for your work today. Call it lab2. There are a few things pre-setup you can can use to get started.

## Week 1 - Introduction
## Lecture
- [Slides](https://drive.google.com/file/d/14pWZNf2Z-FX096wCLHt9t6tLorS323-k/view?usp=sharing)

## Lab

### Learning Outcomes
- Sign up for the class Facebook page
- Find the Unity tutorials
- Test your knowledge of Unity
- Create gameobjects in the scene view
- Create gameobjects from code
- Handle user input
- Use colliders

### Instructions
- Sign up for the [class Facebook page](https://www.facebook.com/groups/2228012700814097/)
- Check out the [Unity tutorial videos](https://unity3d.com/learn/tutorials)

Today you can test your knowledge of Unity by making this:

[![YouTube](http://img.youtube.com/vi/B3dSCruPi_s/0.jpg)](http://www.youtube.com/watch?v=B3dSCruPi_s)

What's happening:

- The tank is made from two cubes. The turrent is parented to the body of the tank
- A material is used to color the tank blue
- A TankController script controlls tank movement which can use either a game controller or the keyboard
- The tank can fire bullets, which get removed from the scene after 5 seconds
- The camera will follow the tank in the style of a third person game
- The wall is made procedurally and physically simulated
- The player tank can crash into the wall and the bullets can damage the wall
- The bricks in the wall are randomly coloured

A few additional points

- The solution to this lab is in a branch of the git repo. *Do not be tempted to look at until you have watched the tutorial videos and tried to do it yourself first*
- The aim of this lab is for me to see what the general level of Unity programming in the class is
- If you have never used Unity before, start by watching a few of the tutorial videos
- See how far you can get with the lab today, but don't be too concerned if you can't finish it. We will make this project in the class next week together and you will discover the awesome power of Unity game engine

[Submit the URL of your git repo here](https://docs.google.com/forms/d/e/1FAIpQLSdNGe6ky0Tezh3a72qCmqMfLeEMbYE9GEtKSnoRI09eQSeeeg/viewform)
