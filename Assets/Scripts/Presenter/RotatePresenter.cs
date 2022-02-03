using UnityEngine;

class RotatePresenter
{
    private IRotator view;
    private Gun model;

    public RotatePresenter(IRotator view, Gun model)
    {
        // set link
        this.view = view;
        this.model = model;
    }

    // pass command to model
    public void Rotate(Vector3 rotate)
    {
        model.Rotate(rotate);
    }
}
