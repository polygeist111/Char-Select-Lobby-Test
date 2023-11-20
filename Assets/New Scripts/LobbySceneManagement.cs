using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using TMPro;

public class LobbySceneManagement : NetworkBehaviour
{
    public static LobbySceneManagement singleton = null;
    public bool[] camsTaken = new bool[4];
    public Transform[] players = new Transform[4];

    
    [SerializeField] public PlayerCard[] playerCards;
    [SerializeField] public TMP_Text[] playerNames;
    [SerializeField] public bool[] playerReady;
    //[SerializeField] private PlayerCard[] playerCards;



    //[SerializeField] private GameObject renameButtonHolder;
    public Button renameButton;
    

    void Awake() {
        if (singleton == null) {
            singleton = this;
            DontDestroyOnLoad(this.gameObject);
        } 
        else if (singleton != this) {
            Debug.Log(singleton.name + " replaced me");
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //renameButton = renameButtonHolder.GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("alive");
    }

    //void updatePlayerCards

    public int identifyPlayer(Transform playerTransform) {
        for (int i = 0; i < 4; i++) {
            if (!camsTaken[i]) {
                camsTaken[i] = true;
                Debug.Log("sent transform " + (i + 1));
                players[i] = playerTransform;
                return i + 1;
            }
        }
        return -1;
    }

    //Renames player on playercard
    public void renamePlayer(int identity) {
        Debug.Log("Player " + identity + " was here");
        playerNames[identity - 1].SetText("Player " + identity + " was here");
    }
}
