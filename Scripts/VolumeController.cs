using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeController : MonoBehaviour
{
    void Start()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.volume = GameObject.FindGameObjectWithTag("volume").GetComponent<Volume>().VolumeValue;
        Debug.Log(GameObject.FindGameObjectWithTag("volume").GetComponent<Volume>().VolumeValue);
    }
}
