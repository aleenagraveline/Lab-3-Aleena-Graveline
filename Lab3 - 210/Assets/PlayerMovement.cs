using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public CharacterController CC;
	public float MoveSpeed;
	public float Gravity = -9.8f;
	public float JumpSpeed;

	public float verticalSpeed;

	private void Update()
	{
		if(GetComponent<FPSController>().getGameActive())
        {
			Vector3 movement = Vector3.zero;

			// X/Z movement
			float forwardMovement = Input.GetAxis("Vertical") * MoveSpeed * Time.deltaTime;
			float sideMovement = Input.GetAxis("Horizontal") * MoveSpeed * Time.deltaTime;

			movement += (transform.forward * forwardMovement) + (transform.right * sideMovement);

			CC.Move(movement);
		}
	}
}
