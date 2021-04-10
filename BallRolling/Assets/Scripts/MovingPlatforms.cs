using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatforms : MonoBehaviour
{

    public float speed = 2.0f;
    private bool moveX = false;
    private bool moveY = false;
    private bool moveZ = false;
    public bool X, Y, Z;
    public float Xmax, Ymax, Zmax, Xmin, Ymin, Zmin;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Xaxis();
        Yaxis();
        Zaxis();
    }

    void Xaxis()
    {
        if (X == true)
        {
            if (moveX == true)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }

            else
            {
                transform.Translate(-Vector3.right * speed * Time.deltaTime);
            }

            if (transform.position.x >= Xmax)
            {
                moveX = false;
            }

            if (transform.position.x <= Xmin)
            {
                moveX = true;
            }
        }

    }

    void Yaxis()
    {
        if (Y == true)
        {
            if (moveY == true)
            {
                transform.Translate(Vector3.up * speed * Time.deltaTime);
            }

            else
            {
                transform.Translate(-Vector3.up * speed * Time.deltaTime);
            }

            if (transform.position.y >= Ymax)
            {
                moveY = false;
            }

            if (transform.position.y <= Ymin)
            {
                moveY = true;
            }
        }
    }

    void Zaxis()
    {
        if (Z == true)
        {
            if (moveZ == true)
            {
                transform.Translate(Vector3.forward * speed * Time.deltaTime);
            }

            else
            {
                transform.Translate(-Vector3.forward * speed * Time.deltaTime);
            }

            if (transform.position.z >= Zmax)
            {
                moveZ = false;
            }

            if (transform.position.z <= Zmin)
            {
                moveZ = true;
            }
        }

    }
}