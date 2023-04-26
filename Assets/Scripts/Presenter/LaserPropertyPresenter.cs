class LaserPropertyPresenter
{
    private readonly ILaserProperty view;
    private readonly Gun model;

    public LaserPropertyPresenter(ILaserProperty view, Gun model)
    {
        this.view = view;
        this.model = model;

        this.model.changedLaserPower += ShowLaserPower;
        this.model.changedLaserRange += ShowLaserRange;
    }

    public void SetLaserPower(float value)
    {
        model.SetLaserPower(value);
    }

    public void SetLaserRange(float value)
    {
        model.SetLaserRange(value);
    }

    private void ShowLaserPower(float value)
    {
        view.ShowLaserPower(value);
    }

    private void ShowLaserRange(float value)
    {
        view.ShowLaserRange(value);
    }
}