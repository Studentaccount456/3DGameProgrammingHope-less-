using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorAnimationScript : MonoBehaviour
{

    // Reference to Animator Component:
    public Animator theAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    // Ontrigger effect:
    private void OnTriggerEnter(Collider other)
    {
        // Two lines of code make sure that you get the bool that's in the animator component and put it on true if OnTrigger happens:
        theAnimator.GetBool("IsDoomDestroyed");
        theAnimator.SetBool("IsDoomDestroyed", true);

    }

}
