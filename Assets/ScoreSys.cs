using UnityEngine;
using TMPro;

public class ScoreSys : MonoBehaviour
{
    public float Score;
    public TMP_Text Scoretext; // Changez Text par TMP_Text
    
    void Start()
    {
        Score = 0;
    }
    void Update()
    {
        Scoretext.text = "Score : " + Score.ToString();
    }

    public void AddScore()
    {
        Score ++;
    }
}