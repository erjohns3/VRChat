using UdonSharp;
using UnityEngine;
using UnityEngine.UI;

namespace Childofthebeast.Toys
{
    public class Dice_Debug : UdonSharpBehaviour
    {
        private float DiceBoiSpeed;
        private int DiceBoiIs = 0;

        private GameObject DiceBoi;
        private Transform placeofDiceBoi;
        private Rigidbody DiceBoiuwu;
        private Vector3 DiceBoiSpawn;

        private InputField OutputUwU;

        private Transform Side1;
        private Transform Side2;
        private Transform Side3;
        private Transform Side4;
        private Transform Side5;
        private Transform Side6;

        private float Side1_Value;
        private float Side2_Value;
        private float Side3_Value;
        private float Side4_Value;
        private float Side5_Value;
        private float Side6_Value;

        public Text Side1_debug;
        public Text Side2_debug;
        public Text Side3_debug;
        public Text Side4_debug;
        public Text Side5_debug;
        public Text Side6_debug;
        public Text DiceBoiIs_debug;
        public Text Debug_DiceBoiSpeed;

        private void Start()
        {
            DiceBoi = gameObject.transform.Find("Dice").gameObject;
            placeofDiceBoi = DiceBoi.transform;
            DiceBoiuwu = DiceBoi.GetComponent<Rigidbody>();
            OutputUwU = gameObject.transform.Find("Output").gameObject.transform.Find("InputField").gameObject.GetComponent<InputField>();
            DiceBoiSpawn = DiceBoi.transform.position;

            Side1 = DiceBoi.transform.Find("Side1").gameObject.transform;
            Side2 = DiceBoi.transform.Find("Side2").gameObject.transform;
            Side3 = DiceBoi.transform.Find("Side3").gameObject.transform;
            Side4 = DiceBoi.transform.Find("Side4").gameObject.transform;
            Side5 = DiceBoi.transform.Find("Side5").gameObject.transform;
            Side6 = DiceBoi.transform.Find("Side6").gameObject.transform;
        }

        public override void Interact()
        {
            debugPrint();
        }



        private void Update()
        {
            debugPrint();

            DiceBoiSpeed = Mathf.Round((DiceBoiuwu.velocity.magnitude) * 100);

            if (DiceBoiSpeed <= 1)
            {
                Side1_Value = Side1.position.y;
                Side2_Value = Side2.position.y;
                Side3_Value = Side3.position.y;
                Side4_Value = Side4.position.y;
                Side5_Value = Side5.position.y;
                Side6_Value = Side6.position.y;
                OutputUwU.text = whatisDiceBoi_Good().ToString();
            }

        }
        private int whatisDiceBoi_Good()
        {
            float floatyDiceBoi = 0;
            for (int i = 0; i < 6; i++)
            {
                if (DiceBoi.transform.GetChild(i).position.y > floatyDiceBoi)
                {
                    floatyDiceBoi = DiceBoi.transform.GetChild(i).position.y;
                    DiceBoiIs = i + 1;
                }
            }
            return (DiceBoiIs);
        }
        private void whatisDiceBoi_Bad()
        {
            if (Side1_Value > Side2_Value &&
                Side1_Value > Side3_Value &&
                Side1_Value > Side4_Value &&
                Side1_Value > Side5_Value)
            {
                DiceBoiIs = 1;
            }
            if (Side6_Value > Side2_Value &&
                Side6_Value > Side3_Value &&
                Side6_Value > Side4_Value &&
                Side6_Value > Side5_Value)
            {
                DiceBoiIs = 6;
            }
            if (Side2_Value > Side1_Value &&
                Side2_Value > Side3_Value &&
                Side2_Value > Side4_Value &&
                Side2_Value > Side6_Value)
            {
                DiceBoiIs = 2;
            }
            if (Side5_Value > Side1_Value &&
                Side5_Value > Side3_Value &&
                Side5_Value > Side4_Value &&
                Side5_Value > Side6_Value)
            {
                DiceBoiIs = 5;
            }
            if (Side3_Value > Side1_Value &&
                Side3_Value > Side2_Value &&
                Side3_Value > Side5_Value &&
                Side3_Value > Side6_Value)
            {
                DiceBoiIs = 3;
            }
            if (Side4_Value > Side1_Value &&
                Side4_Value > Side2_Value &&
                Side4_Value > Side5_Value &&
                Side4_Value > Side6_Value)
            {
                DiceBoiIs = 4;
            }
        }

        private void debugPrint()
        {
            Side1_debug.text = "Side1: " + Side1_Value;
            Side2_debug.text = "Side2: " + Side2_Value;
            Side3_debug.text = "Side3: " + Side3_Value;
            Side4_debug.text = "Side4: " + Side4_Value;
            Side5_debug.text = "Side5: " + Side5_Value;
            Side6_debug.text = "Side6: " + Side6_Value;
            DiceBoiIs_debug.text = "DiceBoiIs: " + DiceBoiIs.ToString();
            Debug_DiceBoiSpeed.text = "DiceBoiSpeed: " + DiceBoiSpeed.ToString();
        }

        public void RespawnDiceboi()
        {
            DiceBoi.transform.position = DiceBoiSpawn;
        }

    }
}
