using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAvoidance : Seek
{
    public Kinematic character;
    public GameObject target;
    GameObject dummyTarget;
    
    bool avoidFlag = false;
    float avoidThresh = 1.0f;

    float maxAcceleration = 25f;
    float maxSpeed = 10f;

    // The min. distance to an obstacle
    float avoidDistance = 3.0f;
    
    // The distance to look ahead
    float lookahead = 5.0f; 

    public ObstacleAvoidance(){
        dummyTarget = GameObject.Find("OATARGET");
    	base.character = character;
    	base.flee = false;
    }

    public override SteeringOutput getSteering()
    {
    	base.character = character;
        SteeringOutput result = null;

        // 1. Calculate collision ray vector
	Vector3 ray = character.linearVelocity; //character.GetComponent<Rigidbody>().velocity;
	ray.Normalize();
	ray.y = 0;
	
	// Look for and handle collision
	RaycastHit hit;
	Debug.DrawRay(character.transform.position, ray * lookahead, Color.blue, 0.1f, false);
	if( avoidFlag ){
	    result = base.getSteering();
	    Vector3 dist = dummyTarget.transform.position - character.transform.position;
	    if( dist.magnitude < avoidThresh )
	        avoidFlag = false;
	}
	else if ( Physics.Raycast(character.transform.position, ray, out hit, lookahead) && hit.transform.name != target.transform.name ){
	    dummyTarget.GetComponent<Renderer>().enabled = true;
	    dummyTarget.transform.position = hit.point + hit.normal * avoidDistance;
	    base.target = dummyTarget;
	    result = base.getSteering();
	    avoidFlag = true;
	}
	else{
	    dummyTarget.GetComponent<Renderer>().enabled = false;
    	    base.target = target;
            result = base.getSteering();
	}
	
	Debug.Log( result.linear );
	
	return result;
    }
}
