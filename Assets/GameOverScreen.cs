using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject gameWon;
    private CanvasGroup cGroup;
    void Start()
    {
        cGroup = GetComponent<CanvasGroup>();
        cGroup.alpha = 0f;
        Setup(false);
    }

    public void Setup(bool won)
    {
        Cursor.lockState = CursorLockMode.None;
        cGroup.alpha = 1f;
        if(won)
        gameWon.SetActive(true);
        else
        gameOver.SetActive(true);
    }
}
