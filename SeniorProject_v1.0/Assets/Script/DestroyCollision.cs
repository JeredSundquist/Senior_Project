using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**************************************************************************************************
//  FUNC: DestroyCollision
//  TASK: Destroy game objects as they collide
**************************************************************************************************/
public class DestroyCollision : MonoBehaviour
{
    //local variables (NOTE: public means changeable within Unity IDE)
    public GameObject explosion;

    //destroy game objects on collision
    void OnTriggerEnter(Collider other)
    {
        //return from trigger if "other" collider is from Boundary
        if(other.tag == "Boundary")
        {
            return;
        }

        //create explosion on current position
        Instantiate(explosion, transform.position, transform.rotation);

        //destroy other game object
        Destroy(other.gameObject);

        //destroy self game object
        Destroy(gameObject);

        //destroy explosion
        //DestroyImmediate(explosion, true);
    }
}
