using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
	Rigidbody2D body;
	float horizontal;
	float vertical;
	Vector2 mousePos;
	public Camera cam;
	public float runSpeed = 0.3f;

	void Start ()
	{
   		body = GetComponent<Rigidbody2D>(); 
	}

	void Update ()
	{
   		horizontal = Input.GetAxisRaw("Horizontal");
   		vertical = Input.GetAxisRaw("Vertical"); 
		mousePos = cam.ScreenToWorldPoint(Input.mousePosition);//get the position of cursor
	}

	private void FixedUpdate()
	{  
   		body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
		Vector2 lookDir = mousePos - body.position;
		float angle = Mathf.Atan2(lookDir.y,lookDir.x)*Mathf.Rad2Deg - 90f;
		body.rotation = angle;
	}
}
