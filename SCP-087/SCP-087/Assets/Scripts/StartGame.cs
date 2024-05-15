using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class StartGame : MonoBehaviour
{
    public Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        startButton = root.Q<Button>("start-button");

        startButton.clicked += StartButtonPressed;
    }

    void StartButtonPressed()
    {
        SceneManager.LoadScene("Game");
    }
}
