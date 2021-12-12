using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartMenu : MonoBehaviour
{
    // Start is called before the first frame updat    
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

public void backGame()
{
    SceneManager.LoadScene(0);
}

}
