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
		bool invalidCollider = false;
        Vector2 normal = collider.contacts[0].normal;
        Platform platform = collider.transform.GetComponent<Platform>();
        EdgesGenerator edgesGenerator = collider.transform.GetComponent<EdgesGenerator>();

		if (platform != null) 
		{
			if (normal != Vector2.up) 
			{
				invalidCollider = true;
			}
		} 
		else if (edgesGenerator != null)
		{
			if (normal == Vector2.up)
			{
				invalidCollider = true;
			}
		} 
		else 
		{
			invalidCollider = false;
			Destroy (collider.gameObject);
		}

		if (!invalidCollider) 
		{
			direction = Vector2.Reflect (direction, normal);
			direction.Normalize ();
		} 
		else 
		{
			GameOver.EndingGame ();
		}
        
    }
}

