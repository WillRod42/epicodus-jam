using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
  public int healingAmount;
  void OnTriggerEnter2D(Collider2D obj)
  {
    if(obj.gameObject.name == "Player" && obj.gameObject.GetComponent<LifeAndDeath>().healthCheck())
    {
      obj.gameObject.GetComponent<LifeAndDeath>().Heal(healingAmount);
      Destroy(gameObject);
    }
  }
}
