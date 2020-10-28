using UdonSharp;
using UnityEngine;
using UnityEngine.UI;
using VRC.SDKBase;
using VRC.Udon;
using UnityEditor;
using System.Collections;

    public class DicePickup : UdonSharpBehaviour
    {
        public GameObject DiceBoi;
        private UdonBehaviour uwu;

        private void Start()
        {
            Debug.Log("Getting udonbehavior");
            uwu = (UdonBehaviour)DiceBoi.transform.GetComponent(typeof(UdonBehaviour));
            Debug.Log("Got udonbehavior");
        }
        public override void OnDrop()
        {
            Debug.Log("OnDrop");
            uwu.SendCustomEvent("Dropped");
            Debug.Log("OnDrop done");
        }
    }
