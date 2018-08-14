using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**************************************************************************************************
//  FUNC: MoveIt
//  TASK: Moves player shots, hazards, enemy shots
**************************************************************************************************/
public class MoveIt : MonoBehaviour
{
    //local variables (NOTE: public means changeable within Unity IDE)
    public float speed;//<---use negative value in Unity IDE to move down-(toward player)

    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.up * speed;
    }
}
