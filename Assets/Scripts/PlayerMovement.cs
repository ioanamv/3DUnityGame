using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Camera playerViewCamera;
	public float speed=5f;
	public float jumpForce = 6f;
	public float gravity = 10f;

	private float vericalRotation = 0;
	private float mouseSensibility = 2f;
	private float verticalViewLimit = 45f;

    private Vector3 moveDirection = Vector3.zero;
	private CharacterController characterController;

	private bool canMove=false;

	private void Start()
	{
		characterController= GetComponent<CharacterController>();
	}

	public void PlayerCanMove()
	{
		canMove= true;
	}

	private void Update()
	{
		if (!canMove) return;

		//player movement
		Vector3 forward = transform.TransformDirection(Vector3.forward);
		Vector3 right= transform.TransformDirection(Vector3.right);

		float speedX = Input.GetAxis("Vertical")*speed;
		float speedY = Input.GetAxis("Horizontal") * speed;
		float movementDirY=moveDirection.y;

		moveDirection=forward*speedX+right*speedY;

		//jumping
		if (Input.GetButton("Jump") && characterController.isGrounded)
		{
			moveDirection.y = jumpForce;
		}
		else
		{
			moveDirection.y=movementDirY-gravity*Time.deltaTime;
		}

		characterController.Move(moveDirection*Time.deltaTime);

		//mouse movement
		vericalRotation += -Input.GetAxis("Mouse Y") * mouseSensibility;
		vericalRotation=Mathf.Clamp(vericalRotation,-mouseSensibility,verticalViewLimit);
		playerViewCamera.transform.localRotation = Quaternion.Euler(vericalRotation, 0, 0);
		transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * mouseSensibility, 0);
	}
}
