using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{
    public Transform player;
	public float yOffset;
	public float sensibility;
	public float rotationLimit;

	float rotX;
	float rotY;


	void Update() 
	{
		float mouseX = Input.GetAxis("Mouse Y");
		float mouseY = Input.GetAxis("Mouse X");	
	
		rotX -= mouseX * sensibility * Time.deltaTime;
		rotY += mouseY * sensibility * Time.deltaTime;

		rotX = Mathf.Clamp(rotX, -rotationLimit, rotationLimit); 
	
		transform.rotation = Quaternion.Euler(rotX, rotY,0);
	}

	private void LateUpdate()
	{
		transform.position = player.position + player.up * yOffset;
	}
}
