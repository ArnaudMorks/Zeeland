using UnityEngine;

public class MapParts : MonoBehaviour
{
	[SerializeField] private GameObject _dialogues;
	[SerializeField] private GameObject _background;
	[SerializeField] private GameObject _npc;

	public void ActiveSwitch(bool setter)
	{
		_dialogues.SetActive(setter);
		_background.SetActive(setter);
		_npc.SetActive(setter);
	}
}
