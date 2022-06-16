using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class victory : MonoBehaviour
{
    public GameObject exitBossRoom;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<CharacterController>())
        {
            Debug.Log("game end trigger");
            exitBossRoom.SetActive(true);
        }
    }

    

}
