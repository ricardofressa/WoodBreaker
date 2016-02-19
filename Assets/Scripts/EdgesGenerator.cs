using UnityEngine;
using System.Collections;

public class EdgesGenerator : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Camera camera = Camera.main;
		EdgeCollider2D colliderEdge = GetComponent<EdgeCollider2D> ();

		Vector2 bottomLeft = camera.ScreenToWorldPoint (new Vector3 (0, 0, 0));
		Vector2 bottomRight = camera.ScreenToWorldPoint (new Vector3 (Screen.width, 0, 0));
		Vector2 TopLeft = camera.ScreenToWorldPoint (new Vector3 (0, Screen.height, 0));
		Vector2 TopRight = camera.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 0));

		colliderEdge.points = new Vector2[5] { bottomLeft, TopLeft, TopRight, bottomRight, bottomLeft };

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
