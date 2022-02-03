using UnityEngine;

public class MainScript : MonoBehaviour
{
    public GameObject rotateButtonView;
    public GameObject laserPropertyView;
    public GameObject laserGunModel;
    
    private void Awake()
    {
        // create presenters for views
        rotateButtonView.GetComponent<UILaserRotateButtons>().CreatePresenter(laserGunModel.GetComponent<Gun>());
        laserPropertyView.GetComponent<UILaserPropertyFields>().CreatePresenter(laserGunModel.GetComponent<Gun>());
    }

    // �� ������ ������� �������, ��� ����� ������ ���� ��� �������.
    // ��� ������������� ����� ��������� � ��������� ������� �� ����� (��������
    // �����, ���������� ����������� � �������� UI) �� ����� �������. � �����
    // Prefabs ��� ����� ������������ ��������������� �������.

    // � ����� Sprites �������� sprite atlas � ���� ������ ��� �� ����� ������ �.�.
    // � ��������� ������ ���� ������, �� ������ ������������� �������� ����������
    // �������� �� �������� ��������� ������������������ �� ���� ���������� ����������
    // draw calls.

    // ����������� "��������� �����" ��� ��������� ��������.

    // ��������� ����������� ���������� ���������� �������� ����� �������� �� ����
    // ����������. "�����" � ���� �������� ����� �������� ��� ��� ����������, �.�.
    // ���������� ���������� ����� ������ ������� �� �������� Target
}
