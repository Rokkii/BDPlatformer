using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessPlatform : MonoBehaviour {

    public GameObject objPlatform;
    public Transform genPoint;
    public float distanceBetween;

    //private float platformWidth;

    public float platformGapMin;
    public float platformGapMax;

    //public GameObject[] somePlatforms;
    private int platformSelector;
    private float[] platformWidths;

    public Pooling[] theObjectPools;

    private float minimumHeight;
    public Transform maximumHeightPt;
    private float maximumHeight;
    public float maximumHeightChange;
    private float heightChange;


	// Use this for initialization
	void Start () {

        //platformWidth = objPlatform.GetComponent<BoxCollider2D>().size.x; /*Get platform width from box collider width*/

        platformWidths = new float[theObjectPools.Length]; /*Creates array for storing different platform widths*/

        for (int i = 0; i < theObjectPools.Length; i++)
        {
            platformWidths [i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }

        minimumHeight = transform.position.y;
        maximumHeight = maximumHeightPt.position.y;

	}
	
	// Update is called once per frame
	void Update () {
		
        if (transform.position.x < genPoint.position.x)
        {
            distanceBetween = Random.Range(platformGapMin, platformGapMax); /*Generate distance between platforms randomly between max/min allowed distance*/

            platformSelector = Random.Range(0, theObjectPools.Length); /*Pick random platform by generating random number within range of number of platforms*/

            heightChange = transform.position.y + Random.Range(maximumHeightChange, -maximumHeightChange); /*Calculate platform height change based on random height change number between 2 set values*/

            if (heightChange > maximumHeight)
            {
                heightChange = maximumHeight;
            }
            else if (heightChange < minimumHeight)
            {
                heightChange = minimumHeight;
            }

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distanceBetween, heightChange, transform.position.z);

            //Instantiate(/*objPlatform*/ somePlatforms[platformSelector], transform.position, transform.rotation); /*Create new platform - random from platformSelector*/

            GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject(); /*Create new platform object from pooled object list*/

            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);

            transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);


        }

    }
}
