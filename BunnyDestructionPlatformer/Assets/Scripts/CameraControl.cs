using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public MoveController thePlayer;

    private Vector3 lastPlayerPos;
    private float distanceMove;


	// Use this for initialization
	void Start () {

        thePlayer = FindObjectOfType<MoveController>(); /*Find player*/

        lastPlayerPos = thePlayer.transform.position; /*Set player positon values*/

	}
	
	// Update is called once per frame
	void Update () {

        distanceMove = thePlayer.transform.position.x - lastPlayerPos.x; /*Calculate distance to move camera by taking current player positon, minus last player positon*/

        transform.position = new Vector3 (transform.position.x + distanceMove, transform.position.y, transform.position.z); /*Add distance to move onto the camera (only on x axis)*/

        lastPlayerPos = thePlayer.transform.position; /*Set player positon values*/

	}
}
