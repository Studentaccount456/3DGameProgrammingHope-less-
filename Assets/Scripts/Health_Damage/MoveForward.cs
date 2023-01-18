using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float upSpeed = 1f;
    public float spinSpeed = 50f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Rotates projectile at certain speed
        transform.Rotate(Vector3.forward * spinSpeed * Time.deltaTime);

        //Moves projectile in certain direction at certain speeed
        transform.Translate(Vector3.forward * upSpeed * Time.deltaTime);
        print(Vector3.forward * Mathf.Cos(Time.timeSinceLevelLoad) * upSpeed);
    }
}

