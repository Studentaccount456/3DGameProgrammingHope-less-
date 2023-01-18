using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHoverTargetBehaviour : MonoBehaviour
{
    // Last time the tile was hovered over with the cursor.
    private float _lastHovered = 0;

    // The animator that makes the tile move up and down.
    public Animator animator;

    void Start()
    {
        if (animator == null) animator = GetComponent<Animator>();
    }

    void Update()
    {
        CheckHovered();
    }

    // Polls the last time the tile was hovered over.
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
