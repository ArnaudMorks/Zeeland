using UnityEngine;

public class TestMove : MonoBehaviour
{
	[SerializeField] private Rigidbody _rigidbody;
	[SerializeField] private float _moveSpeed;
	[SerializeField] private bool _turnedLeft;
	[SerializeField] private GameObject _visualObject;

	[SerializeField] private float _setterWalkScaleAmount;
	[SerializeField] private float _currentWalkScale;
	[SerializeField] private float _currentSize;
	[SerializeField] private float _startYPos;

	private Vector3 _moveDirection = Vector3.zero;

	[SerializeField] private bool _frontBigVisual;



	private void Start()
	{
		WalkScaleSetter(0);

		WalkScale();
	}



	private void Update()
	{
		float moveX = Input.GetAxisRaw("Horizontal");
		float moveY = Input.GetAxisRaw("Vertical");

		if (_turnedLeft && moveX > 0 || !_turnedLeft && moveX < 0)
		{
			/*_visualObject.transform.localScale = new Vector3(-_visualObject.transform.localScale.x, _visualObject.transform.localScale.y,
				_visualObject.transform.localScale.z);*/
			bool flip = false;

			if (moveX > 0)
			{
				//flip = false;
				_turnedLeft = false;
			}
			else if (moveX < 0)
			{
				flip = true;
				_turnedLeft = true;
			}

			_visualObject.GetComponent<SpriteRenderer>().flipX = flip;
		}

		_moveDirection = new Vector2(moveX, moveY);
		_moveDirection.Normalize();


		WalkScale();

		//testwhenscale
		if (Input.GetKeyDown(KeyCode.K))
			WalkScaleSetter(0);
	}


	private void FixedUpdate()
	{
		_rigidbody.linearVelocity = new Vector3(_moveDirection.x * _moveSpeed, _moveDirection.y * _moveSpeed, 0);
		
		//_rigidbody.angularVelocity = new Vector3(_moveDirection.x * _moveSpeed, _moveDirection.y * _moveSpeed, 0);
	}



	//Triggers when entering new area
	// if "newSetter" = "0" use default
	public void WalkScaleSetter(float newSetter)
	{
		_startYPos = transform.position.y;
		_currentSize = _visualObject.transform.localScale.x;

		if (newSetter != 0)
			_currentWalkScale = newSetter;
		else
			_currentWalkScale = _setterWalkScaleAmount; 

		/*_currentWalkScale = -_startYPos / _setterWalkScaleAmount;
		print(_currentWalkScale);*/
	}


	private void WalkScale()
	{
		if (_moveDirection.y == 0)
			return;

		float walkScaler = _currentSize - (transform.position.y - _startYPos) * _currentWalkScale;
		//float walkScaler = _currentSize  - _startYPos - transform.position.y * (_setterWalkScaleAmount * 0.197f);
		//transform.position.y

		if (walkScaler > 1.1f && !_frontBigVisual)
		{
			_visualObject.GetComponent<SpriteRenderer>().sortingOrder = 4;
			_frontBigVisual = true;
		}
		else if (walkScaler < 1.1f && _frontBigVisual)
		{
			_visualObject.GetComponent<SpriteRenderer>().sortingOrder = 2;
			_frontBigVisual = false;
		}

		_visualObject.transform.localScale = new Vector3(walkScaler, walkScaler,
			_visualObject.transform.localScale.z);

		print(walkScaler);
	}



}
