using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverBoard : MonoBehaviour {


    // Components that we can change to affect visuals
    [SerializeField]
    private int sections;
    [SerializeField]
    private float rotSpeed;
    [SerializeField]
    private float sizeLargest;
    [SerializeField]
    private float topSize;
    [SerializeField]
    private GameObject corePrefab;
    [SerializeField]
    private float distFromEachother;


    List<GameObject> mySections;
	// Use this for initialization
	void Start () {
        mySections = new List<GameObject>();
        var sizeChange = sizeLargest / sections;
		for(int i = 0; i <= sections; i++)
        {
            var currentPiece = Instantiate(corePrefab, this.transform);
            currentPiece.transform.position = this.transform.position + Vector3.up * (distFromEachother * i + 1);
            currentPiece.transform.localScale = new Vector3(sizeLargest - (sizeChange * i + 1), .02f, 1 - (sizeChange * i + 1));
            mySections.Add(currentPiece);
        }
    }
	
	// Update is called once per frame
	void Update () {
        var flipFlop = 1;
		foreach(var piece in mySections)
        {
            piece.transform.Rotate(piece.transform.up * rotSpeed * flipFlop * Time.deltaTime);
            flipFlop *= -1;
        }
    }
}
