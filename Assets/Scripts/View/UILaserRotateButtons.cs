using UnityEngine;

class UILaserRotateButtons : MonoBehaviour, IRotator
{
    private RotatePresenter presenter;
    private bool buttonPressed;
    private Vector3 rotate;
    private readonly float sensitivity = 0.05f;

    public void CreatePresenter(Gun model)
    {
        presenter = new RotatePresenter(model);
    }
    private void Update()
    {
        if (buttonPressed) SetRotate(rotate * sensitivity);
    }

    public void Up()
    {
        buttonPressed = true;
        rotate = Vector3.down;
    }

    public void Down()
    {
        buttonPressed = true;
        rotate = Vector3.up;
    }

    public void Right()
    {
        buttonPressed = true;
        rotate = Vector3.right;
    }

    public void Left()
    {
        buttonPressed = true;
        rotate = Vector3.left;
    }

    public void PointerUp()
    {
        buttonPressed = false;
        rotate = Vector3.zero;
    }

    public void SetRotate(Vector3 rotate)
    {
        presenter.Rotate(rotate);
    }
}