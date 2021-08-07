
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayClickSoundOnClick : MonoBehaviour, IPointerClickHandler {

    public void OnPointerClick (PointerEventData eventData) {

        AudioManager.Play("gotu");
    }
}
