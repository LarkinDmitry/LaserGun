class LaserPropertyPresenter
{
    private ILaserProperty view;
    private Gun model;

    public LaserPropertyPresenter(ILaserProperty view, Gun model)
    {
        // set link
        this.view = view;
        this.model = model;

        // waiting for an event
        this.model.changedLaserPower += ShowLaserPower;
        this.model.changedLaserRange += ShowLaserRange;
    }

    // pass command to model
    public void SetLaserPower(float value)
    {
        model.SetLaserPower(value);
    }

    public void SetLaserRange(float value)
    {
        model.SetLaserRange(value);
    }

    // pass command to view
    private void ShowLaserPower(float value)
    {
        view.ShowLaserPower(value);
    }

    private void ShowLaserRange(float value)
    {
        view.ShowLaserRange(value);
    }
}
