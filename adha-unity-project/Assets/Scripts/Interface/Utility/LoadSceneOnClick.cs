
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnClick : MonoBehaviour {

    public string sceneToLoad;

    private void OnClick () {

        SceneManager.LoadScene(sceneToLoad);
    }
}
