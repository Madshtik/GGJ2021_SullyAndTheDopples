using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Plate : MonoBehaviour
{
    public AudioSource source;

    public PlayableDirector director;

    public PlayerMovement player;

    public bool toast;

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
            if (toast)
            {
                if (player.toasted)
                {
                    hasStarted = true;
                    director.Play();
                    source.Play();
                }
            }
            else
            {
                hasStarted = true;
                director.Play();
                source.Play();
            }
        }
    }
}
