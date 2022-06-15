using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LifeAndDeath : MonoBehaviour
{
  public int maxHealth;
  public AudioSource destroySound;
  public AudioSource hitSound;
  private int currentHealth;
  private bool destroySoundPlayed = false;
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
      if(destroySound != null && destroySoundPlayed == false)
      {
        destroySoundPlayed = true;
        destroySound.Play();
      }
      if(gameObject.name == "Player")
      {
        string currentScene = SceneManager.GetActiveScene().name; 
        SceneManager.LoadScene(currentScene, LoadSceneMode.Single);
      }
      else
      {
        Invoke("DestroyGameObject", 0.2f);
      }
      
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
    if(hitSound != null)
    {
      hitSound.Play();
    }
    currentHealth -= damage;
    Debug.Log(currentHealth + "/" + maxHealth);
  }
  public bool healthCheck()
  {
    return currentHealth < maxHealth;
  }
  void DestroyGameObject()
  {
    Destroy(gameObject);
  }
}
