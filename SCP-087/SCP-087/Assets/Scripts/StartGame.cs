using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class StartGame : MonoBehaviour
{
    public Button startButton;
    public Slider slider;

    private void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        startButton = root.Q<Button>("start-button");
        slider = root.Q<Slider>();

        startButton.clicked += StartButtonPressed;
    }

    private void StartButtonPressed()
    {
        GlobalReferences.ScreamerChanse = (int)slider.value;
        SceneManager.LoadScene("Game");
    }
}
