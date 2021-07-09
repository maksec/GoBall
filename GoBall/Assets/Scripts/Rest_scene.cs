using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rest_scene : MonoBehaviour
{
    public void Restarting() {
        SceneManager.LoadScene("main");
    }
}
