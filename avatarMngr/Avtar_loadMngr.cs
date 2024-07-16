using Fusion;
using ReadyPlayerMe.Samples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avtar_loadMngr : NetworkBehaviour
{
    struct Network_Char_Select : INetworkStruct
    {
        public NetworkString<_128> loading_url;
    }

    [Networked(OnChanged = nameof(OnCharChanged))]
    Network_Char_Select player_url { get; set; }


    private void Awake()
    {
        //static_val.avatarUrl = WebGLAvatarLoader.avatarUrl_static;
        Debug.Log("static_val.avatarUrl = " + static_val.avatarUrl);
    }

    // Start is called before the first frame update
    void Start()
    {
        Network_Char_Select ncc = player_url;
        ncc.loading_url = static_val.avatarUrl;


        if (Object.HasInputAuthority)
            RPC_requestCharChange(ncc);

        StartCoroutine(CallCharChange());

    }


    IEnumerator CallCharChange()
    {
        yield return new WaitForSeconds(5f);
        GetComponent<AvatarLoadingExample>().LoadAvatar_Start();
        


    }
    




    static void OnCharChanged(Changed<Avtar_loadMngr> changed)
    {
        changed.Behaviour.OnCharChanged();
    }

    public void OnCharChanged()
    {
        //ChangeChar();
        //AvatarLoadingExample ALE = GetComponent<AvatarLoadingExample>();
        //static_val.avatarUrl = player_url.loading_url.Value;
        GetComponent<AvatarLoadingExample>().avatarUrl = player_url.loading_url.Value;

    }

    [Rpc(RpcSources.InputAuthority, RpcTargets.StateAuthority)]
    void RPC_requestCharChange(Network_Char_Select ncc, RpcInfo info = default)
    {
        Debug.Log("RPC_requestCharChange");
        player_url = ncc;
        //Debug.Log(player_url.loading_url.ToString());
        //Debug.Log(player_url.loading_url.Value);
        

    }
}
