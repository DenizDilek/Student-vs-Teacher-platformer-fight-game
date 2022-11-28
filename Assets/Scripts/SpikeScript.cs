using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D Info)
    {
        PlayerMove move = Info.GetComponent<PlayerMove>();
        move.isDying = true;
        move.animator.SetBool("isDying", move.isDying);
        if(Info.tag == "Player")
        {
            StartCoroutine(Dies());
        }

        Debug.Log(Info.name);
    }
    IEnumerator Dies()
    {
        yield return new WaitForSeconds(1);
        player.SetActive(false);

    }
}
