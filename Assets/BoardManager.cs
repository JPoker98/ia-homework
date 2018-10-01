using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour {

    public int rowsColumns;
    public GameObject grid;

    public GameObject[] cells;
    public int currentQueen;
    public Color[] queensColor = new Color[8];
	// Use this for initialization
	void Start () {
        int totalNumber = rowsColumns * rowsColumns;
        cells = new GameObject[totalNumber];

        int row = 0;
        int column = 0;
        for (int i = 0; i < cells.Length; i++)
        {
            
            cells[i] = grid.transform.GetChild(i).gameObject;
            if (column % 8 == 0 && column >1) row++;
            cells[i].GetComponent<CellStatus>().row = row;
            cells[i].GetComponent<CellStatus>().column= column%8;

            column++;
            if ((i+row)%2 == 1)
            {
                cells[i].GetComponent<CellStatus>().ChangeColor(Color.white);

            }
            else
            {
                cells[i].GetComponent<CellStatus>().ChangeColor(Color.black);

            }
            
        }

    }

    public void AttackTheRest(int row, int column)
    {
        foreach(GameObject cell in cells)
        {
            int cellRow = cell.GetComponent<CellStatus>().row;
            int cellColumn = cell.GetComponent<CellStatus>().column;
            Vector2 cellCoordinates = new Vector2(cellRow, cellColumn);
            Vector2 queenCoordinates = new Vector2(row, column);

            if (!cell.GetComponent<CellStatus>().attacked)
                {
                if (cellRow == row || cellColumn == column || CheckDiagonals(cellCoordinates,queenCoordinates))
                {
                    cell.GetComponent<CellStatus>().attacked = true;
                    cell.GetComponent<CellStatus>().IsAttacked(queensColor[currentQueen]);
                }
                else
                {


                    
                    //diagonal arriba derecha
                    //diagonal arriba izquierda
                    //diagonal abajo derecha
                    //diagonal abajo izquierda
                }
            }

        }
        currentQueen++;
    }

    bool CheckDiagonals(Vector2 cellCoord, Vector2 queenCoord)
    {
        Vector2 v2 = new Vector2(1, 1);
        if (cellCoord.x - queenCoord.x == cellCoord.y - queenCoord.y || queenCoord.x - cellCoord.x == cellCoord.y - queenCoord.y) return true;
        return false;
        /*for (int i = 0; i<8;i++)
        { 
            if (queenCoord + v2*i == cellCoord)
            {
                return true;
            }
        }
        return false;*/
    }
	// Update is called once per frame
    public int SearchNextEmpty()
    {
        int cellsChecked = 0;
        int emptyCell = Random.Range(0, cells.Length);
        while(cellsChecked < 65)
        {
            cellsChecked++;
            if (!cells[(emptyCell + cellsChecked) % 64].GetComponent<CellStatus>().attacked)
            {
                return (emptyCell+cellsChecked)%64;
            }

        }

        return 0;
    }
	void Update () {

    }
}
