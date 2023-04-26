using UnityEngine;
using UnityEngine.UI;

class UILaserPropertyFields : MonoBehaviour, ILaserProperty
{
    public InputField power;
    public InputField range;
    private LaserPropertyPresenter presenter;

    private void Start()
    {
        power.contentType = InputField.ContentType.DecimalNumber;        
        range.contentType = InputField.ContentType.DecimalNumber;
        
        power.characterLimit = 5;
        range.characterLimit = 5;
    }

    public void CreatePresenter(Gun model)
    {
        presenter = new LaserPropertyPresenter(this, model);
    }

    public void SetLaserPower()
    {
        presenter.SetLaserPower(ValueConverter.StringToFloat(power.text));
    }

    public void SetLaserRange()
    {
        presenter.SetLaserRange(ValueConverter.StringToFloat(range.text));
    }    

    public void ShowLaserPower(float value)
    {
        power.text = value.ToString();
    }

    public void ShowLaserRange(float value)
    {
        range.text = value.ToString();
    }
}