using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public float VolumeValue { get; set; }

    public float StartingVolume;
    public Slider volume;

    void Start()
    {
        volume.value = StartingVolume;
        VolumeValue = StartingVolume;

        DontDestroyOnLoad(this.gameObject);
    }
}
