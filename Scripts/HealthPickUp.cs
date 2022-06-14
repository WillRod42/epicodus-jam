using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
  public int healingAmount;
  public AudioSource pickUpSound;
  void OnTriggerEnter2D(Collider2D obj)
  {
    // if(obj.gameObject.name == "Player" && obj.gameObject.GetComponent<LifeAndDeath>().healthCheck())
    // {
    //   pickUpSound.Play();
    //   obj.gameObject.GetComponent<LifeAndDeath>().Heal(healingAmount);
    //   Invoke("DestroyGameObject", 0.2f);
    // }
    if(obj.gameObject.name == "Player")
    {
      pickUpSound.Play();
      obj.gameObject.GetComponent<LifeAndDeath>().Heal(healingAmount);
      Invoke("DestroyGameObject", 0.4f);
    }
  }
  void DestroyGameObject()
  {
    Destroy(gameObject);
  }
}
