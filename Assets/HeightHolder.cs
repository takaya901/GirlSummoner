using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeightHolder : MonoBehaviour
{
    [SerializeField] TMP_InputField _field;
    
    void Start()
    {
        
    }

    public void SetHeight()
    {
        SceneManager.sceneLoaded += GameSceneLoaded;
        SceneManager.LoadScene("Main");
    }
    
    void GameSceneLoaded(Scene next, LoadSceneMode mode)
    {
        // シーン切り替え後のスクリプトを取得
        var summoner= GameObject.FindWithTag("GameController").GetComponent<Summoner>();
    
        // データを渡す処理
        summoner.Height = float.Parse(_field.text) / 100f;

        // イベントから削除
        SceneManager.sceneLoaded -= GameSceneLoaded;
    }
}
