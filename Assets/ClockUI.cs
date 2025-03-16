using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
public class ClockUI : MonoBehaviour
{
    private CanvasGroup clock;
    [SerializeField] private TextMeshProUGUI time;
    [SerializeField] private Image left;
    [SerializeField] private Image right;
    [SerializeField] private Image bottom;
    [SerializeField] private Image top;
    [SerializeField] private RawImage icon;

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
        left.color = Color.red;
        right.color = Color.red;
        bottom.color = Color.red;
        top.color = Color.red;
        icon.color = Color.red;
        while(true)
        {
            timer = 0f;
            progress = 0f;
            while(timer < .3f)
            {
                timer += Time.deltaTime;
                progress = timer / .3f;
                SetAlpha(progress);
                yield return null;
            }
            timer = 0f;
            progress = 0f;
            while(timer < .3f)
            {
                timer += Time.deltaTime;
                progress = 1 - timer / .3f;
                SetAlpha(progress);
                yield return null;
            }
        }
    }

    private void SetAlpha(float value) {
        clock.alpha = value;
    }
}
