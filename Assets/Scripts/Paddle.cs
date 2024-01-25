using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
  [SerializeField] float screenWidthInUnits=16f;
  [SerializeField] float maxX=15f;
  [SerializeField] float minX=1f;
  //cached referecnes
  Ball ball;
  GameStatus gamestatus;
    // Start is called before the first frame update
    void Start()
    {
        ball=FindObjectOfType<Ball>();
        gamestatus=FindObjectOfType<GameStatus>();
    }

    // Update is called once per frame
    void Update()
    {
      
       
      Vector2 paddlePos =new Vector2(transform.position.x,transform.position.y);
      paddlePos.x= Mathf.Clamp(GetXPos(),minX,maxX);
      transform.position=paddlePos;
    }
    private float GetXPos()
    {
      if(gamestatus.IsAutoPlayEnabled())
      {
        return ball.transform.position.x;
      }
      else
      {
        return Input.mousePosition.x/Screen.width*screenWidthInUnits;
      }
    }
}
