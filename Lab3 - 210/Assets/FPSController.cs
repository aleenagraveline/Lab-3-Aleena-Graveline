using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPSController : MonoBehaviour
{
	public float MouseSensitivity;
	public Transform CamTransform;
	//public RigidBody laserRB;
	public bool gameActive = false;
	public TMP_Text instructions;
	public TMP_Text loseText;
	public TMP_Text winText;
	public TMP_Text crosshair;
	public int score = 0;

	private float camRotation = 0f;

	private void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
		instructions.gameObject.SetActive(true);
	}

	private void Update()
	{
		if(gameActive)
        {
			float mouseInputY = Input.GetAxis("Mouse Y") * MouseSensitivity;
			camRotation -= mouseInputY;
			camRotation = Mathf.Clamp(camRotation, -90f, 90f);
			CamTransform.localRotation = Quaternion.Euler(new Vector3(camRotation, 0f, 0f));

			float mouseInputX = Input.GetAxis("Mouse X") * MouseSensitivity;
			transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0f, mouseInputX, 0f));

			if (Input.GetMouseButtonDown(0))
			{
				RaycastHit hit;
				//laserRB.velocity = (new Vector3(0, 5, 0));

				if (Physics.Raycast(CamTransform.position, CamTransform.forward, out hit))
				{
					//Debug.DrawLine(CamTransform.position + new Vector3(0f, -1f, 0f), hit.point, Color.green, 1f);
					//Debug.Log(hit.collider.gameObject.name);
					DeathButton hitObject = hit.collider.gameObject.GetComponent<DeathButton>();
					if (hitObject != null)
					{
						if (hitObject.isBomb)
						{
							loseText.gameObject.SetActive(true);
							crosshair.gameObject.SetActive(false);
							gameActive = false;
						}
						else
						{
							hitObject.transform.parent.GetComponent<DestructibleWall>().PassWall();
							score++;
							if(score == 4)
                            {
								winText.gameObject.SetActive(true);
								crosshair.gameObject.SetActive(false);
								gameActive = false;
                            }
						}
					}
				}
			}
		}
		else
        {
			if(Input.GetKey(KeyCode.Space))
            {
				gameActive = true;
				crosshair.gameObject.SetActive(true);

				if (instructions.gameObject.activeSelf)
                {
					instructions.gameObject.SetActive(false);
                }
				else
                {
					Application.LoadLevel(Application.loadedLevel);
				}
				/*else if(loseText.gameObject.activeSelf)
                {
					loseText.gameObject.SetActive(false);
                }
				else
                {
					winText.gameObject.SetActive(false);
                }*/
            }
        }
	}

	public bool getGameActive()
    {
		return gameActive;
    }
}
