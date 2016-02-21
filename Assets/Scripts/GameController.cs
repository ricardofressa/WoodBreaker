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

	void Awake()
	{
		instance = this;
	}


    public void EndingGame()
    {
		canvasGO.SetActive (true);
    }

	void Start () {
		canvasGO.SetActive (false);
		numberOfBlocksDestroyed = 0;
	}

	void Update () {
		stars.fillAmount = (float) numberOfBlocksDestroyed  / (float) numberTotalOfBlocks; 
	}
}
