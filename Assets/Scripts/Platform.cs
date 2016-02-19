using UnityEngine;
using System.Collections;

public class Platform : MonoBehaviour {

	public float movementVelocity;
	public float limitInX;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		float horizontalDirection = Input.GetAxis ("Mouse X");
		transform.position += Vector3.right * horizontalDirection * movementVelocity * Time.deltaTime;

		float ActualX = transform.position.x;
		ActualX = Mathf.Clamp (ActualX, -limitInX, limitInX);
		transform.position = new Vector3 (ActualX, transform.position.y, transform.position.z);
	}
}
