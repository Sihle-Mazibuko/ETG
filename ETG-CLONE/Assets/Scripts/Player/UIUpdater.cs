//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class UIUpdater : MonoBehaviour
//{

//    public GameObject Heart1;
//    public GameObject Heart2;
//    public GameObject Heart3;
//    public GameObject Heart4;
//    public GameObject Heart5;
//    public GameObject Heart6;

//    public Text KeyAmount;

//    public Text BlankAmount;

//    private void Start()
//    {
//        KeyAmount = GameObject.Find("KEY COUNTER").GetComponent<Text>();
//        BlankAmount = GameObject.Find("BLANK COUNTER").GetComponent<Text>();

//        Heart1 = GameObject.Find("Heart 1");
//        Heart2 = GameObject.Find("Heart 2");
//        Heart3 = GameObject.Find("Heart 3");
//        Heart4 = GameObject.Find("Heart 4");
//        Heart5 = GameObject.Find("Heart 5");
//        Heart6 = GameObject.Find("Heart 6");
//    }

//    private void Update()
//    {
//        BlankAmount.text = Blanks.ToString();
//        KeyAmount.text = Keys.ToString();

//        if (currentHealth == 6)
//        {
//            Heart1.SetActive(true);
//            Heart2.SetActive(true);
//            Heart3.SetActive(true);
//            Heart4.SetActive(true);
//            Heart5.SetActive(true);
//            Heart6.SetActive(true);
//        }
//        else if (currentHealth == 5)
//        {
//            Heart1.SetActive(true);
//            Heart2.SetActive(true);
//            Heart3.SetActive(true);
//            Heart4.SetActive(true);
//            Heart5.SetActive(true);
//            Heart6.SetActive(false);
//        }
//        else if (currentHealth == 4)
//        {
//            Heart1.SetActive(true);
//            Heart2.SetActive(true);
//            Heart3.SetActive(true);
//            Heart4.SetActive(true);
//            Heart5.SetActive(false);
//            Heart6.SetActive(false);
//        }
//        else if (currentHealth == 3)
//        {
//            Heart1.SetActive(true);
//            Heart2.SetActive(true);
//            Heart3.SetActive(true);
//            Heart4.SetActive(false);
//            Heart5.SetActive(false);
//            Heart6.SetActive(false);
//        }
//        else if (currentHealth == 2)
//        {
//            Heart1.SetActive(true);
//            Heart2.SetActive(true);
//            Heart3.SetActive(false);
//            Heart4.SetActive(false);
//            Heart5.SetActive(false);
//            Heart6.SetActive(false);
//        }
//        else if (currentHealth == 1)
//        {
//            Heart1.SetActive(true);
//            Heart2.SetActive(false);
//            Heart3.SetActive(false);
//            Heart4.SetActive(false);
//            Heart5.SetActive(false);
//            Heart6.SetActive(false);
//        }
//        else if (currentHealth == 0)
//        {
//            Heart1.SetActive(false);
//            Heart2.SetActive(false);
//            Heart3.SetActive(false);
//            Heart4.SetActive(false);
//            Heart5.SetActive(false);
//            Heart6.SetActive(false);
//        }
//    }



//}
