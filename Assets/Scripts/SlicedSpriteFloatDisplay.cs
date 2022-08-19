using UnityEngine;
using UnityEngine.UI;

public class SlicedSpriteFloatDisplay : MonoBehaviour
{
    [SerializeField] private Image _displayImage;
    [SerializeField] private FloatVariable _targetFloat;

    public void UpdateFill()
    {
        _displayImage.fillAmount = _targetFloat.Value / _targetFloat.MaximumValue;
    }

}
