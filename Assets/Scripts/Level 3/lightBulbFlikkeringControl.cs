using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class lightBulbFlikkeringControl : MonoBehaviour
{
    //The object that represents the lightBulb
    public GameObject lightObject;

    //The audioSource that will be used to trigger the light-flikkering soundclip
    public AudioSource audioSource;
    //The audioclip that will be triggered by the audioClip
    public AudioClip audioClip;

    //To determine if the light is flikkering starts at false
    public bool isFlikkering = false;
    //The time between every flikker of the light
    public float timeDelay;

    // Start is called before the first frame update
    void Start()
    {
        //Assigning the clip to the audiosource
        audioSource.clip = audioClip;
    }

    // Update is called once per frame
    void Update()
    {
        //If the isFlikkering is false a method that will be expanded
        //over multiple frames will be tiggered
        if (!isFlikkering)
        {
            StartCoroutine(FlikkerLight());
        }
        
    }

    IEnumerator FlikkerLight()
    {
        //Sets everything to false
        isFlikkering=true;
        //Removes the mesh of the object used to represent the lightBulb
        this.lightObject.GetComponent<MeshRenderer>().enabled = false;
        //Turns of the light source
        this.gameObject.GetComponent<Light>().enabled = false;
        //Stops the audiosource from playing
        this.audioSource.Stop();
        timeDelay = Random.Range(0.001f, 0.005f);
        yield return new WaitForSeconds(timeDelay);
        //Accoring to the result value of the timeDelay,
        //so many seconds will be waited until the next set of code will be triggered
        this.lightObject.GetComponent<MeshRenderer>().enabled = true;
        this.gameObject.GetComponent<Light>().enabled = true;
        this.audioSource.Play();
        //Sets the bool back to false so the method can be triggered again in update
        isFlikkering = false;

    }
}
