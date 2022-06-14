using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
  public int damage;
  public AudioSource attackSound;
  private bool attacking;
  private float timer;
    // Start is called before the first frame update
    void Start()
    {
      attacking = false;
      gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      timer -= Time.deltaTime;
    }
    void OnTriggerStay2D(Collider2D obj)
    {
      LifeAndDeath enemyLifeAndDeath = obj.GetComponent<LifeAndDeath>();
      if(enemyLifeAndDeath != null && timer <= 0)
      {
        enemyLifeAndDeath.TakeDamage(damage);
        timer = 0.4f;
      }
    }
    public void ToungeAttack()
    {
      if(!attacking)
      {
        attackSound.Play();
        attacking = true;
        Invoke("ResetAttack", 0.4f);
      }
    }
    void ResetAttack()
    {
      attacking = false;
      gameObject.SetActive(false);
    }
}
