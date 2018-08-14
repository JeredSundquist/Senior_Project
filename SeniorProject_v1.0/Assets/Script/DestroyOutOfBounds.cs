using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**************************************************************************************************
//  FUNC: DestroyOutOfBounds
//  TASK: Destroy game objects as they leave the game board
**************************************************************************************************/
public class DestroyOutOfBounds : MonoBehaviour
{
    //destroy game object upon leaving playable game board
    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
