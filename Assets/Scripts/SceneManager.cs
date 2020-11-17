using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{
    // text fields
    public Text time;
    public Text popped;
    public Text missed;
    public Button end;
    public Text endText;
    // associated variables
    private float t;
    private int p;
    private int m;
    //spawn point array
    public SpawnPoint[] spawnPoints = new SpawnPoint[7];
    //temp for scores
    private int n;
    

    // Start is called before the first frame update
    void Start()
    {
        p = 0;
        m = 0;
        end.interactable = false;
        endText.text = "";
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        updateNumbers();
        time.text = "" + System.Math.Round(Time.time, 2);
        popped.text = "" + p;
        missed.text = "" + m;

        if (m >= 10)
            endGame();
    }

    public void updateNumbers()
    {
        p = spawnPoints[0].nPopped + spawnPoints[1].nPopped + spawnPoints[2].nPopped + spawnPoints[3].nPopped + spawnPoints[4].nPopped + spawnPoints[5].nPopped + spawnPoints[6].nPopped;
        m = spawnPoints[0].nMissed + spawnPoints[1].nMissed + spawnPoints[2].nMissed + spawnPoints[3].nMissed + spawnPoints[4].nMissed + spawnPoints[5].nMissed + spawnPoints[6].nMissed;
    }

     public void endGame()
     {
        for(int i = 0; i <= spawnPoints.Length - 1; i++)
            spawnPoints[i].disabled = true;
        

         PlayerPrefs.SetInt("bubbleScore", p);
         PlayerPrefs.Save();
         endText.text = "Main Menu";
         end.interactable = true;
    }

}
