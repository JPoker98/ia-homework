using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGenerator : MonoBehaviour
{

    public GameObject brick;
    public Vector3 brickDimensions;
    public int rows;
    public int columns;

    public bool zigzag;
    public bool delay;
    public float delayBetweenBricks;

    bool built = false;
    // Use this for initialization
    void Start()
    {
        brickDimensions = brick.GetComponent<MeshFilter>().mesh.bounds.size;
        Vector3 position = new Vector3(0, 0.5f, 0);
        //Instantiate(brick, position, Quaternion.identity, transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (!built)
        {
            built = true;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (zigzag)
                    {
                        if (i % 2 != 0)
                        {
                            Vector3 zigzagPosition = new Vector3(j * brickDimensions.x - brickDimensions.x / 2, 0.5f + i * brickDimensions.y, 0);

                            Instantiate(brick, (transform.position + zigzagPosition), Quaternion.identity, transform);
                            
                        }
                        else
                        {
                            Vector3 position = new Vector3(j * brickDimensions.x, 0.5f + i * brickDimensions.y, 0);

                            Instantiate(brick, transform.position + position, Quaternion.identity, transform);
                        }


                    }
                    else
                    {
                        Vector3 position = new Vector3(j * brickDimensions.x, 0.5f + i * brickDimensions.y, 0);

                        Instantiate(brick, transform.position + position, Quaternion.identity, transform);
                    }



                }
            }
        }
    }

}


