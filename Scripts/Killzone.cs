using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Killzone : MonoBehaviour
{
    public int Respawn;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<CharacterController>())
        {
          string currentScene = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentScene, LoadSceneMode.Single);
        }
    }
}
