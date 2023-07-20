using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{

    #region instance
    public int scoreInt=0;
    public TMP_Text Score;
    public static GameManager instance;
    private void Awake()
    {
        
        if(instance!=null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }
    #endregion


    public delegate void OnPlay(bool isplay);
    public OnPlay onPlay;
    public float gameSpeed = 1;
    
    public bool isPlay = false;
    public GameObject playBtn;
    public void PlayBtnClick()
    {
        
        playBtn.SetActive(false);
        isPlay=true;
        StartCoroutine(ScoreGet());
        onPlay.Invoke(isPlay);
        
    }
    IEnumerator ScoreGet()
    {

        while(isPlay){
            scoreInt+=1;
            yield return new WaitForSeconds(1f);
        }
    }
    public void GameOver()
    {
        
         scoreInt=0;
         playBtn.SetActive(true);
         isPlay=false;
         onPlay.Invoke(isPlay);
    }
    public void Update()
    {
        
        Score.text = "Score : "+scoreInt.ToString();
    }

}
