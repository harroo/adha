
using UnityEngine;
using UnityEngine.UI;

public class VocabMenu : MonoBehaviour {

    public void OnComplete (string[] args) {

        foreach (string s in args) {

            Debug.Log(s);
        }
    }

        public void OnComplete1 (string a, string b) {

            Debug.Log(a+": "+b);
        }

    public void Click () {

        Orthoget.Dictionary.GetWordDefinition("flank", OnComplete1);
    }
}
