using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Toaster : MonoBehaviour
{
    public PlayableDirector director;

    public PlayerMovement player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            director.Play();
            player.toasted = true;
        }
    }
}