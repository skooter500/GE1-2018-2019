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

## Week8 - Procedural terrain using Perlin Noise
- Meshes
- Making the terrain from a sin wave
- Perlin Noise
- Mesh collider
- Shaders
- HSB Colours

## Lab

Take the code we wrote in the class and here are some suggested modifications you can make. Try one of these or use your imagination and come up with something cool:

- Make the terrain infinite by creating a grid of game objects each one generating a part of the terrain. When the player move across the terrain, move and regenerate the terrain around the player
- Check out GetSpectrumData. See if you can generate the terrain from an audiosource
- Make a texture using Conway's Game of Life and texture the terrain with it

## Week 7 - Unity Systems
- The tentacle system
- Procedural octopus example

## Week 6 - Unity Systems

## Lab
### Learning Outcomes
- Use trigonometry
- learn how to profile a Unity system

In this weeks lab you can create a procedural octopus similar to this one:

[![YouTube](http://img.youtube.com/vi/9pMuNGh8dek/0.jpg)](http://www.youtube.com/watch?v=9pMuNGh8dek)

### Part 1

You can use the tentacle system we developed to instiantiate 8 tentacles in a circular configuration. Use a prefab for the tentacle that uses the tentacle generator and also a prefab for the head that uses a sphere.


### Part 2

Enable and disable the C# job system on the tentacles. This has to be done before the project is built and run You can't change it at runtime. See how many octopuses you can create both with and without using the C# job system implementation and maintain a minimum of 90 FPS

Note: There is a bug in the job system implementation you will need to address before you can do part 2


## Week 5 - Physics
## Lecture
- [Physics 1](https://drive.google.com/open?id=1rYFVCwmL81sEUD-b-Nt-1lmMKw-4XDi0)
- [Physics 2](https://drive.google.com/open?id=1ZGWsmDz9uIJEUf2HPBV2JyYxv1RswPar)
- [Physics 3](https://drive.google.com/open?id=1Tncqb27Cg8LpqHqrtSfcZlgeqTo-HpE8)

## Lab
### Learning Outcomes
- Know how to use raycasts, quaternions and vectors
- Know how to use trigonometry and the unit circle
- Know how to create physics objects from code
- Know the different types of physics joints and what they are used for

In todays lab you can try and make this:

[![YouTube](http://img.youtube.com/vi/vDu28RoqPus/0.jpg)](http://www.youtube.com/watch?v=vDu28RoqPus)

What is happening:

- The camera is controlled using keyboard and mouse. 
- When the player presses U, a tower will spawn in front of the player. To choose the position, you should raycast from the cameras position in the direction the camera is looking to hit the ground
- When the player presses I, a rainbow caterpillar will spawn. I made a seperate script for spawning the caterpillar. Have fields for setting:
    - The number of segments
    - The size of each of the segments. I used a cube for each segment and set the localScale to change the size. I also calculated the gap between the segments relative to the size
    - Parent the segments to the owning transform
    - Dont forget to add a rigidbody to the segment
    - Try and get the basic caterpillar working first and then you can refactor to add tapering at the front and back
    - Use Color.HSVToRGB to set the colour of each segment
    - Link the segments to each other with HingeJoints
    - Add fields for spring and damper values. I used values of 100 and 50
    - In update, use addTorque to add rotational force to the rigidBodies. Use a variable to control which segment get the torque and you can use another variable speed to control how fast the contraction moves along the creatures body

Start with scene6
Unity API's you can use in your solution:

- GameObject.Instantiate
- Quaternion.AngleAxis
- Physics.Raycast
- GameObject.CreatePrimitive
- Color.HSVToRGB
- RigidBody.AddTorque

## Week 4 - More Quaternions

[![YouTube](http://img.youtube.com/vi/IXySkVFNhdk/0.jpg)](http://www.youtube.com/watch?v=IXySkVFNhdk)

[![YouTube](http://img.youtube.com/vi/N5PDboNJwks/0.jpg)](http://www.youtube.com/watch?v=N5PDboNJwks)

## Lab
### Learning Outcomes
- Use quaternions to create two Unity systems

In todays lab you will be making two systems in Unity:

[![YouTube](http://img.youtube.com/vi/utJ5uUouxuA/0.jpg)](http://www.youtube.com/watch?v=utJ5uUouxuA)

The first system is a turret AI system for a game such as a tower defence game. In the video below, the red "tower" will turn to face the players tank and start shooting as soon as the player comes in range. To create this system:

- Make the turret from two cubes and set a spawn point for bullets on the turret
- Add a TurretController component to the turret. Add fields for rotationSpeed and fireRate (and any others you might need)
- Use a SphereCollider on the turret and set isTrigger to be true
- Override OnTriggerEnter and OnTriggerStay to detect the player
- Use quaternions to rotate the turret
- Use a co-routine to shoot multiple times per second

The second system is the tentacle system
- Make an empty gameobject and add a TentacleGenerator component. Add a field for the number of segments and any prefabs you need (I suggest one for the segment of the tentacle that oscillates and one for the bits that follow the oscillation). Use TransformPoint in your solution
- The "head" of the tentacle should oscillate. You can use teh sway script for this
- You can make a script called SpineAnimator and attach it to the head. 
- In Start:
    - Get the list of segments store these in a ```List<Transform>```
    - Calculate the offset to the previous segment in local space, store these in a ```List<Vector3>```
- In Update:
    - Calculate the wantedPosition for each segment by transforming the offset by the previous segments transform
    - Calculate the wantedQuaternion (use Quaternion.LookRotation)
    - Lerp the position and quaternions

## Week 3 - Vectors & a little bit on Quaternions
- [Slides on vectors & trigonometry](https://drive.google.com/file/d/14pWZNf2Z-FX096wCLHt9t6tLorS323-k/view?usp=sharing)
- [Slides on quaternions](https://drive.google.com/file/d/11-KFbodaAl9dRSs9ljzdDyTDp1QWWnsZ/view?usp=sharing)
- Solution to last weeks lab is in scene2
- Sway example we did is in scene3
- CubeMove example is in scene4. Example of dot product of vectors
- [Vectors in Unity](https://docs.unity3d.com/Manual/UnderstandingVectorArithmetic.html)
- [Quaternions in Unity](https://docs.unity3d.com/Manual/UnderstandingVectorArithmetic.html)
- [Unity API Quick reference](unityref.md)

Quaternions in Unity:

An ode to Quaternions:

A quaternion is like a vector, but with a "w"
To construct one, use an axis and an angle, that's what we do
For rotations it must be normal, or otherwise its pure
So we normalise, divide by length, just to be sure
To invert a normal quaternion, we negate x, y and z
Multiply quaternion, vector, inverse quaternion and it rotates don't you see
A rotation of 0 radians is the same as two pi
To convert a quaternion to a matrix, we use the API
So here's a health to old Hamilton, your inventor it would appear
And to imaginary numbers floating in the hypersphere
- Dr Bryan Duggan

## Lab
### Learning Outcomes
- Use Colliders and Triggers
- Learn how to enable and disable game components
- User lerp & slerp

Your task today is to recreate this system from Infinite Forms:

[![YouTube](http://img.youtube.com/vi/wvu5DuJydKY/0.jpg)](http://www.youtube.com/watch?v=wvu5DuJydKY)

Clone the repo for the course and make sure you start from the master branch. Create a branch for todays solution (call it lab3)

Open up scene4. There is the red tank following it's circular path (solution from last week). We are going to add a control orb to the red tank so that the player can enter the orb and take control of the red tank.

- Use the orb prefab and attach it at an appropriate position on the red tank
- Add the TankController script to the redtank and set it to be disabled
- Make a script called RotateMe that performs a local rotation and attach it to the orb so that the orb spins by itself
- Add a sphere collider to the orb and set the isTrigger flag to be true
- Add a script called OrbController to the orb and add methods for OnTriggerEnter and OnTriggerStay. OnTriggerEnter gets called on the script whenever the attached collider overlaps with another collider. OnTriggerStay gets called once per frame so long as the collider is still overlapping.
- In OnTriggerEnter you need to:
    - Check you are colliding with the player
    - If so, disable the FPS Controller on the player and enable the TankController script on the tank
    - Disable the EnemyTankController on the Enemy Tank
    - Disable the RotateMe script on the orb
- In OnTriggetStay you need to:    
    - Check you are colliding with the player
    - Lerp the camera position and slerp the camera rotation
    - Check for the space key, if pressed this frame:
        - Disable the TankController on the tank
        - Enable the EnemyTankController
        - Enable the FPS controller
        - Enable the RotateMe script

I may have left out some steps, but you can figure out the rest yourself        

Use the [Unity Quick Reference](unityref.md) and the [Unity online documentation](https://docs.unity3d.com/ScriptReference/) to look up anything you need  
## Week 2 - Trigonometry
## Lecture
- [Slides](https://drive.google.com/file/d/14pWZNf2Z-FX096wCLHt9t6tLorS323-k/view?usp=sharing)
- Solution to last weeks lab is in scene1
- [Trigonometry problem set](https://1.cdn.edl.io/IDqRlI8C9dRkoqehbbdHBrcGT6m87gkCQuMKTkp0U7JvHvuG.pdf)
- Infinite Forms systems
    - Sway/Harmonic rotator
    - Spine animator
    - FishAnimator
    - CreatureGenerator
    - TentacleCreatureGenereator

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
