using UnityEngine;
using UnityEngine.UI;

class UILaserPropertyFields : MonoBehaviour, ILaserProperty
{
    public InputField power;
    public InputField range;
    private LaserPropertyPresenter presenter;

    private void Start()
    {
        // set input type - decimal number
        power.contentType = InputField.ContentType.DecimalNumber;        
        range.contentType = InputField.ContentType.DecimalNumber;
        
        // set character limit
        power.characterLimit = 5;
        range.characterLimit = 5;
    }

    public void CreatePresenter(Gun model)
    {
        presenter = new LaserPropertyPresenter(this, model);
    }

    // read and send laser power value
    public void SetLaserPower()
    {
        presenter.SetLaserPower(ValueConverter.StringToFloat(power.text));
    }

    // read and send laser range value
    public void SetLaserRange()
    {
        presenter.SetLaserRange(ValueConverter.StringToFloat(range.text));
    }
    

    // write on UI laser power value
    public void ShowLaserPower(float value)
    {
        power.text = value.ToString();
    }

    // write on UI laser range value
    public void ShowLaserRange(float value)
    {
        range.text = value.ToString();
    }
}
