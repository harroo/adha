
using UnityEngine;
using UnityEngine.UI;

public class SettingsUtility_Toggle : MonoBehaviour {

    public string valueName;
    public bool defaultValue;

    private Toggle toggle;

    private void Start () {

        toggle = GetComponent<Toggle>();

        toggle.isOn = (bool)Settings.Get(valueName, defaultValue);
    }

    public void OnChange () {

        Settings.Set(valueName, toggle.isOn);
    }
}
