using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
public class ClockUI : MonoBehaviour
{
    private CanvasGroup clock;
    [SerializeField] private TextMeshProUGUI time;

    void Start()
    {
        clock = this.GetComponent<CanvasGroup>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartFlash(){
        StartCoroutine(Flashing());
    }

    IEnumerator Flashing()
    {
        float timer;
        float progress;
        time.color = Color.red;
        for (int i = 0; i < 3; i++)
        {
            timer = 0f;
            progress = 0f;
            while(timer < .5f)
            {
                timer += Time.deltaTime;
                progress = timer / .5f;
                SetAlpha(progress);
                yield return null;
            }
            timer = 0f;
            progress = 0f;
            while(timer < .5f)
            {
                timer += Time.deltaTime;
                progress = 1 - timer / .5f;
                SetAlpha(progress);
                yield return null;
            }
        }
    }

    private void SetAlpha(float value) {
        clock.alpha = value;
    }
}
