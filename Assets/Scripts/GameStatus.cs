using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    //config parameters
    [Range(0.1f,10f)][SerializeField] float gameSpeed=1f;
    [SerializeField] float scorePerBlock=5;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;
    
    //state variable

    [SerializeField] float score=0;

    private void Awake() {
        {
            int gameStatusCount=FindObjectsOfType<GameStatus>().Length; 
            if(gameStatusCount>1)
            {
                gameObject.SetActive(false);
                Destroy(gameObject);
            }    
            else
            {
                DontDestroyOnLoad(gameObject);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText.text=score.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale=gameSpeed;
        
    }
    public void scoreAdder()
    {
        score+=scorePerBlock;
        scoreText.text=score.ToString();
    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }
    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }
}
