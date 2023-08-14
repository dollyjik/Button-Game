using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] TextMeshProUGUI total;
    [SerializeField] TextMeshProUGUI high;
    public int posibility = 0;
    public int highScore = 0;
    public int totalTry = 0;

    private AudioSource button;

    public AudioClip buttonSFX;
    
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClick()
    {
        totalTry++;
        total.text = "Total Try = " + totalTry;
        posibility++;
        text.text = "" + posibility;
        Debug.Log(posibility);
        if (posibility > 19)
        {
            button.PlayOneShot(buttonSFX, 0.01f);
        }
        if (posibility > 50)
        {
            SceneManager.LoadScene(1);
        }
        ScoreReset();
        
    }

    public void ScoreReset()
    {
        if (Random.Range(1, 100) < posibility)
        {
            if (highScore < posibility)
            {
                highScore = (posibility - 1);
                high.text = "Highscore = " + (posibility - 1);
            }
            
            text.text = "0";
            posibility = 0;
            
        }
    }
}
