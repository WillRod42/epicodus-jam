using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
  public float speed;
  public float range;
  public float timeBetweenShots;
  public GameObject projectile;
  public Transform firePosition;
  public Vector2 firingDirection;
  private bool fired = false;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      if(!fired)
      {
        GameObject Newprojectile = Instantiate(projectile, firePosition.position, Quaternion.identity);
        Newprojectile.GetComponent<Rigidbody2D>().AddForce(firingDirection * speed, ForceMode2D.Impulse);
        Newprojectile.GetComponent<Projectile>().SetLifeTime(range);
        fired =true;
        Invoke("ResetFired", timeBetweenShots);
      }
    }
    void ResetFired()
    {
      fired = false;
    }
}
