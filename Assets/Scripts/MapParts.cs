using UnityEngine;

public class MapParts : MonoBehaviour
{
	[SerializeField] private GameObject _dialogues;
	[SerializeField] private GameObject _background;
	[SerializeField] private GameObject _forground;
	[SerializeField] private GameObject _npc;
	[SerializeField] private GameObject _edges;
	[SerializeField] private GameObject _transitions;
	[SerializeField] private GameObject _blocks;
	[SerializeField] private CamMove _camMove;
	[SerializeField] private bool _isLeft;


	public void ActiveSwitch(bool setter)
	{
		_dialogues.SetActive(setter);
		_background.SetActive(setter);
		if (_forground != null)
			_forground.SetActive(setter);
		if (_edges != null)
			_edges.SetActive(setter);
		_npc.SetActive(setter);
		_blocks.SetActive(setter);

		//if (setter == true)
		//	_transitions.SetActive(true);
		_camMove.CamSetTrans(_isLeft);
	}

}
