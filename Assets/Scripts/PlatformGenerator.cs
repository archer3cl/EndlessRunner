using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {
    
    public ObjectPooler[] platformsPoolers;
    public Transform generationPoint;
    public float distanceBetweenMin;
    public float distanceBetweenMax;
    public Transform maxHeightPoint;
    public float maxHeightChange;

    private float distanceBetween;
    private int platformSelector;
    private float[] platformsWidth;
    private float minHeight;
    private float maxHeight;
    private float heightChange;

    // Use this for initialization
    void Start () {        
        platformsWidth = new float[platformsPoolers.Length];
        for (int i = 0; i < platformsWidth.Length; i++) {
            platformsWidth[i] = platformsPoolers[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
        }
        minHeight = transform.position.y;
        maxHeight = maxHeightPoint.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position.x < generationPoint.position.x){
            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);
            platformSelector = Random.Range(0, platformsPoolers.Length);
            heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);
            if (heightChange > maxHeight) {
                heightChange = maxHeight;
            } else if (heightChange < minHeight) {
                heightChange = minHeight;
            }
            

            transform.position = new Vector3(transform.position.x + (platformsWidth[platformSelector]/2) + distanceBetween, heightChange, transform.position.z);
            GameObject newPlatform = platformsPoolers[platformSelector].GetPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);
            transform.position = new Vector3(transform.position.x + (platformsWidth[platformSelector] / 2), transform.position.y, transform.position.z);
        }
	}
}
