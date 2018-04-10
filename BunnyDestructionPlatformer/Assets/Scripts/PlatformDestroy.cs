using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroy : MonoBehaviour {

    public GameObject platformDestroyPt;

	// Use this for initialization
	void Start () {

        platformDestroyPt = GameObject.Find("PlatformDestroyPt"); /*Finds the current point used to determine where to destroy platforms*/
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (transform.position.x < platformDestroyPt.transform.position.x ) /*If position is behind platform destroy point...*/
        {
            //Destroy(gameObject); /*Destroy game object*/

            gameObject.SetActive (false); /*Deactivate platform object*/
        }

	}
}
