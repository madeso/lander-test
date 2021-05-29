using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SpringRotation : MonoBehaviour
{
	public bool active = true;

	public Transform target;
	private new Rigidbody rigidbody;

	private Vector3 torque;

	private void Awake()
	{
		this.rigidbody = this.GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		if (active)
		{
			//Find the rotation difference in eulers
			Quaternion diff = Quaternion.Inverse(rigidbody.rotation) * target.rotation;
			Vector3 eulers = OrientTorque(diff.eulerAngles);
			Vector3 torque = eulers;
			//put the torque back in body space
			torque = rigidbody.rotation * torque;

			//just zero out the current angularVelocity so it doesnt interfere
			// rigidbody.angularVelocity = Vector3.zero;

			rigidbody.AddTorque(torque, ForceMode.Acceleration);
		}
	}

	private Vector3 OrientTorque(Vector3 torque)
	{
		// Quaternion's Euler conversion results in (0-360)
		// For torque, we need -180 to 180.

		return new Vector3
		(
		torque.x > 180f ? torque.x - 360f : torque.x,
		torque.y > 180f ? torque.y - 360f : torque.y,
		torque.z > 180f ? torque.z - 360f : torque.z
		);
	}
}