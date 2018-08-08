using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**************************************************************************************************
//  FUNC: MoveShot
//  TASK: Moves the shot down range on game board
**************************************************************************************************/
public class MoveShot : MonoBehaviour
{
    //local variables (NOTE: public means changeable within Unity IDE)
    public float speed;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.up * speed;
    }
}
