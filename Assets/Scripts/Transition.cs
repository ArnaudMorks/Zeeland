using UnityEngine;

public class Transition : MonoBehaviour
{
	[SerializeField] private bool _playerContinue;
	[SerializeField] private MapParts[] _maps;
	[SerializeField] private int _toMapTransition;
	[SerializeField] private bool _teleLeft;
	[SerializeField] private GameObject _player;
	[SerializeField] private float _transOffset;
	[SerializeField] private float _newWalkScaleSetter; //"0" if default
	[SerializeField] private GameObject _newTransport;

	/*private void Update()
	{
		if (Input.GetButtonDown("Jump"))
		{
			//print("BLOP");
			_playerContinue = true;
		}
	}*/


	private void OnTriggerStay(Collider other)	//NOT WORKING, CHANGE IT ALL
	{
		print("PLAYERIN");
		if (_playerContinue)
		{
			TransitionMap();
		}
		TestMove playerCheck;
		playerCheck = other.gameObject.GetComponent<TestMove>();

		//if (playerCheck != null)

	}

	private void OnTriggerEnter(Collider other)
	{
		_playerContinue = true;
	}


	private void TransitionMap()
	{
		_playerContinue = false;

		TestMove testMove = FindFirstObjectByType<TestMove>();
		testMove.WalkScaleSetter(_newWalkScaleSetter);

		if (_teleLeft)
		{
			_maps[1].ActiveSwitch(false);
			_player.transform.position = new Vector3(_newTransport.transform.position.x - 5, _player.transform.position.y, _player.transform.position.z);
			_maps[0].ActiveSwitch(true);
		}

		if (!_teleLeft)
		{
			_maps[0].ActiveSwitch(false);
			_player.transform.position = new Vector3(_newTransport.transform.position.x + 5, _player.transform.position.y, _player.transform.position.z);
			_maps[1].ActiveSwitch(true);
		}


		this.enabled = false;
	}

}
