using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
  public int damage;
  public AudioSource attackSound;
  private bool attacking;
    // Start is called before the first frame update
    void Start()
    {
      gameObject.SetActive(false);
    }
    void OnTriggerEnter2D(Collider2D obj)
    {
      LifeAndDeath enemyLifeAndDeath = obj.GetComponent<LifeAndDeath>();
      if(enemyLifeAndDeath != null && enemyLifeAndDeath.currentHealth > 0)
      {
        enemyLifeAndDeath.TakeDamage(damage);
      }
    }
    public void ToungeAttack()
    {
      if(!attacking)
      {
        attackSound.Play();
        attacking = true;
        Invoke("ResetAttack", 1f);
      }
    }
    void ResetAttack()
    {
      attacking = false;
      gameObject.SetActive(false);
    }
}
