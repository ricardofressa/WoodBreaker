using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

	public static int numberTotalOfBlocks;
	public static int numberOfBlocksDestroyed;
	public Image stars;
	public GameObject canvasGO;
	public static GameController instance;
	public Ball ball;
	public Platform platform;

	void Awake()
	{
		instance = this;
	}


    public void EndingGame()
    {
		canvasGO.SetActive (true);
		stars.fillAmount = (float) numberOfBlocksDestroyed  / (float) numberTotalOfBlocks; 
		platform.enabled = false;
		Destroy (ball.gameObject);

    }

	void Start () {
		canvasGO.SetActive (false);
		numberOfBlocksDestroyed = 0;
	}

	public void AlterScene(string scene)
	{
		SceneManager.LoadScene (scene);
	}
}
