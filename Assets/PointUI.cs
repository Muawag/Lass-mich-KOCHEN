using UnityEngine;
using System.Collections;
using TMPro;

public class PointUI : MonoBehaviour
{
    [SerializeField] private CanvasGroup display;
    [SerializeField] private TextMeshProUGUI text;
    private float timer;

    void Start() {
        display.alpha = 0f;
        EventManager.instance.ObjectDestroyedEvent += AddScore;
    }


    IEnumerator SpawnPoints(float value) {
        float timer = 0f;
        float progress = 0f;
        display.alpha = 1f;
        Debug.Log("und jetzt war kurz das display:");
        Debug.Log(display.alpha);
        text.text = "+" + value.ToString();
        yield return new WaitForSeconds(0.5f);
        for (int i = 0; i < 10; i++)
        {
            if(display.alpha >= 0.05f) {

                display.alpha -= 0.05f;
            }
            yield return new WaitForSeconds(.03f);
        }
        display.alpha = 0f;
    }   
    private void AddScore(object sender, DestroyEvent e) {
        StartCoroutine(SpawnPoints(e.money)); 
    }
}
