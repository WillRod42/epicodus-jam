using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geyser : MonoBehaviour
{
  public float timeToRise;
  public float timeBetweenRising;
  public float timeUntilFall;
  private float timerForRising;
  private float timerForBetweenRising;
  private float timerForFalling;
  private float initalYPosition;
  
  private bool risen = false;
  private bool falling = false;
  

    // Start is called before the first frame update
    void Start()
    {
      timerForRising = timeToRise;
      timerForBetweenRising = timeBetweenRising;
      initalYPosition = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
      
      if(timerForBetweenRising <= 0f && transform.position.y <= initalYPosition + (transform.localScale.y / 3f))
      {
        Vector2 position = new Vector2(0f, (transform.localScale.y * timeToRise) / 1000f);
        transform.Translate(position);
        timerForRising -= Time.deltaTime;
      }
      else if (timerForBetweenRising <= 0f && transform.position.y <= initalYPosition + transform.localScale.y)
      {
        Vector2 position = new Vector2(0f, (transform.localScale.y * timeToRise) / 100f);
        transform.Translate(position);
        timerForRising -= Time.deltaTime;
      }
      if(transform.position.y >= initalYPosition + transform.localScale.y && risen == false)
      {
        risen = true;
        timerForFalling = timeUntilFall;
      }
      if(risen == true && timerForFalling > 0f)
      {
        timerForFalling -= Time.deltaTime;
      }
      else if((risen == true || falling == true) && timerForFalling <= 0f)
      {
        risen = false;
        Vector2 position = new Vector2(0f, -0.5f);
        transform.Translate(position);
        timerForBetweenRising = timeBetweenRising;
        falling = true;
      }
      if(falling == true && transform.position.y <= initalYPosition)
      {
        falling = false;
      }
      if(falling == false && timerForBetweenRising >= 0)
      {
        timerForBetweenRising -= Time.deltaTime;
      }
    }
}
