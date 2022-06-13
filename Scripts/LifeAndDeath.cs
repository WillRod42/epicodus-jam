using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeAndDeath : MonoBehaviour
{
  public int maxHealth;
  private int currentHealth;
  // Start is called before the first frame update
  void Start()
  {
    currentHealth = maxHealth;
  }

  // Update is called once per frame
  void Update()
  {
    if(currentHealth <= 0)
    {
      Destroy(gameObject);
    }
  }
  public void Heal(int amount)
  {
    if(healthCheck())
    {
      currentHealth += amount;
      Debug.Log(currentHealth + "/" + maxHealth);
    }
  }
  public void TakeDamage(int damage)
  {
    currentHealth -= damage;
    Debug.Log(currentHealth + "/" + maxHealth);
  }
  public bool healthCheck()
  {
    return currentHealth < maxHealth;
  }
}
