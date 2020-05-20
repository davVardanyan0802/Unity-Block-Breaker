using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float min = 1f;
    [SerializeField] float max = 15f;
    [SerializeField] float screenWithInUnits = 16f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float mousePosInUnits =    Input.mousePosition.x / Screen.width * screenWithInUnits;
        Vector2 paddlePos = new Vector2(transform.position.x,transform.position.y);
        paddlePos.x = Mathf.Clamp(mousePosInUnits,min,max); 
        transform.position = paddlePos;
    }
}
