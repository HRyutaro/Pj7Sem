using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class postProcssing : MonoBehaviour
{
    public static postProcssing instance;
    public PostProcessVolume postProcessVolume;
    private MotionBlur motionBlurLayer;
    private ChromaticAberration chromaticAberration;
    public Image ima;

    void Start()
    {
    }

    public void ToggleChromaticAberration(bool enable)
    {
        postProcessVolume.profile.TryGetSettings(out chromaticAberration);
        chromaticAberration.active = enable;
    }
    public void ToggleMotionBlur()
    {
        postProcessVolume.profile.TryGetSettings(out motionBlurLayer);
        motionBlurLayer.enabled.value = !motionBlurLayer.enabled.value;
        if (motionBlurLayer.enabled.value == true)
        {
            ima.color = Color.green;
        }
        if (motionBlurLayer.enabled.value == false)
        {
            ima.color = Color.red;
        }
    }
}
