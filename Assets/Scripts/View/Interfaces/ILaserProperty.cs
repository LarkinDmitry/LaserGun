interface ILaserProperty
{
    // get command from model (via a presenter)
    public void ShowLaserPower(float value);

    public void ShowLaserRange(float value);

    // send command to model (via a presenter)
    void SetLaserPower();

    void SetLaserRange();
}
