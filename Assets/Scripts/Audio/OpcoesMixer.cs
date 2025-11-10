using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OpcoesMixer : MonoBehaviour
{
    [Header("Opções")]
    public Slider volumefx;
    public Slider volumeMaster;
    public Toggle muter;

    public AudioMixer mixer;

    private const string VolumeMasterKey = "VolumeMaster";
    private const string VolumeFXKey = "VolumeFX";

    private void Awake()
    {
        volumefx.onValueChanged.AddListener(ChangerVolFX);
        volumeMaster.onValueChanged.AddListener(ChangerVolMaster);

        LoadSettings(); // Carrega as configurações ao iniciar o script
    }

    private void ChangerVolMaster(float v)
    {
        mixer.SetFloat("VloMaster", v);
        SaveSettings(); // Salva as configurações ao alterar o valor do slider
    }

    private void ChangerVolFX(float v)
    {
        mixer.SetFloat("VolFX", v);
        SaveSettings(); // Salva as configurações ao alterar o valor do slider
    }

    private void SaveSettings()
    {
        PlayerPrefs.SetFloat(VolumeMasterKey, volumeMaster.value);
        PlayerPrefs.SetFloat(VolumeFXKey, volumefx.value);
        PlayerPrefs.Save();
    }

    private void LoadSettings()
    {
        volumeMaster.value = PlayerPrefs.GetFloat(VolumeMasterKey, 1.0f);
        volumefx.value = PlayerPrefs.GetFloat(VolumeFXKey, 1.0f);
    }
}