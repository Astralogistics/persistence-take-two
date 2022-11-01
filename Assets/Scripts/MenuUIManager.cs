using System.Collections;
using System.Collections.Generic;
//This should prevent errors when closing the game outside of Unity, since we used conditional compiling on our exit button
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour
{
    public InputField nameEntry;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //this method loads a scene from the scene index. We attach this method to the "on click" property of the Start button
    //(Unity did this for us when we saved the script!)
    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    //this  method exits! We use conditional compiling to tell the game how to exit, based on where it's loaded
    //because we use EditorApplication here, we'll need to use conditional compiling to tell the game how to ignore
    //this when it's loaded as an app; as-is, it'll give us an error if we try to exit when we're playing outside Unity
    public void Exit()
    {
        ScoreManager.instance.SaveScore();
    #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
    #else
            Application.Quit();
    #endif
    }

    
}
