using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageObject : MonoBehaviour
{
  public int damage;

  public void OnCollisionEnter2D(Collision2D obj)
  {
    if(obj.gameObject.name == "Player")
    {
      obj.gameObject.GetComponent<LifeAndDeath>().TakeDamage(damage);
    }
  }
}
