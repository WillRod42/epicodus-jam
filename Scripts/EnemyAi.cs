using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
  public float changeTimer;
  public float speed;
  public bool vertical;
  private Rigidbody2D rb;
  private float timer;
  private SpriteRenderer sr;
  
  private int direction = 1;
    // Update is called once per frame
    void Start()
    {
      sr = GetComponent<SpriteRenderer>();
      timer = changeTimer;
    }
    void Update()
    {
      timer -= Time.deltaTime;
      if(timer <= 0)
      {
        direction *= -1;
        timer = changeTimer;
      }
    }
    void FixedUpdate()
    {
      if(!vertical)
      {
        if(direction < 0)
        {
          sr.flipX = true;
        }
        else if(direction > 0)
        {
          sr.flipX = false;
        }
        Vector2 position = new Vector2(speed * -direction, 0);
        transform.Translate(position);
      }
      if(vertical)
      {
        Vector2 position = new Vector2(0, speed * -direction);
        transform.Translate(position);
      }
    }
}
