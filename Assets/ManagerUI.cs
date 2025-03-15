using UnityEngine;
using UnityEngine.UI;

public class ManagerUI : MonoBehaviour
{
    [SerializeField] private Slider sliderWhite;
    public float noise;
    public float lerpTimer;
    private float lerpSpeed = 2f;
    void Start()
    {
        
    }

    void Update()
    {
    }

    public void UpdateUI(float noise, float maxNoise)
    {
        float fillW = sliderWhite.value; //get current values

        float hFraction = noise / maxNoise; //get noise percentage

        lerpTimer += Time.deltaTime;
        float percentComplete = lerpTimer / lerpSpeed;

        percentComplete = percentComplete * percentComplete; //nice lerp effect

        SetWhite(Mathf.Lerp(fillW, hFraction, percentComplete * 10f));
    }

    public void SetWhite(float value)
    {
        sliderWhite.value = value;
    }
}