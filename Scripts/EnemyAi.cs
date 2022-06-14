using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
  public float changeTimer;
  public float speed;
  private Rigidbody2D rb;
  private float timer;
  
  private int direction = 1;
    // Update is called once per frame
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
      Vector2 position = new Vector2(speed * direction, 0);
      transform.Translate(position);
    }
}
