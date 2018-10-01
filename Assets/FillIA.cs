﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillIA : MonoBehaviour {
    public BoardManager bm;
    public int initialCell; //If kept 0, it randomnizes
    public Vector2 initialQueenCoord;

    bool firstPlaced = false;
    public bool placeQueen = false;

    int queensPlaced = 0;
	// Use this for initialization
	void Start () {
        if (initialCell == 0 || initialCell >64)
        {
            initialCell = Random.Range(1, 65);
        }
        int row = (initialCell - 1)/8 + 1;
        int column =initialCell%8 + 1;

        initialQueenCoord = new Vector2(row, column);


	}
	
	// Update is called once per frame
	void Update () {
		if(placeQueen)
        {
            placeQueen = false;

            if (queensPlaced == 8)
            {
                Debug.Log("No More Room for Queens, total number = " + queensPlaced);
                return;
            }
            if(!firstPlaced)
            {
                firstPlaced = true;
                PlaceNextQueen(initialCell);

            }
            else
            {
                int nextEmpty = bm.SearchNextEmpty();
                if (nextEmpty == 0)
                {
                    Debug.Log("No More Room for Queens, total number = " + queensPlaced);
                }
                else
                {
                    PlaceNextQueen(nextEmpty+1);
                }
            }

        }
	}
    public void PlaceNextQueen(int cellNumber)
    {
        bm.cells[cellNumber - 1].GetComponent<CellStatus>().PlaceQueen();
        queensPlaced++;
    }

    public void PlaceNextQueen(Vector2 cellcoord)
    {

    }
}
