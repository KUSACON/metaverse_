using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using ReadyPlayerMe.Samples;
//using UnityEditor.Animations;

public class playerOrientation : NetworkBehaviour
{
    public GameObject headSet;
    public GameObject DefaultAvatar;
    public GameObject Avatar_parent_GO;
    public GameObject newAv;
    //public AnimatorController animatorController;
    public string s_controllerName = "Anim_main_controller";

    public NetworkMecanimAnimator networkMecanimAnimator;


    AvatarLoadingExample avatarLoadingExample;
    bool avatarLoaded = false;
    bool avatar_resetDone = false;


    

    // Start is called before the first frame update
    void Start()
    {
        avatarLoadingExample = GetComponent<AvatarLoadingExample>();    
        if (HasInputAuthority)
        {
            //DefaultAvatar.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!avatarLoaded && avatarLoadingExample._GetAvatar() != null)
        {
            avatarLoaded = true;
        }

        if (!HasInputAuthority)
        {
            #region player orientation
            //Debug.Log("has input authority==================================================================================");
            Vector3 camRot = headSet.transform.rotation.eulerAngles;
            //Debug.Log("camRot: " + camRot);

            Vector3 playerRotation = transform.rotation.eulerAngles; 
            //Debug.Log("playerRotation: " + playerRotation); 
            
            //inverse the rotation so the player will stand straight
            playerRotation.x = 0;
            playerRotation.z = 0;

            transform.rotation = Quaternion.Euler(playerRotation);
            //Debug.Log("transform.rotation: " + transform.rotation.eulerAngles);
            #endregion

            //Debug.Log("End==================================================================================");
        }

        if (avatarLoaded && !avatar_resetDone)
        {
            //Debug.Log("avatarLoaded: " + avatarLoaded);
            Vector3 def_pos = DefaultAvatar.transform.localPosition;

            newAv = avatarLoadingExample._GetAvatar();
            DefaultAvatar.SetActive(false);

            
            //set newAv as child of this gameobject
            newAv.transform.parent = Avatar_parent_GO.transform;
            newAv.transform.localPosition = def_pos;
            newAv.transform.localRotation = Quaternion.Euler(0, 0, 0);
            Animator newAv_animator = newAv.GetComponent<Animator>();
            //newAv_animator = DefaultAvatar.GetComponent<Animator>();
            newAv_animator.runtimeAnimatorController = Resources.Load(s_controllerName) as RuntimeAnimatorController; ;
            //NetworkMecanimAnimator networkMecanimAnimator = newAv.GetComponent<NetworkMecanimAnimator>();
            //networkMecanimAnimator.Animator = newAv.GetComponent<Animator>();
            networkMecanimAnimator.Animator = newAv_animator;
            


            avatar_resetDone = true;

            if (HasInputAuthority)
            {
                //set newAv layer to 3 and to its children
                newAv.layer = 3;
                foreach (Transform child in newAv.transform)
                {
                    child.gameObject.layer = 3;
                }
            }
            else
            {
                //newAv.SetActive(true);
            }
        }



    }


}
