using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

	public float movementVelocity;
	public float limitInX;

	// Use this for initialization
	void Start () 
	{
		limitInX = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, 0, 0)).x - GetComponent<SpriteRenderer> ().bounds.extents.x;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.touches.Length > 0) {
			// Apenas funciona com o primeiro toque
			// e apenas se mover o dedo desde o último frame
			if (Input.touches [0].phase == TouchPhase.Moved) {
				float horizontalDirection = Input.GetAxis ("Mouse X");
				transform.position += Vector3.right * horizontalDirection * movementVelocity * Time.deltaTime;

				float ActualX = transform.position.x;
				ActualX = Mathf.Clamp (ActualX, -limitInX, limitInX);
				transform.position = new Vector3 (ActualX, transform.position.y, transform.position.z);
			}
		}
	}
}
