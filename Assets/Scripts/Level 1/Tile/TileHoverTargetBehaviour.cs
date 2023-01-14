using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHoverTargetBehaviour : MonoBehaviour
{
    private float _lastHovered = 0;

    public Animator animator;

    void Start()
    {
        if (animator == null) animator = GetComponent<Animator>();
    }

    void Update()
    {
        CheckHovered();
    }

    public void PollHovered()
    {
        _lastHovered = Time.time;
        animator.SetBool("IsHovered", true);
    }

    private void CheckHovered()
    {
        if (Time.time - _lastHovered > 0.1f) animator.SetBool("IsHovered", false);
    }
}
