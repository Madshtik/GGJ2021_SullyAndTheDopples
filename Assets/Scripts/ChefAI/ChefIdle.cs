using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefIdle : MonoBehaviour
{
    public AudioSource source;
    
    public float timer;

    float countdown;

    // Start is called before the first frame update
    void Start()
    {
        countdown = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown <= 0)
        {
            source.Play();
            countdown = timer;
        }
        else if (!source.isPlaying)
        {
            countdown -= Time.deltaTime;
        }
    }
}
