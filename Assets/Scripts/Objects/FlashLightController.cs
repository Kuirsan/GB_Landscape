using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightController : MonoBehaviour
{

    private bool _isOn = false;
    [SerializeField] private GameObject _lightSource;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(_isOn)
            {
                _lightSource.SetActive(false);
                _isOn = false;
            }
            else
            {
                _lightSource.SetActive(true);
                _isOn = true;
            }
        }
    }
}
