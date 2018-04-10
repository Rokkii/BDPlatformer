using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Transform platformGenerator;
    private Vector3 platformStartPoint;

    public MoveController thePlayer;
    private Vector3 playerStartPoint;

    private PlatformDestroy[] platformList;

    private ScoreManager theScoreManager;

	// Use this for initialization
	void Start () {

        platformStartPoint = platformGenerator.position; /*Find platform generator start point*/
        playerStartPoint = thePlayer.transform.position; /*Find player start point*/

        theScoreManager = FindObjectOfType<ScoreManager>();   // Find score manager script

	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void RestartGame()
    {
        StartCoroutine("RestartGameCo");    // Calls Restart Co Routine
    }


    public IEnumerator RestartGameCo()
    {
        theScoreManager.scoreIncreasing = false;    // Set scoreIncreasing to false to prevent score from continuing to increase
        thePlayer.gameObject.SetActive(false);  // Disables player character to make invisable
        yield return new WaitForSeconds(0.5f); // Waits 1 second

        platformList = FindObjectsOfType<PlatformDestroy>();    // Finds list of platforms with PlatformDestroy script, adds to platformList array

        for (int i = 0; i < platformList.Length; i++)
        {
            platformList[i].gameObject.SetActive(false);    // Deactivates all generated platforms with PlatformDestroy script
        }

        thePlayer.transform.position = playerStartPoint;    // Restart
        platformGenerator.position = platformStartPoint;    // Restart
        thePlayer.gameObject.SetActive(true);  // Reactivate player

        theScoreManager.scoreCount = 0; // Reset the scoreCount when player dies
        theScoreManager.scoreIncreasing = true;  //  Reset scoreIncreasing when player respawned

    }


}
