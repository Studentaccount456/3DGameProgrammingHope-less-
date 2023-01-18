using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sickness : MonoBehaviour
{
    Animator animator;
    // configurable times for getting sick and end scenario
    [SerializeField]
    float sickTime1;
    [SerializeField]
    float sickTime2;
    [SerializeField]
    float sickTimeEnd;

    void Start()
    {
        // starts timers for each patient
        animator = this.GetComponent<Animator>();
        SickTimer.Create(Sick1, sickTime1);
        SickTimer.Create(Sick2, sickTime2);
        SickTimer.Create(SickEnd, sickTimeEnd);
    }

    private void OnTriggerEnter(Collider other)
    {
        // heal patient when sick
        if (other.gameObject.tag == "Player")
        {
            animator.SetBool("Sick", false);
        }
        
    }
    // ever kind of timer (two times sick and end scenario)
    private void Sick1()
    {
        animator.SetBool("Sick", true);
    }
    private void Sick2()
    {
        animator.SetBool("Sick", true);
    }
    private void SickEnd()
    {
        animator.SetBool("Sick", true);
    }
}
