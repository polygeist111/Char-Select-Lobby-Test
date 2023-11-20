using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Unity.Netcode;
using UnityEngine.Networking;
using TMPro;

public class LobbySceneManagement : NetworkBehaviour
{
    public static LobbySceneManagement singleton = null;
    public int mostRecentPlayerClick;
    public bool[] camsTaken = new bool[4];
    public RegisterPlayer[] players = new RegisterPlayer[4];
    private int playerCount = 0;

    [SerializeField] public TMP_Text joinCodeText;
    public string joinCode;

    
    [SerializeField] public PlayerCard[] playerCards;
    [SerializeField] public TMP_Text[] playerNames;
    [SerializeField] public bool[] playerReady;
    //[SerializeField] private PlayerCard[] playerCards;



    [SerializeField] public GameObject renameButtonHolder;
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
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("alive");
        if (renameButton == null) {
            renameButton = renameButtonHolder.GetComponent<Button>();
        }
        if (joinCodeText.text.Length == 0) {
            joinCodeText.SetText("" + joinCode);
        }
  
    }

    //void updatePlayerCards

    public int identifyPlayer(RegisterPlayer player) {
        for (int i = 0; i < 4; i++) {
            if (!camsTaken[i]) {
                camsTaken[i] = true;
                Debug.Log("sent transform " + (i + 1));
                players[i] = player;
                playerCount++;
                players[i].OnPlayerClick += Clicked;
                return i + 1;
            }
        }
        return -1;
    }

    public void Clicked(object sender, System.EventArgs e) {
        Debug.Log("player clicked manager");
        int PlayerIdentifier = (sender as RegisterPlayer).identity;
        mostRecentPlayerClick = PlayerIdentifier;
        Debug.Log(mostRecentPlayerClick);
    }

    [ServerRpc(RequireOwnership = false)]
    public void renamePlayerServerRpc(string name) {
        Debug.Log("Renaming player " + mostRecentPlayerClick + " to: " + name); 
        playerNames[mostRecentPlayerClick - 1].SetText(name);       
        //renamePlayerServerRpc(identity);
    }

    /*
    [ServerRpc(RequireOwnership = false)]
    //Renames player on playercard
    public void renamePlayerServerRpc(int identity) {
        Debug.Log("Player " + identity + " was here");
        LobbySceneManagement.singleton.playerNames[identity - 1].SetText("Player " + identity + " was here");
    }
    */
}
