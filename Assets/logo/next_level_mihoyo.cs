using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class next_level_mihoyo : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene(1,LoadSceneMode.Single);
    }
}
