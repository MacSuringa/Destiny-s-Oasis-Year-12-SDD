using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ambience: MonoBehaviour
{
    public AudioClip[] soundtrack;
    public Slider volume;

    void Start()
    {
        if (!GetComponent<AudioSource>().playOnAwake)
        {
            GetComponent<AudioSource>().clip = soundtrack[Random.Range(0, soundtrack.Length)];
            GetComponent<AudioSource>().Play();
        }
    }

    void Update()
    {
        if (!GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().clip = soundtrack[Random.Range(0, soundtrack.Length)];
            GetComponent<AudioSource>().Play();
        }
    }
}