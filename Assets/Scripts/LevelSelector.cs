using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public Button[] levelButtons;
    public Sprite lockedImage;

    // Start is called before the first frame update
    void Start()
    {
        int lastLevelUnlocked = PlayerPrefs.GetInt("Last_Level_unlocked") ;
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if(i +1 > lastLevelUnlocked )
            {
                levelButtons[i].image.sprite = lockedImage;
                levelButtons[i].interactable = false;
            }
    
        }
    }

}
