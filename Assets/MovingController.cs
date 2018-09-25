using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingController : MonoBehaviour {

    Vector3 initialTransform = new Vector3 (0,0,0);
    public Transform fixedTransform;

    public enum PossibleMoves
    {
        StraightForward,
        Rotate,
        PatrolOne,
        PatrolSeveral,
    }
    public PossibleMoves currentMove;
    public float charSpeed;
    public float charRotationSpeed;
    public GameObject charGoalPosition;
    public GameObject[] charGoalPoints;

    bool straightForward;
    bool rotate;
    bool patrol;
   

    //Patrolling variables
    public int nextPointToCheck = 1;
    public Vector3[] positions; 

    // Use this for initialization
    void Start() {
        initialTransform = transform.position;

        if (currentMove == PossibleMoves.StraightForward)
        {
            straightForward = true;
        }
        else if (currentMove == PossibleMoves.Rotate)
        {
            rotate = true;
        }
        else if (currentMove == PossibleMoves.PatrolOne)
        {
            Vector3[] positions = new Vector3[2];
            positions[0] = initialTransform;
            positions[1] = charGoalPosition.transform.position;
            patrol = true;
        }
        else
        { 
            //Includes origin as extra point
            positions = new Vector3[charGoalPoints.Length+1];
            positions[0] = initialTransform;
            for (int i = 1; i < positions.Length; i++ )
            {
                positions[i] = charGoalPoints[i - 1].transform.position;
            }
            patrol = true;


        }
    }

    // Update is called once per frame
    void Update() {
        if (straightForward)
        {
            MoveStraightForward();
        }
        else if (rotate)
        {
            RotateItself();
        }
        else if (patrol)
        {
 
            Patrol(positions);
        }

    }

    public void MoveStraightForward()
    {
        fixedTransform.position += Vector3.forward * Time.deltaTime * charSpeed;
    }

    public void RotateItself()
    {
        fixedTransform.Rotate(Vector3.up * Time.deltaTime * charRotationSpeed);
    }

    public void Patrol(Vector3[] positions)
    {
        fixedTransform.position = Vector3.MoveTowards(transform.position, positions[nextPointToCheck], charSpeed * Time.deltaTime);

        //Checks if it has arrived and change objective if so
        if (Vector3.Distance(transform.position, positions[nextPointToCheck]) < 0.001f )
        {
            ++nextPointToCheck;
            nextPointToCheck %= positions.Length;
            fixedTransform.LookAt(positions[nextPointToCheck]);

        }

       
    }
}
