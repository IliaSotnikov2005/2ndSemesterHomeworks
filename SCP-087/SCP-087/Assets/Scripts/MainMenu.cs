// <copyright file="MainMenu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

/// <summary>
/// Represents main menu.
/// </summary>
public class MainMenu : MonoBehaviour
{
    private Button startButton;
    private Slider slider;

    private void Start()
    {
        var root = this.GetComponent<UIDocument>().rootVisualElement;

        this.startButton = root.Q<Button>("start-button");
        this.slider = root.Q<Slider>();

        this.startButton.clicked += this.StartButtonPressed;
    }

    private void StartButtonPressed()
    {
        GlobalReferences.ScreamerChanse = (int)this.slider.value;
        SceneManager.LoadScene("Game");
    }
}
