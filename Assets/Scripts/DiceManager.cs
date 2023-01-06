using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    private Sprite[] diceSides;

    private SpriteRenderer rend;

    public int finalSide;
     
    public TurnManager turnManager;

    // Start is called before the first frame update
    void Start()
    {

        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        
        
    }

    private void OnMouseDown()
    {
        
        StartCoroutine("RollTheDice");
        
    }

    private IEnumerator RollTheDice() {
        int randomDiceSides = 0;

        finalSide = 0;

        for (int i = 0; i <= 20; i++) {
            randomDiceSides = Random.Range(0, 6);
            rend.sprite = diceSides[randomDiceSides];

            yield return new WaitForSeconds(0.05f);
        }

        finalSide = randomDiceSides + 1;
        //Debug.Log("finalSide" + finalSide);
        turnManager.GetTurn(finalSide);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
