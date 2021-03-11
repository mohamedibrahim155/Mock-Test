using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Scoremanager : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
  public  float score;
    public static Scoremanager instance;
    private void Awake()
    {
        if (instance==null)
        {
            instance = this;

        }
        else
        {
            Destroy(instance);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        score = 800f;
        ScoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (score<=0)
        {
            SceneManager.LoadScene(2);
        }
        ScoreText.text = score.ToString();
    }

   
}
