using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;


public delegate void PlayerClick (object sender, System.EventArgs e);

public class RegisterPlayer : NetworkBehaviour
{
    public event PlayerClick OnPlayerClick;
    
    private GameObject sceneManager;
    //private LobbySceneManagement managerScript;
    private bool registered = false;
    private Button rename;

    public int identity = -1;

    void Awake() {
        
    }

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetMouseButtonDown(0)) {
            Debug.Log("Player clicked local");
            OnPlayerClick(this, System.EventArgs.Empty);
        }  
        /*
        if (!registered) {
            if (sceneManager == null) {
                sceneManager = GameObject.FindWithTag("GameController");
                Debug.Log(sceneManager.name + " is the  controller");
            } else {
                var managerScript = sceneManager.GetComponent<LobbySceneManagement>();
                Debug.Log(managerScript +" scene begin");
                if (managerScript != null) {
                    registered = true;
                    Debug.Log(GetComponent<Transform>() + " Player Transform");
                    identity = managerScript.identifyPlayer(GetComponent<Transform>());
                }
            }
        }
        */
        if (identity <= 0) {
            identity = LobbySceneManagement.singleton.identifyPlayer(this);
        }
        /*
        if (rename == null) {
            Debug.Log("Button: " + LobbySceneManagement.singleton.renameButton);
            rename = LobbySceneManagement.singleton.renameButton;
            //rename.onClick.AddListener(() => {LobbySceneManagement.singleton.renamePlayer(identity); Debug.Log("clicked");});
            // /rename.onClick.AddListener(renamePlayer);
        }
        */
    }

    /*
    void OnKeyDown() {
        Debug.Log("Player clicked local");
        OnPlayerClick(this, System.EventArgs.Empty);
    }
    */
}  
