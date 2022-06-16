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
  public AudioSource cannonShotSound;
  private bool fired = false;
    void FixedUpdate()
    {
      if(!fired)
      {
        
        if(cannonShotSound != null)
        {
          cannonShotSound.Play();
        }
        Shoot();
        Invoke("ResetFired", timeBetweenShots);
      }
    }
    void Shoot()
    {
      fired =true;
      GameObject Newprojectile = Instantiate(projectile, firePosition.position, Quaternion.identity);
      Newprojectile.GetComponent<Rigidbody2D>().AddForce(firingDirection * speed, ForceMode2D.Impulse);
      Newprojectile.GetComponent<Projectile>().SetLifeTime(range);
    }
    void ResetFired()
    {
      fired = false;
    }
}
