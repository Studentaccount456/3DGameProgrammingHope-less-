using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerParticles : MonoBehaviour
{
    public ParticleSystem collisionParticleSystem1;
    public ParticleSystem collisionParticleSystem2;
    public ParticleSystem collisionParticleSystem3;

    public bool once = true;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FallingBuilding") && once)
        {

            var em1 = collisionParticleSystem1.emission;
            var em2 = collisionParticleSystem2.emission;
            var em3 = collisionParticleSystem3.emission;

            var du1 = collisionParticleSystem1.main.duration;
            var du2 = collisionParticleSystem2.main.duration;
            var du3 = collisionParticleSystem2.main.duration;

            em1.enabled = true;
            em2.enabled = true;
            em3.enabled = true;

            collisionParticleSystem1.Play();
            collisionParticleSystem2.Play();
            collisionParticleSystem3.Play();

            once = false;


        }

    }
}
