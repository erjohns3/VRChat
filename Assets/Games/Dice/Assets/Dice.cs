using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;
using UnityEditor;
using System.Collections;
using System;

    public class Dice : UdonSharpBehaviour
    {
        public bool DebugThisBoi = false;
        [UdonSynced] private float DiceBoiSpeed;
        private int DiceBoiIs = 0;

        public GameObject DiceBoi;
        public GameObject OutputObj;
    public GameObject button1;
    public GameObject button2;
    public GameObject button3;

    private Transform placeofDiceBoi;
        private Rigidbody DiceBoiuwu;
        private Vector3 DiceBoiSpawn;

        private InputField OutputUwU;
        [UdonSynced] private bool Go = false;

        private void Start()
        {
            //DiceBoi = gameObject.transform.Find("Dice").gameObject;
            Debug.Log("Getting transform");
            placeofDiceBoi = DiceBoi.transform;
            Debug.Log(placeofDiceBoi);
            DiceBoiuwu = DiceBoi.GetComponent<Rigidbody>();
            Debug.Log("DiceBOiuwu");
            Debug.Log(DiceBoiuwu.transform);
            OutputUwU = OutputObj.transform.Find("InputField").gameObject.GetComponent<InputField>();
            Debug.Log("Outputuwu");
            Debug.Log(OutputUwU.transform);
            DiceBoiSpawn = DiceBoi.transform.position;
            Debug.Log("DiceBOiSpawn");
            Debug.Log(DiceBoiSpawn);
        }
        private void Update()
        {
            //if (DebugThisBoi == true) DebugMe();
            if (Go == true)
            {
                Debug.Log("Go dice");
                DiceBoiSpeed = Mathf.Round((DiceBoiuwu.velocity.magnitude) * 100);
                if (DiceBoiSpeed <= 1)
                {
                    SendCustomNetworkEvent(VRC.Udon.Common.Interfaces.NetworkEventTarget.All, "PDiceNetworkEvent");
                    Debug.Log("Dice done");
                    Go = false;
                }
            }
        }
        public void PDiceNetworkEvent()
        {
            Debug.Log("Displaying dice");
            OutputUwU.text = whatisDiceBoi_Good().ToString();
        }

        private int whatisDiceBoi_Good()
        {
            float floatyDiceBoi = -999999;
            for (int i = 0; i < 6; i++)
            {
                if (DiceBoi.transform.GetChild(i).position.y > floatyDiceBoi)
                {
                    Debug.Log("Got dice number");
                    floatyDiceBoi = DiceBoi.transform.GetChild(i).position.y;
                    DiceBoiIs = i + 1;
                }
            }
            return (DiceBoiIs);
        }
        public void Dropped()
        {
            Debug.Log("Dropping dice");
           Go = true;
        }

        public void RespawnDiceboi()
        {
            Debug.Log("Respawning 0");
            Go = false;
            Networking.SetOwner(Networking.LocalPlayer, DiceBoi);
            DiceBoi.transform.position = DiceBoiSpawn;

        }

    public void RespawnDiceboi1()
    {
        Debug.Log("Respawning 1");
        Go = false;
        Networking.SetOwner(Networking.LocalPlayer, DiceBoi);
        DiceBoi.transform.position = button1.transform.position + new Vector3(0, 0.5f, 0);
    }

    public void RespawnDiceboi2()
    {
        Debug.Log("Respawning 2");
        Go = false;
        Networking.SetOwner(Networking.LocalPlayer, DiceBoi);
        DiceBoi.transform.position = button2.transform.position + new Vector3(0, 0.5f, 0);
    }

    public void RespawnDiceboi3()
    {
        Debug.Log("Respawning 3");
        Go = false;
        Networking.SetOwner(Networking.LocalPlayer, DiceBoi);
        DiceBoi.transform.position = button3.transform.position + new Vector3(0, 0.5f, 0);
    }

    public Text GoVal;
        public void DebugMe()
        {
            GoVal.text = Go.ToString();
        }

    }
