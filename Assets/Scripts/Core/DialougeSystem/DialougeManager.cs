using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;


namespace Core.DialougeSystem
{
    public class DialougeManager : MonoBehaviour
    {
        public Dialouge[] dialouges;

        public GameObject dialougeWindow;

        public TMP_Text dialougeDisplay;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.D)) ShowDialouge("hello");
        }

        public void ShowDialouge(string Name)
        {
            Dialouge d = Array.Find(dialouges, dialouge => dialouge.name == Name);

            if (d == null) return;

            dialougeWindow.SetActive(true);

            while (Time.time < d.deleteAfterSec)
            {
                dialougeDisplay.text = d.content;
            }

            dialougeWindow.SetActive(false);
        }
    }

}
