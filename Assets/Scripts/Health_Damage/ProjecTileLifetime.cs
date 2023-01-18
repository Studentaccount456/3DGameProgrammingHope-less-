using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjecTileLifetime : MonoBehaviour
{
    float timer = 0;
    public float lifeTime = 3f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timer < lifeTime)
        {
            timer += Time.deltaTime;
        }
        else
        {
            // after 3 seconds destroy this gameobject
            Destroy(gameObject);
        }
    }
}
