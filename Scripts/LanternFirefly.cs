using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternFirefly : MonoBehaviour
{
    public GameObject lockedItem;
    public GameObject firefly;
    public GameObject lantern;
    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;
    public bool open;
    
    // Start is called before the first frame update

    void Start()
    {
        open = false;
    }

    // Update is called once per frame
    void Update()
    {

    }   

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<CharacterController>() && gameObject.tag == "Lantern" && other.gameObject.GetComponent<CharacterController>().hasFirefly)
        {
            open = true;
            spriteRenderer.sprite = newSprite;
            Destroy(lockedItem);
        }

        if(other.gameObject.GetComponent<CharacterController>() && gameObject.tag == "Firefly")
        {
            other.gameObject.GetComponent<CharacterController>().hasFirefly = true;
            Destroy(firefly);
        }
    }
}
