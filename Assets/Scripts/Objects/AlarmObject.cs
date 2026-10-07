using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmObject : MonoBehaviour
{
    public GameObject glow;

    public Animator shake;

    public AudioSource source;

    public bool isLaptop;

    bool touched;

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying)
        {
            touched = false;

            if (isLaptop)
            {
                glow.SetActive(false);
            }
            else
            {
                shake.SetBool("Play", false);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && !touched)
        {
            source.Play();
            touched = true;

            if (isLaptop)
            {
                glow.SetActive(true);
            }
            else
            {
                shake.SetBool("Play", true);
            }
        }
    }
}
