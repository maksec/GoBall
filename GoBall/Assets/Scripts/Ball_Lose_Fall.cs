using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Lose_Fall : MonoBehaviour
{
    public GameObject game_status;
    public GameObject Current_Score;
    private void OnCollisionExit(Collision other) {
        if (other.gameObject.tag == "Platform") {
            game_status.transform.position = new Vector3(3, 0, 0);
            if (PlayerPrefs.GetInt("BestScore") < Current_Score.transform.position.x) {
                PlayerPrefs.SetInt("BestScore", (int) Current_Score.transform.position.x);
                PlayerPrefs.Save();
            }
        }
    }
}
