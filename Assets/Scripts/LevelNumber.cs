using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelNumber : MonoBehaviour
{
   public TextMeshProUGUI LevelNumberTxt;

   private void Start()
    {
        int lastLevelNumber = PlayerPrefs.GetInt("Last_Level") - 4;
        LevelNumberTxt.text = lastLevelNumber.ToString();
    }
}
