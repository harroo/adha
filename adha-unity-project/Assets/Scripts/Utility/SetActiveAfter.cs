
using UnityEngine;

public class SetActiveAfter : MonoBehaviour {

    public float waitTime;
    public GameObject objectToSetActive;

    private void Start () {

        objectToSetActive.SetActive(false);
    }

    private void Update () {

        waitTime -= Time.deltaTime;
        if (waitTime < 0) {

            objectToSetActive.SetActive(true);
        }
    }
}
