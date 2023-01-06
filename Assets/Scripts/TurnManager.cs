using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    
    public Player1Move player1Move;
    public Player2Move player2Move;
    public Player3Move player3Move;
    public Player4Move player4Move;
    [HideInInspector]
    public int diceResult;
    public int playerTurn = 1;
    public int totalPlayers;
    public int whosTurn;

    [SerializeField] PlayerConfig numberOfPlayers;
    
    //public int numberOfPlayers;

    // Start is called before the first frame update
    void Start()
    {
        totalPlayers = numberOfPlayers.GetNumberOfPlayers();
    }

    public void GetTurn(int diceSide)
    {
        
        StartCoroutine(changeTurn(diceSide));
        
    }

    IEnumerator MovePlayer(int diceSide, int playerTurn)
    {
       switch (playerTurn) {
           case 1:
                player1Move.GetDiceSide(diceSide);
                break;
            case 2:
                player2Move.GetDiceSide(diceSide);
                break;
            case 3:
                player3Move.GetDiceSide(diceSide);
                break;
            case 4:
                player4Move.GetDiceSide(diceSide);
                break;
            default:
                break;
       }
        yield return new WaitForSeconds(1f);
          
    }

    IEnumerator changeTurn(int diceSide)
    {
        StartCoroutine(MovePlayer(diceSide, playerTurn));
        if (diceSide == 2 || diceSide == 3 || diceSide == 4 || diceSide == 5)
        {
            if (playerTurn < totalPlayers)
            {
                playerTurn += 1;
            }
            else
            {
                playerTurn = 1;
            }
            
            yield return new WaitForSeconds(0.1f);
            //MovePlayer(diceSide, playerTurn);
            Debug.Log("nextPlayer" + playerTurn);
            
        }
        else if (diceSide == 1 || diceSide == 6) {
            
            yield return new WaitForSeconds(0.1f);
            //MovePlayer(diceSide, playerTurn);
            Debug.Log("samePlayer" + playerTurn);
            
            
        }
        //Debug.Log("whosturn" + playerTurn);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
