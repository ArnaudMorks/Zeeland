using UnityEngine;

public class TestMove : MonoBehaviour
{
	[SerializeField] private Rigidbody _rigidbody;
	[SerializeField] private float _moveSpeed;

	private Vector3 _moveDirection = Vector3.zero;


	private void Update()
	{
		float moveX = Input.GetAxis("Horizontal");
		//float moveY = Input.GetAxis("Vertical");

		_moveDirection = new Vector2(moveX, 0);

	}


	private void FixedUpdate()
	{
		_rigidbody.linearVelocity = new Vector3(_moveDirection.x * _moveSpeed, 0, 0);
		//_rigidbody.angularVelocity = new Vector3(_moveDirection.x * _moveSpeed, _moveDirection.y * _moveSpeed, 0);
	}

}
