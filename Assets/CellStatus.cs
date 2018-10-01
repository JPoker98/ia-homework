using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CellStatus : MonoBehaviour {

    Text cellName;
    Image cellColor;
    public Image queen;
    public Image attackedCell;
    public BoardManager bm;
    public bool attacked = false;

    public int row;
    public int column;
    
	// Use this for initialization
	void Awake () {
        cellName = GetComponentInChildren<Text>();
        cellColor = GetComponent<Image>();
	}
	public void IsAttacked(Color color)
    {

            attackedCell.enabled = true;
            attackedCell.color = color;
        
    }
    public void ChangeText(string name)
    {
        cellName.text = name;
    }
    public void ChangeColor(Color color)
    {
        color.a = 0.8f;
        cellColor.color = color;
    }
     
    public void PlaceQueen()
    {
        if(!attacked)
        {
            attacked = true;
            queen.enabled = true;
            queen.color = bm.queensColor[bm.currentQueen];
            bm.AttackTheRest(row, column);
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
}
