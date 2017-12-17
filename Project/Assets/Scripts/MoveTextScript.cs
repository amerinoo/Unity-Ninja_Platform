using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTextScript : MonoBehaviour
{
	public Transform startMarker;
	public Transform endMarker;
	public int pos;
	public float speed = 1.0F;
	private float startTime;
	private float journeyLength;

	void Start ()
	{
		startTime = Time.time;
		startMarker.localPosition = new Vector3 (0, -pos, 0);
		endMarker.localPosition = new Vector3 (0, pos, 0);
		transform.position = startMarker.position;
		journeyLength = Vector3.Distance (startMarker.position, endMarker.position);
		GetComponent<UnityEngine.UI.Text> ().text = StaticData.GetCredits ();
	}

	void Update ()
	{
		float distCovered = (Time.time - startTime) * speed;
		float fracJourney = distCovered / journeyLength;
		transform.position = Vector3.Lerp (startMarker.position, endMarker.position, fracJourney);

		if (fracJourney > 1.0f) {
			UnityEngine.SceneManagement.SceneManager.LoadScene (0);
		}
	}

}
