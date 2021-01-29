using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmObject : MonoBehaviour
{
    public GameObject glow;

    public bool isLaptop;

    Animation shake;

    AudioSource source;

    bool touched;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();

        if (!isLaptop)
        {
            shake = GetComponent<Animation>();
        }
    }

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
                shake.Stop();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !touched)
        {
            source.Play();
            touched = true;

            if (isLaptop)
            {
                glow.SetActive(true);
            }
            else
            {
                shake.Play();
            }
        }
    }
}
