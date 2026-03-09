using UnityEngine;

public class Paralaxing : MonoBehaviour	//MAAK FLEXIBEL; MAAKT NEIT UIT WAAR CAMERA STAAT
{
	private Camera _mainCam;
	[SerializeField] private float _scrollSpeed;
	private float _yPosition;


	private void Start()
	{
		_mainCam = Camera.main;
		_yPosition = transform.position.y;
	}


	private void LateUpdate()
	{
		if (_scrollSpeed == 0)
			return;
		transform.position = new Vector3(_mainCam.transform.position.x * _scrollSpeed, _yPosition, 10);
	}


}
