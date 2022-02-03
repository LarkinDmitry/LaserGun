using UnityEngine;
using UnityEngine.UI;

class UILaserPropertyFields : MonoBehaviour, ILaserProperty
{
    public InputField power;
    public InputField range;
    private LaserPropertyPresenter presenter;

    public void CreatePresenter(Gun model)
    {
        presenter = new LaserPropertyPresenter(this, model);
    }

    // read and send laser power value
    public void SetLaserPower()
    {
        presenter.SetLaserPower(StringToFloat(power.text));
    }

    // read and send laser range value
    public void SetLaserRange()
    {
        presenter.SetLaserRange(StringToFloat(range.text));
    }

    // format text and convert string to float
    private float StringToFloat(string s)
    {
        char separator = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
        return float.Parse(s.Replace(".", separator.ToString()));
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
