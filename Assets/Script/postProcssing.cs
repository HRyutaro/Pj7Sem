using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class postProcssing : MonoBehaviour
{
    public static postProcssing instance;
    public PostProcessVolume postProcessVolume;
    private ChromaticAberration chromaticAberration;

    void Start()
    {
        postProcessVolume.profile.TryGetSettings(out chromaticAberration);
    }

    public void ToggleChromaticAberration(bool enable)
    {
        chromaticAberration.active = enable;
    }
}
