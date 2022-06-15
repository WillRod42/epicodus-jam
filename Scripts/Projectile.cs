using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
  public int damage;
  private float lifeTime;
  
  public bool destroyOnContact;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if(lifeTime > 0)
      {
        lifeTime -= Time.deltaTime;
      }
      if(lifeTime <= 0)
      {
        Destroy(gameObject);
      }
    }
    void OnTriggerEnter2D(Collider2D obj)
    {
      if(obj.name == "Player")
      {
        obj.GetComponent<LifeAndDeath>().TakeDamage(damage);
      }
      if(destroyOnContact)
      {
        Invoke("DestroyGameObject", 0.5f);
      }
    }
    public void DestroyGameObject()
    {
      Destroy(gameObject);
    }
    public void SetLifeTime(float time)
    {
      lifeTime = time;
    }
}
