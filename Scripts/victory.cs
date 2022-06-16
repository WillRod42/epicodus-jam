using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class victory : MonoBehaviour
{
    public GameObject exitBossRoom;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<CharacterController>())
        {
            exitBossRoom.SetActive(true);
            Invoke("BackToMainMenu", 5f);
        }
    }
    void BackToMainMenu()
    {
      SceneManager.LoadScene("StartMenu", LoadSceneMode.Single);
    }
}
