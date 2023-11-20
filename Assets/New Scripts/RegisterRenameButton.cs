using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterRenameButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake() {
        LobbySceneManagement.singleton.renameButtonHolder = gameObject;
    }

    public void proofOfLife() {
        Debug.Log("clicked");
    }
}
