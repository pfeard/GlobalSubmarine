using UnityEngine;
using System.Collections;

public class Sonar : MonoBehaviour {

	public Transform needle;
	public float period;
	float speed;
	public Texture2D[] obstacleTextures;
	Texture2D currentObstacleTexture;
	public MeshRenderer obstacleDisplayRenderer;
	public float _level;
	public float level
	{
		get { return _level; }
		set {
			_level = Mathf.Clamp01(value);
			ChangeObstacleLevel();
		}
	}

	// Use this for initialization
	void Start () {
		speed = 360.0f/period;
		obstacleDisplayRenderer.material.SetFloat("_Period", period);
		ChangeObstacleLevel();
	}
	
	// Update is called once per frame
	void Update () {
		needle.Rotate(new Vector3(0, 0, -(speed*Time.deltaTime)));

		//Change the texture only when the 
		if(needle.localEulerAngles.z > 180f && needle.localEulerAngles.z < 210f)
		{
			obstacleDisplayRenderer.material.SetTexture("_MainTex", currentObstacleTexture);
		}
	}

	void ChangeObstacleLevel()
	{
		int obstacleLevel = Mathf.FloorToInt(level*obstacleTextures.Length);
		obstacleLevel = Mathf.Min(obstacleLevel, obstacleTextures.Length-1);//If level == 1.0f, we're out of bounds! oops~

		currentObstacleTexture = obstacleTextures[obstacleLevel];
	}
}
