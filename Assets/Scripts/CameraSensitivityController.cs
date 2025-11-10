using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class CameraSensitivityController : MonoBehaviour
{
    public CinemachineFreeLook freeLookCamera;
    public Slider sensitivitySliderX;
    public Slider sensitivitySliderY;

    void Start()
    {
        // Define os valores mínimos e máximos dos sliders
        sensitivitySliderX.minValue = 0; // Valor mínimo para X
        sensitivitySliderX.maxValue = 150; // Valor máximo para X
        sensitivitySliderY.minValue = 0; // Valor mínimo para Y
        sensitivitySliderY.maxValue = 2; // Valor máximo para Y

        // Inicializa os sliders com os valores atuais da câmera
        sensitivitySliderX.value = freeLookCamera.m_XAxis.m_MaxSpeed;
        sensitivitySliderY.value = freeLookCamera.m_YAxis.m_MaxSpeed;

        // Adiciona listeners para os sliders separadamente
        sensitivitySliderX.onValueChanged.AddListener(OnXSliderChanged);
        sensitivitySliderY.onValueChanged.AddListener(OnYSliderChanged);
    }

    void OnXSliderChanged(float value)
    {
        // Ajusta a sensibilidade do eixo X
        freeLookCamera.m_XAxis.m_MaxSpeed = value;
    }

    void OnYSliderChanged(float value)
    {
        // Ajusta a sensibilidade do eixo Y
        freeLookCamera.m_YAxis.m_MaxSpeed = value;
    }
}