using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private Observer _observer;
    [SerializeField] private FlashingLight _flashingLight;
    [SerializeField] private Siren _siren;

    private void OnEnable()
    {
        _observer.Spotted += OnSpotted;
        _observer.Losted += OnLosted;
    }

    private void OnDisable()
    {
        _observer.Spotted -= OnSpotted;
        _observer.Losted -= OnLosted;
    }

    private void OnSpotted()
    {
        _flashingLight.StartFlashLight();
        _siren.StartSiren();
    }    
    
    private void OnLosted()
    {
        _flashingLight.StopFlashLight();
        _siren.StopSiren();
    }
}
