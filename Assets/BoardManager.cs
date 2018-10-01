using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardManager : MonoBehaviour
{

    public int rowsColumns;
    public GameObject grid;
    public GameObject cell;
    public GameObject[] cells;
    public int currentQueen;
    public Color[] queensColor = new Color[8];
    // Use this for initialization
    void Start()
    {
        InitializeBoard(rowsColumns);
        int totalNumber = rowsColumns * rowsColumns;
        cells = new GameObject[totalNumber];

        int row = 0;
        int column = 0;

        if (rowsColumns % 2 == 0)
        {
            for (int i = 0; i < cells.Length; i++)
            {

                cells[i] = grid.transform.GetChild(i).gameObject;
                if (column % rowsColumns == 0 && column > 1) row++;
                cells[i].GetComponent<CellStatus>().row = row;
                cells[i].GetComponent<CellStatus>().column = column % rowsColumns;

                column++;
                if ((i + row) % 2 == 1)
                {
                    cells[i].GetComponent<CellStatus>().ChangeColor(Color.white);

                }
                else
                {
                    cells[i].GetComponent<CellStatus>().ChangeColor(Color.black);

                }
            }
        }
        else
        {
            for (int i = 0; i < cells.Length; i++)
            {

                cells[i] = grid.transform.GetChild(i).gameObject;
                if (column % rowsColumns == 0 && column > 1) row++;
                cells[i].GetComponent<CellStatus>().row = row;
                cells[i].GetComponent<CellStatus>().column = column % rowsColumns;

                column++;
                if ((i) % 2 == 1)
                {
                    cells[i].GetComponent<CellStatus>().ChangeColor(Color.white);

                }
                else
                {
                    cells[i].GetComponent<CellStatus>().ChangeColor(Color.black);

                }
            }
        }

    }
    public void InitializeBoard(int rows)
    {
        grid.GetComponent<GridLayoutGroup>().cellSize = new Vector2(1024 / rows, 1024 / rows);



        for (int i = 0; i < rows * rows; i++)
        {
            Instantiate(cell, Vector3.zero, Quaternion.identity, grid.transform);
        }
    }
    public void AttackTheRest(int row, int column)
    {
        foreach (GameObject cell in cells)
        {
            int cellRow = cell.GetComponent<CellStatus>().row;
            int cellColumn = cell.GetComponent<CellStatus>().column;
            Vector2 cellCoordinates = new Vector2(cellRow, cellColumn);
            Vector2 queenCoordinates = new Vector2(row, column);

            if (!cell.GetComponent<CellStatus>().attacked)
            {
                if (cellRow == row || cellColumn == column || CheckDiagonals(cellCoordinates, queenCoordinates))
                {
                    cell.GetComponent<CellStatus>().attacked = true;
                    cell.GetComponent<CellStatus>().IsAttacked(queensColor[currentQueen % queensColor.Length]);
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
        while (cellsChecked < (rowsColumns * rowsColumns + 1))
        {
            cellsChecked++;
            if (!cells[(emptyCell + cellsChecked) % (rowsColumns * rowsColumns)].GetComponent<CellStatus>().attacked)
            {
                return (emptyCell + cellsChecked) % (rowsColumns * rowsColumns);
            }

        }

        return 0;
    }
    void Update()
    {

    }
}
