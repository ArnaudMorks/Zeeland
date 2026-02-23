using UnityEngine;

public class NpcInteract : MonoBehaviour
{
	[SerializeField] private bool _playerContinue;

	[SerializeField] private int _finText;
	[SerializeField] private int _currentText = -1;

	[SerializeField] private GameObject[] _allTexts;



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
			ContinuePress();
		}

	}


	private void ContinuePress()
	{
		if (_currentText == _finText)
			return;

		_currentText++;

		if (_currentText > 0)
			_allTexts[_currentText - 1].SetActive(false);
		_allTexts[_currentText].SetActive(true);

		print("Continue Done");
		_playerContinue = false;
	}


}
