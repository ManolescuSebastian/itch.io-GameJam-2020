using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefData : MonoBehaviour
{
    
    public void SaveMusicUserSelection(bool state)
    {
        PlayerPrefs.SetInt("backgroundMusicState", BoolToInt(state));
        PlayerPrefs.Save();
    }


    private int BoolToInt(bool val)
    {
        if (val)
            return 1;
        else
            return 0;
    }
}
