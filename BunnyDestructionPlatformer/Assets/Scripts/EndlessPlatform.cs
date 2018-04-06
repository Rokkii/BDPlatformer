using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessPlatform : MonoBehaviour {

    public GameObject objPlatform;
    public Transform genPoint;
    public float distanceBetween;

    private float platformWidth;


	// Use this for initialization
	void Start () {

        platformWidth = objPlatform.GetComponent<BoxCollider2D>().size.x; /*Get platform width from box collider width*/

	}
	
	// Update is called once per frame
	void Update () {
		
        if (transform.position.x < genPoint.position.x)
        {
            transform.position = new Vector3(transform.position.x + platformWidth + distanceBetween, transform.position.y, transform.position.z);

            Instantiate(objPlatform, transform.position, transform.rotation); /*Create new platform*/
        }

	}
}
