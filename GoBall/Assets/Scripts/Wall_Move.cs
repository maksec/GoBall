using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wall_Move : MonoBehaviour
{
    public GameObject game_status;
    public GameObject game_speed;
    public GameObject Current_Score;
    public GameObject Ball, resp;
    public Text Score;
    public GameObject Audio;
    public GameObject Easy_Wall, Med_Wall, Hard_Wall;
    private AudioSource Audios;

    bool done = false;
    bool respawned = false;
    public float speed;

    private void Start() {
        Audios = Audio.GetComponent<AudioSource>();
    }
    void FixedUpdate()
    {
        if (game_status.transform.position.x == 2) {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z - game_speed.transform.transform.position.x * speed / 1000);
            if (transform.position.z <= -0.2 && !done) {
                done = true;
                Current_Score.transform.position = new Vector3(Current_Score.transform.position.x + 0.5f, 0 ,0);
                int cur_cs = (int)Current_Score.transform.position.x;
                string skr = "";
                while (cur_cs != 0) {
                    skr += (char)('0' + cur_cs % 10);
                    cur_cs /= 10;
                }
                int n = skr.Length;
                string ans = "";
                for (int i = n - 1; i >= 0; --i) {
                    ans += skr[i];
                }
                Score.text = ans;
                Audios.Play();
            }
            if (transform.position.z <= 1 && !respawned && resp.transform.position.x == 1) {
                resp.transform.position = new Vector3(0, 0, 0);
                respawned = true;
                if ((int)Current_Score.transform.position.x <= 10) {
                    int value = Random.Range(1, 101);
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
                } else if ((int)Current_Score.transform.position.x <= 17) {
                    int value = Random.Range(1, 101);
                    if (value >= 1 && value <= 70) {
                        float x = Random.Range(-1f, 1f);
                        GameObject neww = Instantiate(Easy_Wall, new Vector3((x - 3.5f)/2f, 1, 24), Quaternion.identity);
                        neww.transform.localScale = new Vector3(x + 1.5f, 1, 1);
                        neww = Instantiate(Easy_Wall, new Vector3((x + 3.5f)/2f, 1, 24), Quaternion.identity);
                        neww.transform.localScale = new Vector3(1.5f - x, 1, 1);
                    } else if (value > 70 && value <= 100) {
                        float x = Random.Range(-1.2f, 1.2f);
                        GameObject neww = Instantiate(Med_Wall, new Vector3((x - 3.3f)/2f, 1, 24), Quaternion.identity);
                        neww.transform.localScale = new Vector3(x + 1.7f, 1, 1);
                        neww = Instantiate(Med_Wall, new Vector3((x + 3.3f)/2f, 1, 24), Quaternion.identity);
                        neww.transform.localScale = new Vector3(1.7f - x, 1, 1);
                    }
                } else if ((int)Current_Score.transform.position.x <= 23) {
                    int value = Random.Range(1, 101);
                    if (value >= 1 && value <= 55) {
                        float x = Random.Range(-1f, 1f);
                        GameObject neww = Instantiate(Easy_Wall, new Vector3((x - 3.5f)/2f, 1, 24), Quaternion.identity);
                        neww.transform.localScale = new Vector3(x + 1.5f, 1, 1);
                        neww = Instantiate(Easy_Wall, new Vector3((x + 3.5f)/2f, 1, 24), Quaternion.identity);
                        neww.transform.localScale = new Vector3(1.5f - x, 1, 1);
                    } else if (value > 55 && value <= 85) {
                        float x = Random.Range(-1.2f, 1.2f);
                        GameObject neww = Instantiate(Med_Wall, new Vector3((x - 3.3f)/2f, 1, 24), Quaternion.identity);
                        neww.transform.localScale = new Vector3(x + 1.7f, 1, 1);
                        neww = Instantiate(Med_Wall, new Vector3((x + 3.3f)/2f, 1, 24), Quaternion.identity);
                        neww.transform.localScale = new Vector3(1.7f - x, 1, 1);
                    } else if (value > 85 && value <= 100) {
                        float x = Random.Range(-1.3f, 1.3f);
                        GameObject neww = Instantiate(Hard_Wall, new Vector3((x - 3.15f)/2f, 1, 24), Quaternion.identity);
                        neww.transform.localScale = new Vector3(x + 1.8f, 1, 1);
                        neww = Instantiate(Hard_Wall, new Vector3((x + 3.15f)/2f, 1, 24), Quaternion.identity);
                        neww.transform.localScale = new Vector3(1.8f - x, 1, 1);
                    }
                } else {
                    int value = Random.Range(1, 101);
                    if (value >= 1 && value <= 33) {
                        float x = Random.Range(-1f, 1f);
                        GameObject neww = Instantiate(Easy_Wall, new Vector3((x - 3.5f)/2f, 1, 24), Quaternion.identity);
                        neww.transform.localScale = new Vector3(x + 1.5f, 1, 1);
                        neww = Instantiate(Easy_Wall, new Vector3((x + 3.5f)/2f, 1, 24), Quaternion.identity);
                        neww.transform.localScale = new Vector3(1.5f - x, 1, 1);
                    } else if (value > 33 && value <= 66) {
                        float x = Random.Range(-1.2f, 1.2f);
                        GameObject neww = Instantiate(Med_Wall, new Vector3((x - 3.3f)/2f, 1, 24), Quaternion.identity);
                        neww.transform.localScale = new Vector3(x + 1.7f, 1, 1);
                        neww = Instantiate(Med_Wall, new Vector3((x + 3.3f)/2f, 1, 24), Quaternion.identity);
                        neww.transform.localScale = new Vector3(1.7f - x, 1, 1);
                    } else if (value > 66 && value <= 100) {
                        float x = Random.Range(-1.3f, 1.3f);
                        GameObject neww = Instantiate(Hard_Wall, new Vector3((x - 3.15f)/2f, 1, 24), Quaternion.identity);
                        neww.transform.localScale = new Vector3(x + 1.8f, 1, 1);
                        neww = Instantiate(Hard_Wall, new Vector3((x + 3.15f)/2f, 1, 24), Quaternion.identity);
                        neww.transform.localScale = new Vector3(1.8f - x, 1, 1);
                    }
                }
            } else if (transform.position.z <= 1 && !respawned && resp.transform.position.x == 0) {
                resp.transform.position = new Vector3(1, 0, 0);
                respawned = true;
            }
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Del_Plat") {
            Destroy(gameObject);
        } else if (other.gameObject.tag == "Ball") {
            game_status.transform.position = new Vector3(3, 0, 0);
            if (PlayerPrefs.GetInt("BestScore") < Current_Score.transform.position.x) {
                PlayerPrefs.SetInt("BestScore", (int) Current_Score.transform.position.x);
                PlayerPrefs.Save();
            }
        }
    }
}
