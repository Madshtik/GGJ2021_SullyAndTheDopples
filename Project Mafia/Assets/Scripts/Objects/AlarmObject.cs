using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmObject : MonoBehaviour
{
    AudioSource source;

    bool touched;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying)
        {
            touched = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !touched)
        {
            source.Play();
            touched = true;
        }
    }
}
