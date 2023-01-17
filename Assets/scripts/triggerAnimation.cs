using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerAnimation : MonoBehaviour
{
    [SerializeField]
    private Animator animationController;

    public AudioSource audioSource;
    public AudioClip audioClip;

    private bool soundPlayed = false;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            animationController.SetBool("playerInTrigger", true);
            if (!soundPlayed)
            {
                Invoke("playSound", 1.72f);
            }
        }
    }

    private void playSound()
    {
        this.audioSource.PlayOneShot(audioClip);
        this.soundPlayed = true;

    }

}
