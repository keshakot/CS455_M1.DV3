CS455 Module 1 DV3: Collision/Obstacle Avoidance Behaviors Submission
Author: Georgiy Antonovich Bondar

Go to https://keshakot.github.io/CS455_M1.DV3/ to play the game :)

# Behaviors
Collision Avoidance: Assets/Scripts/CollisionAvoider.cs  
Obstacle Avoidance: Assets/Scripts/ObstacleAvoider.cs  
 
# Bugs/Issues:
## Obstacle Avoidance
1. The small cube moving target is a manually-generated GameObject - ideally, it should be generated in the instance of the ObstacleAvoider.  
2. The ObstacleAvoider will 'side-swipe' the obstacle, for it doesn't take its own dimensions into account.  
3. The ObstacleAvoider will get stuck in a loop behind the obstacle if the obstacle is directly between the player and the ObstacleAvoider.  
