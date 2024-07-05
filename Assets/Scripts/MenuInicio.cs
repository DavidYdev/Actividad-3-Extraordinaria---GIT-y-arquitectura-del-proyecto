using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tutorial.Transition
{
public class MenuInicio : MonoBehaviour
{
public void LoadGameScene()
{
    TransitionManager.Instance.LoadScene(TransitionManager.level_1);
}

public void Salir(){
    Debug.Log("Salir...");
    Application.Quit();
}
}
}
