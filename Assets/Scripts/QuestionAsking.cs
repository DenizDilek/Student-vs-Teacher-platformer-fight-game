using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class QuestionAsking : MonoBehaviour
{
    public static bool Question = false;
    public bool isTrue = false ;
    public Text text1;
    public InputField input1;
    private int x;
    private int y;
    private int answer;
    private string youranswer;
    public float Counter = 2f;
    
    
       
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Start()
    {
        
    }
    void Update()
    {
        desiredCounter -= 1 * Time.deltaTime;
        if(isTrue != true && desiredCounter>0) {
            gameObject.SetActive(true);
        }
        else
        {
           
            gameObject.SetActive(false);
            if (isTrue == false)
            {
                GameManager.isDead = true;
            }
            else
            {
                GameManager.isHit = false;
            }
        }
    }
    private float desiredCounter = 0f;
    public void BringQuestion()
    {
        desiredCounter = Counter;
        Question = true;
        System.Random rand = new System.Random();
        x = rand.Next(0, 20);
        y = rand.Next(0, 20);
        int sec = rand.Next(1, 3);
        switch (sec) {
            case 1:
                answer = x + y;
                text1.text = x.ToString() + "+" + y.ToString()+ "= ?";
                break;
            case 2:
                answer = x * y;
                text1.text = x.ToString() + "*" + y.ToString() + "= ?";
                break;
            case 3:
                answer = x - y;
                text1.text = x.ToString() + "-" + y.ToString() + "= ?";
                break;

        }
       
            
    }
    public void GetInput(string guess)
    {

        
        
        if (answer.ToString() == guess)
        {
            gameObject.SetActive(false);
            Question = false;
            
            
        }
        else
        {
            isTrue = false;
            
            GameManager.isDead = true;
        }
        input1.text = "";
    }
}
