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
        _raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawLine(_raycast.origin, _raycastHit.point, Color.red);
        if (Physics.Raycast(_raycast, out _raycastHit)) {
            var gameObject = _raycastHit.collider.gameObject.transform.parent.gameObject;
            if (!gameObject.tag.Equals("Tile")) return;

            var tileBehaviour = gameObject.GetComponentInParent<TileHoverTargetBehaviour>();
            var audioSource = gameObject.GetComponent<AudioSource>();
            if (!audioSource.isPlaying && !tileBehaviour.animator.GetBool("IsHovered"))
            {
                audioSource.clip = hoverSounds[Random.Range(0, hoverSounds.Length)];
                audioSource.Play();
            }

            tileBehaviour.PollHovered();
        }
    }
}
