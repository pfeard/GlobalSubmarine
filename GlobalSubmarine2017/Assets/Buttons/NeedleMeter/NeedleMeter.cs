using UnityEngine;
using System.Collections;
using DG.Tweening;

public class NeedleMeter : MonoBehaviour {

	public float _level;
	public float level{
		get { return _level; }
		set
		{
			_level = Mathf.Clamp01(value);
			UpdateDisplay();
		}
	}

	public Transform needleTransform;

	public float minAngle = -80;
	public float maxAngle = 40;
	float amplitude;


	// Use this for initialization
	void Start () {
		amplitude = maxAngle - minAngle;
	}

	public void SetRandomLevel()
	{
		level = Random.Range(0.0f, 1.0f);
		UpdateDisplay();
	}

	void UpdateDisplay()
	{
		float targetAngle = (minAngle + level*amplitude) * -1.0f;
		needleTransform.DOLocalRotate(new Vector3(0, 0, targetAngle), 0.7f).SetEase(Ease.OutBounce);
	}

}
