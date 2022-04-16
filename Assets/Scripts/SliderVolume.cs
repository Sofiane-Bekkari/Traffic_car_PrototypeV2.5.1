using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderVolume : MonoBehaviour
{
    [SerializeField] public Slider _slider; 
    // Start is called before the first frame update
    void Start()
    {
        _slider.onValueChanged.AddListener(val => SoundManager.Instance.ChangeMusicVolume(val));

    }

}
