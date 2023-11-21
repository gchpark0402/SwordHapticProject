using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonManager : MonoBehaviourPunCallbacks, IPunObservable
{
    private static PhotonManager instance;
    public int count;
    public int CurrentPlayerCount = 0; 
    private void Awake()
    {
        if(null == instance)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else{
            Destroy(this.gameObject);
        }
    }

    public static PhotonManager Instance
    {
            get
            {
                if(null == instance) return null;
                return instance;
            }
    }

    public PhotonView PV;

    // Start is called before the first frame update
    void Start()
    {
        if(PhotonNetwork.ConnectUsingSettings()) Debug.Log("connected!");
        PV = this.GetComponent<PhotonView>();
    }

    public override void OnConnectedToMaster()
    {
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 4;
        if(PhotonNetwork.JoinOrCreateRoom("Room1", options, null)) Debug.Log("joined!");
    }

    // Update is called once per frame
    void Update()
    {
        CurrentPlayerCount = PhotonNetwork.PlayerList.Length;
        //Debug.Log(PhotonNetwork.PlayerList.Length);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if(stream.IsWriting)
        {
            stream.SendNext(count);
        }
        else
        {
            this.count = (int)stream.ReceiveNext();
        }
    }
}
