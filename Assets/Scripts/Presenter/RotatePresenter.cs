using UnityEngine;

class RotatePresenter
{
    private readonly Gun model;

    public RotatePresenter(Gun model)
    {
        this.model = model;
    }

    public void Rotate(Vector3 rotate)
    {
        model.Rotate(rotate);
    }
}