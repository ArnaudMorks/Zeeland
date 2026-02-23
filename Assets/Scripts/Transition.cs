using UnityEngine;

public class Transition : MonoBehaviour
{
	[SerializeField] private bool _playerContinue;
	[SerializeField] private MapParts[] _maps;
	[SerializeField] private int _toMapTransition;
	[SerializeField] private GameObject _player;

	private void Update()
	{
		if (Input.GetButtonDown("Jump"))
		{
			//print("BLOP");
			_playerContinue = true;
		}
	}


	private void OnTriggerStay(Collider other)
	{
		print("PLAYERIN");
		if (_playerContinue)
		{
			TransitionMap();
		}

	}


	private void TransitionMap()
	{
		_playerContinue = false;
		if (_toMapTransition == 0)
		{
			_maps[1].ActiveSwitch(false);
			_player.transform.position = new Vector3(-10f, _player.transform.position.y, _player.transform.position.z);
			_maps[0].ActiveSwitch(true);
		}

		if (_toMapTransition == 1)
		{
			_maps[0].ActiveSwitch(false);
			_player.transform.position = new Vector3(10f, _player.transform.position.y, _player.transform.position.z);
			_maps[1].ActiveSwitch(true);
		}


	}

}
