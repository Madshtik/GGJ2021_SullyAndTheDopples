using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Plate : MonoBehaviour
{
    public PlayableDirector director;

    bool hasStarted = false;

    void Update()
    {
        if (director.state != PlayState.Playing && hasStarted)
        {
            SceneManager.LoadScene(4);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            hasStarted = true;
            director.Play();
        }
    }
}
