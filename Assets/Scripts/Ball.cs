using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public Vector3 direction;
    public float velocity;

	void Start ()
    {

        direction.Normalize();
	
	}

	void Update ()
    {
        transform.position += direction * velocity * Time.deltaTime;
	}

    void OnCollisionEnter2D(Collision2D collider)
    {
        Vector2 normal = collider.contacts[0].normal;
        direction = Vector2.Reflect(direction, normal);
        direction.Normalize();
    }
}

