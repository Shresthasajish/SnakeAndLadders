using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player3Move : MonoBehaviour
{
    [SerializeField] PlayerConfig playerConfig;
    List<Transform> waypoints;
    [SerializeField] float speed = 20f;
    //[SerializeField] public GameObject player3Piece;
    GameObject greenPiece;
    private bool playerPresent = false;
    [SerializeField] Vector3 position;
    Vector3 startingPosition;
    private bool MoveToOne = false;
    int boardValue = 0;
    
    private bool OnBoardMove = false;
    // Start is called before the first frame update
    void Start()
    {
        //player3Piece = playerConfig.GetPlayer3Prefab();
        waypoints = playerConfig.GetGamePath();
        position = waypoints[0].transform.position;
        startingPosition = transform.position;
        //Debug.Log(waypoints);
    }

    public void GetDiceSide(int diceSide)
    {
        StartCoroutine(CheckIfPlayerOnBoard(diceSide));
    }

    IEnumerator CheckIfPlayerOnBoard(int diceSide)
    {
        //Debug.Log("Player1GetDice");
        for (int i = 0; i < 100; i++)
        {
            if (waypoints[i].transform.position == transform.position)
            {
                playerPresent = true;

            }

        }

        yield return new WaitForSeconds(0.1f);
        if (playerPresent)
        {
            StartCoroutine(onBoardMove(diceSide));
        }
        else
        {
            StartCoroutine(onStartingMove(diceSide));
        }
    }

    IEnumerator onStartingMove(int diceSide)
    {
        //Debug.Log("StartingMove");
        if (diceSide == 1 || diceSide == 6)
        {
            MoveToOne = true;
        }
        yield return new WaitForSeconds(0.2f);
    }
    IEnumerator onBoardMove(int diceSide)
    {
        //Debug.Log("onBoardMove");
        //Debug.Log("onBoardMove");
        StartCoroutine(CheckIfPlayerOnLadder(diceSide));
        OnBoardMove = true;
        position = waypoints[boardValue + diceSide].transform.position;
        boardValue += diceSide;
        yield return new WaitForSeconds(0.2f);

    }



    // Update is called once per frame
    void Update()
    {
        if (MoveToOne)
        {
            //Debug.Log("NotMoving"); 
            //Debug.Log(position);
            transform.position = Vector3.MoveTowards(transform.position, position, speed * Time.deltaTime);
        }
        if (OnBoardMove)
        {


        }
    }

    IEnumerator CheckIfPlayerOnLadder(int diceSide)
    {
        if (boardValue == 3)
        {
            transform.position = Vector3.Lerp(transform.position, waypoints[24].transform.position, speed * Time.deltaTime);
            boardValue = 24;
        }
        if (boardValue == 12)
        {
            transform.position = Vector3.Lerp(transform.position, waypoints[45].transform.position, speed * Time.deltaTime);
            boardValue = 45;
        }
        if (boardValue == 32)
        {
            transform.position = Vector3.Lerp(transform.position, waypoints[48].transform.position, speed * Time.deltaTime);
            boardValue = 48;
        }
        if (boardValue == 49)
        {
            transform.position = Vector3.Lerp(transform.position, waypoints[68].transform.position, speed * Time.deltaTime);
            boardValue = 68;
        }
        if (boardValue == 41)
        {
            transform.position = Vector3.Lerp(transform.position, waypoints[62].transform.position, speed * Time.deltaTime);
            boardValue = 62;
        }
        if (boardValue == 61)
        {
            transform.position = Vector3.Lerp(transform.position, waypoints[80].transform.position, speed * Time.deltaTime);
            boardValue = 80;
        }
        if (boardValue == 73)
        {
            transform.position = Vector3.Lerp(transform.position, waypoints[91].transform.position, speed * Time.deltaTime);
            boardValue = 91;
        }
        if (boardValue == 39)
        {
            transform.position = Vector3.Lerp(transform.position, waypoints[91].transform.position, speed * Time.deltaTime);
            boardValue = 2;
        }
        if (boardValue == 88)
        {
            transform.position = Vector3.Lerp(transform.position, waypoints[91].transform.position, speed * Time.deltaTime);
            boardValue = 52;
        }
        if (boardValue == 86)
        {
            transform.position = Vector3.Lerp(transform.position, waypoints[91].transform.position, speed * Time.deltaTime);
            boardValue = 36;
        }
        if (boardValue == 97)
        {
            transform.position = Vector3.Lerp(transform.position, waypoints[91].transform.position, speed * Time.deltaTime);
            boardValue = 40;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, position, speed * Time.deltaTime);

        }
        yield return new WaitForSeconds(4f);

    }
}
