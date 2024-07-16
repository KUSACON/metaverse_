using Fusion;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class avatarName : NetworkBehaviour
{
    [Header("User Name")]
    public TextMeshProUGUI playerNickNameTM;

    [Networked(OnChanged = nameof(OnNickNameChanged))]
    public NetworkString<_16> nickName { get; set; }

    private void Start()
    {

        //RPC_SetNickName(static_val._AvatarName);
        if (HasInputAuthority)
            nickName = static_val._AvatarName;
    }

    static void OnNickNameChanged(Changed<avatarName> changed)
    {
        changed.Behaviour.OnNickNameChanged();
    }


    private void OnNickNameChanged()
    {
        playerNickNameTM.text = nickName.ToString();
    }


    [Rpc(RpcSources.All, RpcTargets.All)]
    public void RPC_SetNickName(string nickName)
    {
        this.nickName = nickName;
    }

}
