using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float min = 1f;
    [SerializeField] float max = 15f;
    [SerializeField] float screenWithInUnits = 16f;
    GameState theGameState;
    Ball theBall;
    // Start is called before the first frame update
    void Start()
    {
        theGameState = FindObjectOfType<GameState>();
        theBall = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), min, max);
        transform.position = paddlePos;
    }

    private float GetXPos(){
        if(theGameState.IsAutoPlayEnabled()){
            return theBall.transform.position.x;
        }
        else{
            return Input.mousePosition.x / Screen.width * screenWithInUnits;
        }
    }
}
