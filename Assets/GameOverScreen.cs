using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject gameWon;
    [SerializeField] private TextMeshProUGUI text1, text2;
    private CanvasGroup cGroup;
    public float score = 0;
    void Start()
    {
        cGroup = GetComponent<CanvasGroup>();
        cGroup.alpha = 0f;
    }

    public void Setup(bool won)
    {
        Cursor.lockState = CursorLockMode.None;
        cGroup.alpha = 1f;
        if(won) {
        gameWon.SetActive(true);
        text1.text = score.ToString();
        }
        else {
        gameOver.SetActive(true);
        text1.text = score.ToString();
        }
    }
}
