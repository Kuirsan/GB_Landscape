using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class SphereEnter : MonoBehaviour
{
    [SerializeField]
    private float _vignetteMaxIntensity;

    [SerializeField]
    private float _vignetteIntensityStep;

    private PostProcessVolume _postProcessVolume;

    private Vignette _vignette;

    private float _vignetteMinIntensity;

    private bool _isInTrigger;

    private void Start()
    {
        SettingsVignette();

        _isInTrigger = false;

        _postProcessVolume = PostProcessManager.instance.QuickVolume(gameObject.layer, 2, _vignette);
    }

    private void SettingsVignette()
    {
        _vignette = ScriptableObject.CreateInstance<Vignette>();
        _vignette.enabled.Override(true);
        _vignette.intensity.Override(0);
    }

    private void OnDestroy()
    {
        RuntimeUtilities.DestroyVolume(_postProcessVolume, true, true);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if ((_vignette.intensity.value + Time.deltaTime * _vignetteIntensityStep) >= _vignetteMaxIntensity)
            {
                _vignette.intensity.value = _vignetteMaxIntensity;
            }
            else
            {
                _vignette.intensity.value += Time.deltaTime * _vignetteIntensityStep;
            }
        }
    }

    private void Update()
    {
        if(!_isInTrigger)
        {
            if ((_vignette.intensity.value - Time.deltaTime * _vignetteIntensityStep) <=_vignetteMinIntensity)
            {
                _vignette.intensity.value = _vignetteMinIntensity;
            }
            else
            {
                _vignette.intensity.value -= Time.deltaTime * _vignetteIntensityStep;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag =="Player")
        {
            _isInTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            _isInTrigger = false;
        }
    }
}
