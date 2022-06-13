using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorButton : MonoBehaviour
{
    private BoxCollider2D bc;
    public GameObject door;

    void Awake()
    {
        bc = gameObject.GetComponent<BoxCollider2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<CharacterController>())
        {
        Destroy(door);
        }
    }
}
