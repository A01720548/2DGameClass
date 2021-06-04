using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public int items;
    public Text scoreBoard;
    // Start is called before the first frame update
    void Start()
    {
        scoreBoard.text = "Score: " + items;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void reollectItems (int points) {
        items += points;
        scoreBoard.text = "Score: " + items;

    } 
}
