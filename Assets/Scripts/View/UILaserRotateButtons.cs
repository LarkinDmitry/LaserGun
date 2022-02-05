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

    // pressing button up
    public void Up()
    {
        buttonPressed = true;
        rotate = Vector3.up;
    }

    // pressing button down
    public void Down()
    {
        buttonPressed = true;
        rotate = Vector3.down;
    }

    // pressing button right
    public void Right()
    {
        buttonPressed = true;
        rotate = Vector3.right;
    }

    // pressing button left
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

    // send command to rotate model 
    public void SetRotate(Vector3 rotate)
    {
        presenter.Rotate(rotate);
    }
}