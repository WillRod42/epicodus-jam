using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Geyser : MonoBehaviour
{
  public float timeToRise;
  public float timeBetweenRising;
  public float timeUntilFall;
  private float timerForBetweenRising;
  private float timerForFalling;
  private float initalYPosition;
  
  private bool risen = false;
  private bool falling = false;
  

    // Start is called before the first frame update
    void Start()
    {
      timerForBetweenRising = timeBetweenRising;
      initalYPosition = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      if(timerForBetweenRising <= 0f && !falling)
      {
        Rising();
      }
      if(transform.position.y >= initalYPosition + transform.localScale.y && !risen && !falling)
      {
        risen = true;
        timerForFalling = timeUntilFall;
      }
      else if(risen && timerForFalling > 0f)
      {
        timerForFalling -= Time.fixedDeltaTime;
        if(timerForFalling <= 0f)
        {
          risen = false;
          falling = true;
          timerForBetweenRising = timeBetweenRising;
        }
      }
      if(falling)
      {
        Falling();
      }
      if(falling && transform.position.y <= initalYPosition)
      {
        falling = false;
      }
      if(!falling && timerForBetweenRising >= 0)
      {
        timerForBetweenRising -= Time.fixedDeltaTime;
      }
    }
    void Rising()
    {
      if(transform.position.y <= initalYPosition + (transform.localScale.y / 5f))
      {
        Vector2 position = new Vector2(0f, (transform.localScale.y * timeToRise) / 1000f);
        transform.Translate(position);
      }
      else if (transform.position.y <= initalYPosition + transform.localScale.y)
      {
        Vector2 position = new Vector2(0f, (transform.localScale.y * timeToRise) / 100f);
        transform.Translate(position);
      }
    }
    void Falling()
    {
      if(!Mathf.Approximately(transform.position.y, initalYPosition))
      {
        Vector2 position = new Vector2(0f, -0.5f);
        transform.Translate(position);
      }
    }
}
