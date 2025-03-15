using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public float multiplier = 1f;
    public static ScoreManager instance;
    public float score;
    void Awake()
    {
        if(instance != null) {
            instance = this;
        }
    }
    public void Start(){
        EventManager.instance.ObjectDestroyedEvent += addScore;
    }
    private void addScore(object sender, DestroyEvent e){
        score = score +(e.money * multiplier);
    }

}
