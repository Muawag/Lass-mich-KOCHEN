using UnityEngine;
using System.Collections;
using TMPro;

public class PointUI : MonoBehaviour
{
    [SerializeField] private CanvasGroup display;
    [SerializeField] private TextMeshProUGUI text;

    void Start() {
        display.alpha = 0f;
        EventManager.instance.ObjectDestroyedEvent += AddScore;
    }

    private void SpawnPoints(float value) {
        float timer;
        float progress;
        display.alpha = 1f;
        text.text = "+" + value.ToString();
        timer = 0f;
        progress = 0f;

        while(timer < .3f)
        {
            timer += Time.deltaTime;
            progress = timer / .3f;
            display.alpha = progress;
        }
    }   
    private void AddScore(object sender, DestroyEvent e) {
        SpawnPoints(e.money); 
    }
}
