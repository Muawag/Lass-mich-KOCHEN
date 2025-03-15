using UnityEngine;
using UnityEngine.SceneManagement;
public class SwitchScene : MonoBehaviour
{
    public void OnClick(string scene) {
        SceneManager.LoadScene(scene);
    }
    
}
