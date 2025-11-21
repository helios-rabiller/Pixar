using UnityEngine;
using System.Collections;   
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("Pixar");
    }

}
