using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

    public Vector3 direction;
    public float velocity;
	public GameObject particleBlocks;
	public ParticleSystem particleLeaf;

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
			else
			{
				particleLeaf.transform.position = platform.transform.position;
				Debug.Log ("Play particleLeaf");
				particleLeaf.Play ();
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
			Bounds colliderBorder = collider.transform.GetComponent<SpriteRenderer> ().bounds;
			Vector3 createPosition = new Vector3 (collider.transform.position.x + colliderBorder.extents.x, collider.transform.position.y - colliderBorder.extents.y, collider.transform.position.z);
			GameObject particle = (GameObject) Instantiate (particleBlocks, createPosition, Quaternion.identity);
			ParticleSystem particleComponent = particle.GetComponent<ParticleSystem> ();
			GameController.numberOfBlocksDestroyed++;
			Destroy (particle, particleComponent.duration + particleComponent.startLifetime);
			Destroy (collider.gameObject);
		}

		if (!invalidCollider) 
		{
			direction = Vector2.Reflect (direction, normal);
			direction.Normalize ();

		} 
		else 
		{
			GameController.instance.EndingGame ();
		}
        
    }
}

