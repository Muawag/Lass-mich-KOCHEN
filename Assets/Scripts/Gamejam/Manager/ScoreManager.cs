using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    public float multiplier = 1f;
    public static ScoreManager instance;
    [SerializeField] GameOverScreen g;
    public float score = 0;
    void Awake()
    {
        if(instance != null) {
            instance = this;
            score = 0;
        }
    }
    public void Start(){
        EventManager.instance.ObjectDestroyedEvent += addScore;
    }
    private void addScore(object sender, DestroyEvent e){
        score = score +(e.money * multiplier);
        g.score = score;
    }
    public float GetScore() {
        return score;
    }

}
