using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject fire;

    public float timer;

    float countdownOff;
    float countdownOn;

    // Start is called before the first frame update
    void Start()
    {
        countdownOff = timer;
        countdownOn = timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (countdownOff <= 0)
        {
            fire.SetActive(true);

            if (countdownOn <= 0)
            {
                fire.SetActive(false);
                countdownOff = timer;
                countdownOn = timer;
            }
            else
            {
                countdownOn -= Time.deltaTime;
            }
        }
        else
        {
            countdownOff -= Time.deltaTime;
        }
    }
}
