using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

	public GameObject target;

	float force = 1000;

	public Rigidbody Physics;

	const float ORIENTATION_INC = 60.0f;

	void Update()
    {
		var movementX = Input.GetAxis("Horizontal");
		var movementY = Input.GetAxis("Vertical");

		var dt = Time.deltaTime;

		if (Input.GetKey(KeyCode.Space)) Physics.AddForce(Physics.transform.up * force * dt, ForceMode.Acceleration);
		if (Input.GetKey(KeyCode.A)) incRoll(-ORIENTATION_INC * dt);
		if (Input.GetKey(KeyCode.D)) incRoll(ORIENTATION_INC * dt);
		if (Input.GetKey(KeyCode.UpArrow)) incPitch(ORIENTATION_INC * dt);
		if (Input.GetKey(KeyCode.DownArrow)) incPitch(-ORIENTATION_INC * dt);
		if (Input.GetKey(KeyCode.RightArrow)) incYaw(-ORIENTATION_INC * dt);
		if (Input.GetKey(KeyCode.LeftArrow)) incYaw(ORIENTATION_INC * dt);
	}

    private void incYaw(float v)
	{
		target.transform.Rotate(Vector3.up, -v, Space.World);
	}

	private void incPitch(float v)
	{
		target.transform.Rotate(Vector3.right, -v, Space.Self);
	}

	private void incRoll(float v)
	{
		target.transform.Rotate(Vector3.forward, -v, Space.Self);
	}
}
