using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlay : MonoBehaviour
{
    public Player player;
    public int heart_num = 3;
    public List<GameObject> hearts = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
       
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }


     public void Restart()
    {
        player.PlayerReset();
        heart_num = 3;
        for (int i = 0; i < hearts.Count; i++)
        {
            hearts[i].SetActive(true);
        }
        GameObject.Find("Canvas").transform.Find("GameClear").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("gameover").gameObject.SetActive(false);
        GameObject.Find("Canvas").transform.Find("Title").gameObject.SetActive(true);
        
    }
}
