using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class lightBulbFlikkeringControl : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject lightObject;

    public AudioSource audioSource;
    public AudioClip audioClip;

    public bool isFlikkering = false;
    public float timeDelay;

    void Start()
    {
        audioSource.clip = audioClip;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFlikkering)
        {
            StartCoroutine(FlikkerLight());
        }
        
    }

    IEnumerator FlikkerLight()
    {
        isFlikkering=true;
        this.lightObject.GetComponent<MeshRenderer>().enabled = false;
        this.gameObject.GetComponent<Light>().enabled = false;
        this.audioSource.Stop();
        timeDelay = Random.Range(0.001f, 0.005f);
        yield return new WaitForSeconds(timeDelay);
        this.lightObject.GetComponent<MeshRenderer>().enabled = true;
        this.gameObject.GetComponent<Light>().enabled = true;
        this.audioSource.Play();
        isFlikkering = false;

    }
}
