using UnityEngine;

public class CamMove : MonoBehaviour
{
	[SerializeField] private GameObject[] _startEndCamMovePoints;
	[SerializeField] private float[] _startEndXAmount;
	[SerializeField] private float _camYAmount;
	[SerializeField] private bool _camMoving;
	[SerializeField] private GameObject _player;



	private void Start()
	{
		StartCamLocations();
		CamSetTrans(true);
	}


	private void Update()
	{
		CamMoving();
	}



	private void StartCamLocations()
	{
		_startEndXAmount[0] = _startEndCamMovePoints[0].transform.position.x;
		_startEndXAmount[1] = _startEndCamMovePoints[1].transform.position.x;
		_camYAmount = transform.position.y;
	}


	private void CamMoving()
	{

		if (_player.transform.position.x < _startEndXAmount[0] || _player.transform.position.x > _startEndXAmount[1])
			_camMoving = false;
		else
			_camMoving = true;

		if (!_camMoving)
			return;


		transform.position = new Vector3(_player.transform.position.x, _camYAmount, -10);
	}



	public void CamSetTrans(bool isLeft)
	{
		if (isLeft)
			transform.position = new Vector3(_startEndXAmount[0], _camYAmount, -10);
		else
			transform.position = new Vector3(_startEndXAmount[1], _camYAmount, -10);
	}



}
