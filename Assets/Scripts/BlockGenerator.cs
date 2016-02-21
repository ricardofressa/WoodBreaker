using UnityEngine;
using System.Collections;

public class BlockGenerator : MonoBehaviour {

	public GameObject[] blocks;
	public int lines;

	void Start () {
	
		CreateBlockGroups ();
	}

	void CreateBlockGroups()
	{
		Bounds limitBlock = blocks [0].GetComponent<SpriteRenderer> ().bounds;
		float blockWidth = limitBlock.size.x;
		float blockHeight = limitBlock.size.y;
		float screenWidth, screenHeight, multiplierWidth;
		int columns;

		CollectInformationsOfBlock (blockWidth, out screenWidth, out screenHeight, out columns, out multiplierWidth);
		GameController.numberTotalOfBlocks = lines * columns;
		for (int i = 0; i < lines; i++) 
		{
			for (int j = 0; j < columns; j++) 
			{
				

				GameObject randomBlock = blocks [Random.Range (0, blocks.Length)];
				GameObject instatiateBlock = (GameObject) Instantiate (randomBlock);

				instatiateBlock.transform.position = new Vector3(-(screenWidth * 0.50f) + (j * blockWidth * multiplierWidth), (screenHeight * 0.40f) - (i * blockHeight), 0);
				float newWidthBlock = instatiateBlock.transform.localScale.x * multiplierWidth;
				instatiateBlock.transform.localScale = new Vector3 (newWidthBlock, instatiateBlock.transform.localScale.y, 1);
			}	
		}
	}

		

	void CollectInformationsOfBlock(float blockWidth, out float screenWidth, out float screenHeight, 
		out int columns, out float multiplierWidth)
	{
		Camera camera = Camera.main;
		screenWidth = (camera.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)) - camera.ScreenToWorldPoint(new Vector3(0,0,0))).x;
		screenHeight = (camera.ScreenToWorldPoint (new Vector3 (0, Screen.height, 0)) - camera.ScreenToWorldPoint (new Vector3 (0, 0, 0))).y;
		columns = (int)(screenWidth / blockWidth);

		multiplierWidth = screenWidth / (columns * blockWidth);
			
	}
}
