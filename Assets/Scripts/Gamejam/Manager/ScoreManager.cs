using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float multiplier = 1f;
    public float score;
    public void Start(){
        EventManager.instance.ObjectDestroyedEvent += addScore;
    }
    private void addScore(object sender, DestroyEvent e){
        score = score +(e.money * multiplier);
    }

}
