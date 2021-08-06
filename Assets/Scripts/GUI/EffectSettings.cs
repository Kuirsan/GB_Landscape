using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class EffectSettings : MonoBehaviour
{
    [SerializeField]
    private Button _firstPostProcessButton;

    [SerializeField]
    private Button _secondPostProcessButton;

    [SerializeField]
    private PostProcessProfile _firstProcessProfile;

    [SerializeField]
    private PostProcessProfile _secondProcessProfile;

    [SerializeField]
    private PostProcessVolume _postProcessVolume;

    private void Start()
    {
        _firstPostProcessButton.onClick.AddListener(() =>
        {
            ChangeSettings(true);
        });
        _secondPostProcessButton.onClick.AddListener(() =>
        {
            ChangeSettings(false);
        });
    }

    private void ChangeSettings(bool isFirstPostProcess)
    {
        _postProcessVolume.profile = isFirstPostProcess ? _firstProcessProfile : _secondProcessProfile;
    }

    private void OnDestroy()
    {
        _firstPostProcessButton.onClick.RemoveAllListeners();
        _secondPostProcessButton.onClick.RemoveAllListeners();
    }
}
