using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RegisterRenameButton : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (LobbySceneManagement.singleton.renameButtonHolder == null) {
            LobbySceneManagement.singleton.renameButtonHolder = gameObject;
        }
    }

    void Awake() {

    }

    public void finishRename() {
        if (string.IsNullOrWhiteSpace(GetComponent<TMP_InputField>().text)) {
            
            //LogHandlerSettings.Instance.SpawnErrorPopup(
                //"Empty Name not allowed."); // Lobby error type, then HTTP error type.
            Debug.LogError("Empty name not allowed");
            return;
        }
        LobbySceneManagement.singleton.renamePlayerServerRpc(GetComponent<TMP_InputField>().text);

    }

}
