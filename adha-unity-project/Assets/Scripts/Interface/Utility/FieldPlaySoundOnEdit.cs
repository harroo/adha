
using UnityEngine;
using UnityEngine.UI;

public class FieldPlaySoundOnEdit : MonoBehaviour {

    public void OnEdit () {

        AudioManager.Play("type-sound");
    }
}
