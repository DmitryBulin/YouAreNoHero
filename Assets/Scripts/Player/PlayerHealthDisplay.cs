using UnityEngine;

public class PlayerHealthDisplay : MonoBehaviour
{
    [SerializeField] private GameObject[] _healthBars;
    [SerializeField] private FloatVariable _health;

    private void Start()
    {
        if (_healthBars.Length != _health.MaximumValue)
        {
            Debug.LogError("Amount of health bars on display is not the same as in player health!");
        }
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        for (int i = 0; i < _health.MaximumValue; ++i)
        {
            _healthBars[i].SetActive(i + 1 <= _health.Value);
        }
    }

}
