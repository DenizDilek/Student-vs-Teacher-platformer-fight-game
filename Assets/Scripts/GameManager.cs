using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public GameObject gameoverui;
    public GameObject Questionui;
    public static bool isDead = false;
    public static bool isHit = false;
    
    Freezer freezer;
    QuestionAsking que;
    public float Counter = 2f;
    private float desiredCounter = 0f;
    // Start is called before the first frame update
    void Awake()
    {
        if(gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>();
            freezer = GameObject.FindGameObjectWithTag("GM").GetComponent<Freezer>();
            que = Questionui.GetComponent<QuestionAsking>();
           
        }
    }
    void Update()
    {
        if (isDead == true)
        {
            gm.EndGame();

        }
        else if (isHit == true)
        {
            Question();
            StartCoroutine(QuestionSolveWaiting());
            

            isHit = false;
            
        }
    }
    public void EndGame()
    {
        gameoverui.SetActive(true);
    }
    public void Question()
    {
        Questionui.SetActive(true);   
        que.BringQuestion();
       
    }
    public void QuestionResult()
    {
        if(que.isTrue == true) {
            Questionui.SetActive(false);
        }
        else
        {
            Questionui.SetActive(false);
            isDead = true;
            
        }
    }
    IEnumerator QuestionSolveWaiting()
    {
        yield return new WaitForSeconds(5f);
    }
    
}
