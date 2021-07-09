using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Game_Controller : MonoBehaviour
{
    public GameObject game_status; // transform.x == 1 -> just runned game. 2 -> game in progress. 3 -> game over
    public GameObject game_settings; // x: 1 - volume, 2 - no volume. y: 1 - ads, 2 - no ads
    public GameObject ball;
    Transform ball_tr;
    Rigidbody ball_rb;
    public int speed;
    public Image TapToPlay;
    public Image GameName;
    public Text Score, BestScore, TextScore, TextBestScore;
    public Button Shop, Leaderboard, restart, volume_on, volume_off, no_ads;
    bool volume, ads;
    float best_score;
    float cur_score;
    public GameObject leftSide, rightSide;
    public GameObject Easy_Wall, Med_Wall, Hard_Wall;
    public GameObject Current_Score;
    void Start()
    {
        // 2, 1.6, 1.4
        int value = Random.Range(1, 101);
        if (value >= 1 && value <= 85) {
            float x = Random.Range(-1f, 1f);
            GameObject neww = Instantiate(Easy_Wall, new Vector3((x - 3.5f)/2f, 1, 6), Quaternion.identity);
            neww.transform.localScale = new Vector3(x + 1.5f, 1, 1);
            neww = Instantiate(Easy_Wall, new Vector3((x + 3.5f)/2f, 1, 6), Quaternion.identity);
            neww.transform.localScale = new Vector3(1.5f - x, 1, 1);
        } else if (value > 85 && value <= 100) {
            float x = Random.Range(-1.2f, 1.2f);
            GameObject neww = Instantiate(Med_Wall, new Vector3((x - 3.3f)/2f, 1, 6), Quaternion.identity);
            neww.transform.localScale = new Vector3(x + 1.7f, 1, 1);
            neww = Instantiate(Med_Wall, new Vector3((x + 3.3f)/2f, 1, 6), Quaternion.identity);
            neww.transform.localScale = new Vector3(1.7f - x, 1, 1);
        }
        value = Random.Range(1, 101);
        if (value >= 1 && value <= 85) {
            float x = Random.Range(-1f, 1f);
            GameObject neww = Instantiate(Easy_Wall, new Vector3((x - 3.5f)/2f, 1, 12), Quaternion.identity);
            neww.transform.localScale = new Vector3(x + 1.5f, 1, 1);
            neww = Instantiate(Easy_Wall, new Vector3((x + 3.5f)/2f, 1, 12), Quaternion.identity);
            neww.transform.localScale = new Vector3(1.5f - x, 1, 1);
        } else if (value > 85 && value <= 100) {
            float x = Random.Range(-1.2f, 1.2f);
            GameObject neww = Instantiate(Med_Wall, new Vector3((x - 3.3f)/2f, 1, 12), Quaternion.identity);
            neww.transform.localScale = new Vector3(x + 1.7f, 1, 1);
            neww = Instantiate(Med_Wall, new Vector3((x + 3.3f)/2f, 1, 12), Quaternion.identity);
            neww.transform.localScale = new Vector3(1.7f - x, 1, 1);
        }
        value = Random.Range(1, 101);
        if (value >= 1 && value <= 85) {
            float x = Random.Range(-1f, 1f);
            GameObject neww = Instantiate(Easy_Wall, new Vector3((x - 3.5f)/2f, 1, 18), Quaternion.identity);
            neww.transform.localScale = new Vector3(x + 1.5f, 1, 1);
            neww = Instantiate(Easy_Wall, new Vector3((x + 3.5f)/2f, 1, 18), Quaternion.identity);
            neww.transform.localScale = new Vector3(1.5f - x, 1, 1);
        } else if (value > 85 && value <= 100) {
            float x = Random.Range(-1.2f, 1.2f);
            GameObject neww = Instantiate(Med_Wall, new Vector3((x - 3.3f)/2f, 1, 18), Quaternion.identity);
            neww.transform.localScale = new Vector3(x + 1.7f, 1, 1);
            neww = Instantiate(Med_Wall, new Vector3((x + 3.3f)/2f, 1, 18), Quaternion.identity);
            neww.transform.localScale = new Vector3(1.7f - x, 1, 1);
        }
        value = Random.Range(1, 101);
        if (value >= 1 && value <= 85) {
            float x = Random.Range(-1f, 1f);
            GameObject neww = Instantiate(Easy_Wall, new Vector3((x - 3.5f)/2f, 1, 24), Quaternion.identity);
            neww.transform.localScale = new Vector3(x + 1.5f, 1, 1);
            neww = Instantiate(Easy_Wall, new Vector3((x + 3.5f)/2f, 1, 24), Quaternion.identity);
            neww.transform.localScale = new Vector3(1.5f - x, 1, 1);
        } else if (value > 85 && value <= 100) {
            float x = Random.Range(-1.2f, 1.2f);
            GameObject neww = Instantiate(Med_Wall, new Vector3((x - 3.3f)/2f, 1, 24), Quaternion.identity);
            neww.transform.localScale = new Vector3(x + 1.7f, 1, 1);
            neww = Instantiate(Med_Wall, new Vector3((x + 3.3f)/2f, 1, 24), Quaternion.identity);
            neww.transform.localScale = new Vector3(1.7f - x, 1, 1);
        }

        ball_rb = ball.GetComponent<Rigidbody>();
        ball_tr = ball.GetComponent<Transform>();
        Score.text = "0";
        game_status.transform.position = new Vector3(1f, 0f, 0f); // ставим игру в начало
        Shop.gameObject.SetActive(true);
        Leaderboard.gameObject.SetActive(true);
        restart.gameObject.SetActive(false);
        volume_on.gameObject.SetActive(true);
        volume_off.gameObject.SetActive(false);
        no_ads.gameObject.SetActive(true);
        Score.gameObject.SetActive(false);
        GameName.gameObject.SetActive(true);
        TapToPlay.gameObject.SetActive(true);
        leftSide.gameObject.SetActive(false);
        rightSide.gameObject.SetActive(false);
        volume = true;
        ads = true; // нужно сохранять настройки!!!!!!
        best_score = 0;
        cur_score = 0;
    }

    
    void Update()
    {
        if (game_status.transform.position.x == 1) {
            if (Input.touchCount > 0 || Input.GetKeyDown(KeyCode.R)) {
                game_status.transform.position = new Vector3(2f, 0f, 0f); // игра началась
                Shop.gameObject.SetActive(false);
                Leaderboard.gameObject.SetActive(false);
                restart.gameObject.SetActive(false);
                volume_on.gameObject.SetActive(false);
                volume_off.gameObject.SetActive(false);
                no_ads.gameObject.SetActive(false);
                Score.gameObject.SetActive(true);
                TextScore.gameObject.SetActive(false);
                BestScore.gameObject.SetActive(false);
                TextBestScore.gameObject.SetActive(false);
                GameName.gameObject.SetActive(false);
                TapToPlay.gameObject.SetActive(false);
                leftSide.gameObject.SetActive(true);
                rightSide.gameObject.SetActive(true);
                Current_Score.transform.position = new Vector3(0, 0, 0);
                Score.text = "0";
            }
        } else if (game_status.transform.position.x == 2) {
            
        } else if (game_status.transform.position.x == 3) {
            Shop.gameObject.SetActive(false);
            Leaderboard.gameObject.SetActive(false);
            restart.gameObject.SetActive(true);
            volume_on.gameObject.SetActive(false);
            volume_off.gameObject.SetActive(false);
            no_ads.gameObject.SetActive(false);
            Score.gameObject.SetActive(true);
            TextScore.gameObject.SetActive(true);
            BestScore.gameObject.SetActive(true);
            TextBestScore.gameObject.SetActive(true);
            GameName.gameObject.SetActive(false);
            TapToPlay.gameObject.SetActive(false);
            leftSide.gameObject.SetActive(false);
            rightSide.gameObject.SetActive(false);
            cur_score = Current_Score.transform.position.x;

            int cur_best = PlayerPrefs.GetInt("BestScore");
            string skr = "";
            while (cur_best != 0) {
                skr += (char)('0' + cur_best % 10);
                cur_best /= 10;
            }
            int n = skr.Length;
            string ans = "";
            for (int i = n - 1; i >= 0; --i) {
                ans += skr[i];
            }
            BestScore.text = ans;
        }
    }
}
