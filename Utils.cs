using System.Collections;
using System.Collections.Generic;
using Photon.Voice.Unity;
using UnityEngine;

public static class Utils
{
    public static Vector3 SpawnPoint = new Vector3(-16.4099998f, 3.16799998f, -15.9799995f);
    public static Recorder localRecorder;

    public static void SetLocalRecorder(Recorder record)
    {
        localRecorder = record;
    }
    public static Vector3 GetRandomSpawnPoint(string name)
    {
        //return new Vector3(Random.Range(-20, 20), 4, Random.Range(-20, 20));
        //return new Vector3(-35.8400002f, 1.36000001f, 19.1100006f);
        //return new Vector3(Random.Range(-33f, -41), 1.36000001f, Random.Range(19, 24));
        //reception
        if (name == "Recption")
            return new Vector3(-36.2210007f, 3.04399991f, 5.21000004f);
        //return new Vector3(-32.07f, 2.38000011f, 4.09600019f);
        //lake front 
        //return new Vector3(-4.48394728f, 5.7421875f, -7.91525841f);
        //doc Room
        if (name == "DocRoom")
            return new Vector3(-0.99000001f, 1.66999996f, 0.0f);
        //beach2
        //return new Vector3(-9.02999973f, 4.57999992f, -36.3300018f);
        //groupTherapy
        //return new Vector3(1.62f, 2.01999998f, -0.5f);
        //nurse room
        if (name == "NurseArea")
            return new Vector3(1.25f, 2.91000009f, 0.0f);

        if (name == "beach2")
            return new Vector3(-16.4099998f, 3.16799998f, -15.9799995f);

        if (name == "LakeFront")
            return new Vector3(2.47600007f, 2.58999991f, 2.95600009f);

        if (name == "waitingRoom")
            return new Vector3(0.280999988f, 2.63657427f, 0.0320000015f);

        if (name == "GroupTheropy")
            return new Vector3(1.62f, 2.45000005f, -0.5f);


        return new Vector3(-32.07f, 2.38000011f, 4.09600019f);

    }

    public static void SetRenderLayerInChildren(Transform transform, int layerNumber)
    {
        foreach (Transform trans in transform.GetComponentsInChildren<Transform>(true))
        {
            trans.gameObject.layer = layerNumber;
        }
    }
}
