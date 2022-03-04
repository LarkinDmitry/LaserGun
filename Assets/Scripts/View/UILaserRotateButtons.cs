using UnityEngine;

class UILaserRotateButtons : MonoBehaviour, IRotator
{
    private RotatePresenter presenter;
    private bool buttonPressed;
    private Vector3 rotate;    
    private float step = 0.05f; // sensitivity of rotate

    public void CreatePresenter(Gun model)
    {
        presenter = new RotatePresenter(this, model);
    }
    private void Update()
    {
        // rotate while the button is pressed
        if (buttonPressed) SetRotate(rotate * step);
    }

    // pressing button
    public void Up()
    {
        buttonPressed = true;
        rotate = Vector3.up;
    }

    public void Down()
    {
        buttonPressed = true;
        rotate = Vector3.down;
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

    // unpressed any button
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