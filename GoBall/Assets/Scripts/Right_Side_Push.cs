using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right_Side_Push : MonoBehaviour
{
    public GameObject ballr;
    public float ball_r_l_move_speedr;
    private bool clickedisr = false;
    public GameObject game_statusr;
    public GameObject game_speed;

    private void OnMouseDown() {
        clickedisr = true;
    }

    private void OnMouseUp() {
        clickedisr = false;
    }

    private void FixedUpdate() {
        if (game_statusr.transform.position.x == 2) {
            if (clickedisr) {
                ballr.transform.position = new Vector3((ballr.transform.position.x + ball_r_l_move_speedr / 1000) * game_speed.transform.position.x, ballr.transform.position.y, ballr.transform.position.z);
            }
        }
    }
}
