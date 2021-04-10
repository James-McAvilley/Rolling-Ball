using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 

{
	public GameObject player; 
	private Vector3 offset;
    public float speed = 2.0f;
    private float mouseX = 0.0f;
    private float mouseY = 0.0f;
    public bool inverted = false;

	void Start ()
    {
		offset = transform.position;
	}
	
	void Update ()
    {
        mouseX += speed * Input.GetAxis("Mouse X");
        mouseY -= speed * Input.GetAxis("Mouse Y");

        //transform.eulerAngles = new Vector3(mouseY, mouseX, 0.0f);
		transform.position = player.transform.position + offset;
	}

    /*void Invert()
    {
        if (inverted == true)
        {
            transform.Rotate(-mouseY, 0, 0);
        }
    }*/
    
    
}
