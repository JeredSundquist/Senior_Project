using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**************************************************************************************************
//  FUNC: PlayableBoundary
//  TASK: Keeps player ship away from boundary by creating a buffer between it and the player ship
**************************************************************************************************/
[System.Serializable]
public class PlayableBoundary
{
    public float xMin;
    public float xMax;
}

/**************************************************************************************************
//  FUNC: PlayerMovement
//  TASK: Handles (player movement, shot spawn, player fire shot)
**************************************************************************************************/
public class PlayerMovement : MonoBehaviour
{
    //local variables (NOTE: public means changeable within Unity IDE)
    public PlayableBoundary board;//<---playable game board; keeps player ship on screen and away from playable game boundary
    Rigidbody rb;//<---physical player game object
    public float speed;//<---physics variable for speed
    public float momentum;//<---physics variable for momentum
    public Transform shotSpawn;//<---physical shot spawn object (NOTE: child of player game object)
    public GameObject shot;//<---physical shot game object from player ship (NOTE: child of shotSpawn game object)
    public float rateOfFire;//<---the rate at which ship can fire it's shot
    private float fireDelay;//<---the actual time the next shot can occur

    //USE FOR GAME COMPONENT INSTANTIATION
    void Start ()
    {
        //NOTE: may not be used in every script for every game component; consider removing
        rb = GetComponent<Rigidbody>();
	}
	
	//USE WHERE FAST & ACCURATE GAME RESPONSE LESS IMPORTANT - (Once per frame calculations)
	void Update()
    {
        //player fires a shot
        if(Input.GetButton("Fire1") && Time.time > fireDelay)
        {
            fireDelay = Time.time + rateOfFire;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }

    //USE WHERE FAST & ACCURATE GAME RESPONSE IMPORTANT (Preframe per frame calculations)
    void FixedUpdate()
    {
        //local variables
        float moveHorizontal = Input.GetAxis("Horizontal");//<---Input.GetAxis more flexible than Input.GetKeyDown for mobile
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);//<---Vector3 for use with velocity call on rigid body player obeject; Z-axis not used therefore zero'd out

        //apply movement to rigid body player object
        rb.velocity = movement * speed;

        //TODO: find a way to slow the slowing of player speed when input direction is released

        //TODO: implement boost direction right and boost direction left

        //set boundary for player game component
        rb.position = new Vector3(Mathf.Clamp(rb.position.x, board.xMin, board.xMax), 0.0f, 0.0f);//<---limits x-axis movement by player; y-axis, z-axis not used therefore zero'd out
    }
}
