using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerAnimation : MonoBehaviour
{
    //The controller which will be controlled by the script
    [SerializeField]
    private Animator animationController;

    //The audio source property which will be summoned later in the code
    public AudioSource audioSource;
    //The audio clip that the audio source will use
    public AudioClip audioClip;

    //Used so that the sound doesn't play again if the player gets
    //back in the trigger and the building has already been triggered
    private bool soundPlayed = false;

    /// <summary>
    /// Checks to see if the player is in the triggerBox, if he is then the playerInTrigger 
    /// bool of the animationController will be set to 'true' 
    /// which will trigger the next animation state of the controller.
    /// The method will then check if the sound played bool is false 
    /// in order to trigger the PlaySound() method after 1.72 seconds
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            animationController.SetBool("playerInTrigger", true);
            if (!soundPlayed)
            {
                //Will trigger the method after 1.72 seconds
                Invoke("PlaySound", 1.72f);
            }
        }
    }

    /// <summary>
    /// Is triggered if by the OnTriggerEnter method if the soundPlayer bool is false. 
    /// The method will use the audioSource to trigger the audioClip once, 
    /// after that the bool soundPlayed will be set to true so that the method cannot be called again
    /// </summary>
    private void PlaySound()
    {
        this.audioSource.PlayOneShot(audioClip);
        this.soundPlayed = true;

    }

}
