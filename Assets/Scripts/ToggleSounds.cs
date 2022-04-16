using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class ToggleSounds : MonoBehaviour
{
    public Toggle _toggle;
    [SerializeField] private bool _toggleEffects;

    void Awake()
    {
        _toggle = GetComponent<Toggle>();
    }
    public void Toggle()
    {
        if (_toggleEffects) SoundManager.Instance.SoundMuteOnOff();
    }

}
