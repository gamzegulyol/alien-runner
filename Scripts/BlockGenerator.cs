using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : MonoBehaviour
{

    // Use this for initialization

    //public GameObject block;
    public Transform generationPoint2;
    //private float blockWidth;
    public float distanceBetween;

    public float distanceBetweenMax;
    public float distanceBetweenMin;

    public GameObject[] blocks;
    private int blockSelect;
    private float[] blockWidths;

    private float minHeight;
    public Transform maxHeightPoint;
    private float maxHeight;
    public float maxHeightChange;
    private float heightChange;



    void Start()
    {
  
        blockWidths = new float[blocks.Length];

        for (int i = 0; i < blocks.Length; i++)
        {
            blockWidths[i] = blocks[i].GetComponent<BoxCollider2D>().size.x;

        }

        minHeight = transform.position.y - 2;
        maxHeight = maxHeightPoint.position.y;


    }

    void Update()
    {

        if (transform.position.x < generationPoint2.position.x)
        {

            distanceBetween = Random.Range(distanceBetweenMin, distanceBetweenMax);

            blockSelect = Random.Range(0, blocks.Length);

            heightChange = Random.Range(minHeight, maxHeight);

            if (heightChange > maxHeight)
            {
                heightChange = maxHeight;
            }
            else if (heightChange < minHeight)
            {
                heightChange = minHeight;
            }


            transform.position = new Vector3(transform.position.x + (blockWidths[blockSelect] / 2) + distanceBetween, heightChange, transform.position.z);



            Destroy(Instantiate(blocks[blockSelect], transform.position, transform.rotation), 12);






        }
    }
}
