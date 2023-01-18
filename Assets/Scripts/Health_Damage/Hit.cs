using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Hit : MonoBehaviour
{
    public AudioClip audioClip;
    public GameObject explosionParticle;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "projectile")
        {
            //print("hit");
            //print(transform.position);
            Instantiate(explosionParticle, transform.position, transform.rotation);
            // DO explosion
            if (audioClip)
            {
                if (gameObject.GetComponent<AudioSource>())
                {
                    // gameobject has audiosource
                    gameObject.GetComponent<AudioSource>().PlayOneShot(audioClip);
                }
                else
                {
                    // add audiosource to gameobject: dynamically create object with audiosource, it will remove itself
                    AudioSource.PlayClipAtPoint(audioClip, transform.position);
                }
            }

            Destroy(gameObject);
        }


    }




}

