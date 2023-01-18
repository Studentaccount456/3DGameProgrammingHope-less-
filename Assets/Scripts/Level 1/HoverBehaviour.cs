using UnityEngine;

public class HoverBehaviour : MonoBehaviour
{
    // The sounds to play when hovering over a tile.
    public AudioClip[] hoverSounds;

    private Ray _raycast;
    private RaycastHit _raycastHit;

    void Start()
    {
    }

    void FixedUpdate()
    {
        // Cast a raycast from the camera to the mouse position on screen.
        _raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawLine(_raycast.origin, _raycastHit.point, Color.red);
        if (Physics.Raycast(_raycast, out _raycastHit))
        {
            // If this hit a gameobject, check if the parent has a "Tile" tag.
            var gameObject = _raycastHit.collider.gameObject.transform.parent.gameObject;
            if (!gameObject.tag.Equals("Tile")) return;

            var tileBehaviour = gameObject.GetComponentInParent<TileHoverTargetBehaviour>();
            var audioSource = gameObject.GetComponent<AudioSource>();
            // If the audio isn't playing and this is the first time it's getting hovered over, play the hover noise.
            if (!audioSource.isPlaying && !tileBehaviour.animator.GetBool("IsHovered"))
            {
                audioSource.clip = hoverSounds[Random.Range(0, hoverSounds.Length)];
                audioSource.Play();
            }

            // Update the hover behaviour.
            tileBehaviour.PollHovered();
        }
    }
}
