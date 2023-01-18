using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {

    }
    float timer = 10f;
    bool start = false;
    public float shootRate = 3f;

    // Update is called once per frame
    void Update()
    {
        float shoot = Input.GetAxis("Fire1");
        //print(shoot);

        if (shoot == 1 && timer >= shootRate) //shoot {
        {
            GameObject newProjectile = Instantiate(projectile, transform.position + transform.forward, transform.rotation);

            newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * 5, ForceMode.VelocityChange);
            start = true;
            timer = 0f;
        }

        if (start)
        {
            if (timer < shootRate)
            {
                timer += Time.deltaTime;
            }
            else
            {
                timer = shootRate;
                start = false;
            }
        }
    }
}
