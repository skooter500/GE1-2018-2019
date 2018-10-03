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

## Week 3 - Vectors & Quaternions
- [Slides](https://drive.google.com/file/d/14pWZNf2Z-FX096wCLHt9t6tLorS323-k/view?usp=sharing)
- Solution to last weeks lab is in scene2
- Sway example we did is in scene3
- [Vectors in Unity](https://docs.unity3d.com/Manual/UnderstandingVectorArithmetic.html)

### Unity API Quick Reference

| API | Note |
|----------|------|
| Random.Range | Random number between 2 numbers. Make sure to use approproatly typed parameters! (floats or ints) |
| Random.insideUnitCircle | Random Vector2 of unit length |
| Random.insideUnitSphere | Random Vector3 of unit length |
| transform.position | Note position is a *value* type |
| transform.rotation | A quaternion, another value type |
| transform.localScale | Relative to the parent |
| transform.localPosition | |
| transform.localRotation | |
| transform.Translate | Can use local or world space |
| transform.Rotate | Can use local or world space |
| transform.RotateAround | Takes point, axis and angle. This and the subsequent call loose precision after a while |
| transform.RotateAroundLocal | Takes point, axis and angle |
| transform.SetParent | Often used to just keep the scene tidy |
| transform.up | Local up  |
| transform.right |Local right |
| transform.forward | Local forward |
| transform.TransformPoint | Scales, rotates and transforms a point by a transform. Local to world space |
| transform.InverseTransformPoint | Scales, rotates and transforms a point by a transform. World to local space |
| transform.TransformDirection | Not affected by scale or position |
| transform.LookAt | Rotates the quaternion part to look at a point in world space | 
| transform.ChildCount() | returns the number of children transforms parented to this transform |
| transform.GetChild(0) | returns child 0 |
| gameObject.SetActive | Disables and enables a gameobject and any components attached to it will not have the Update method called |
| gameObject.name |  Name in the hierarchy |
| gameObject.Tag | Set up the strings in the Unity editor. Can use with FindGameObjectWithTag |
| gameObject.layer | A number. Set up different layers for different groups of objects like environment, different enemy types. Use with layer masks. Used for raycasting and rendering |
| gameObject.GetComponent<> | To return a component attached to a gameobject. Uses generics. Returns null if there is no component attached |
| gameObject.AddComponent<> | Retuns the new component |
| gameObject.GetComponentInChildren | Recursive search |
| GameObject.FindGameObjectWithTag<> | Returns the first matching object |
| GameObject.FindGameObjectsWithTag<> | Returns a typed array of objects |
| GameObject.CreatePrimitive | Creates cubes, spheres, cylinders etc |
| GameObject.Destroy | Pass in the gameobject or component you want to distroy |
| GameObject.FindObjectOfType |  Searches the memory space for an instance of a class |
| Vector3.Dot | Multiplies 2 vectors returns a scalar. In front/behind or calculating angle between 2 vectors |
| Vector3.Lerp | Interpolates between 2 vectors using t |
| Vector3.Cross | Returns a vector that is mutully perpindicular to the 2 parameters |
| Vector3.Normalize | Makes the vector of length 1 |
| Vector3.Up | The world up vector |
| Vector3.Right | |
| Vector3.Forward | |
| Vector3.Zero | The vector (0,0,0)  |
| Vector3.One | The vector (1,1,1) |
| Vector3.Distance | Distance between 2 position vectors |
| Vector3.Angle | Angle between 2 vectors |
| x, y, z, | Note vectors are value types! (Structs) |
| vector3.normalized | |
| Quaternion.AngleAxis | This is how to make a quaternion! Angle is in degrees |
| Quaternion.Slerp |  Interpolates between 2 quaternions |
| Quaternion.Identity | No rotation |
| Quaternion.Euler | Make a quetarnion from euler angles |
| Quaternion.Inverse | Quaternion in the opposite direction |
| Quaternion.LookRotation | Makes a quaternion from a vector |
| Quaternion * by a Vector3 | Rotates the vector by the quaternion |
| Quaternion * by a Quaternion | Combines 2 quaternion rotations |
| x, y, z, w | Components of the quaternion |
| Input.GetAxis("Vertical") | returns a value between 0 and 1. Used to move things in response to user input |
| Input.GetKey(KeyCode.Escape) | Check if a key is currently being pressed |
| Input.GetButtonDown("Fire1") | Check if a button is pressed this frame |
| OnDrawGizmos | Called by the Unity editor. Allows the game component to draw gizmos to the scene view |
| Gizmos.color | Sets the color of the subsequently drawn gizmos |
| Gizmos.DrawSphere | |
| Gizmos.DrawWireSphere | |
| Gizmos.DrawCube | |
| Gizmos.DrawLine | |
| Gizmos.DrawRay | |

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
