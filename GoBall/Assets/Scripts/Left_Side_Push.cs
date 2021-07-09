using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left_Side_Push : MonoBehaviour
{
    public GameObject ball;
    public float ball_r_l_move_speed;
    private bool clickedis = false;
    public GameObject game_status;
    public GameObject game_speed;

    private void OnMouseDown() {
        clickedis = true;
    }

    private void OnMouseUp() {
        clickedis = false;
    }

    private void FixedUpdate() {
        if (game_status.transform.position.x == 2) {
            if (clickedis) {
                ball.transform.position = new Vector3((ball.transform.position.x - ball_r_l_move_speed / 1000) * game_speed.transform.position.x, ball.transform.position.y, ball.transform.position.z);
            }
        }
    }
}
