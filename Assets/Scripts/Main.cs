using UnityEngine;

public class Main : MonoBehaviour
{
    public GameObject rotateButtonView;
    public GameObject laserPropertyView;
    public GameObject laserGunModel;
    
    private void Awake()
    {
        rotateButtonView.GetComponent<UILaserRotateButtons>().CreatePresenter(laserGunModel.GetComponent<Gun>());
        laserPropertyView.GetComponent<UILaserPropertyFields>().CreatePresenter(laserGunModel.GetComponent<Gun>());
    }

    private void Start()
    {
        laserGunModel.GetComponent<Gun>().SetLaserRange(50f);
        laserGunModel.GetComponent<Gun>().SetLaserPower(25f);
        laserGunModel.GetComponent<Gun>().Rotate(Vector3.zero);
    }

    // ��������� ����������� ���������� ���������� �������� ����� ��������� �� ����
    // ����������. "�����" � ���� �������� ����� �������� ��� ��� ����������, �.�.
    // ���������� ���������� ����� ������ ������� �� �������� Target

    // ����� ���� ����� ����� "��� �������". ��� ���������
    // "������ ����" ��� ����������� ��������, ������� lightmap � ���������
    // ����������������� �� ���� ��������� �������� ��������� �����.

    // ��� ������������� ����� ��������� � ��������� ������� �� ����� (��������
    // �����, ���������� ����������� � �������� UI) �� ����� �������, ������ � ����� ������
    // ���� ����� ����������� � ���������. � ����� Prefabs ��� ����� ������������
    // ��������������� �������.

    // � ����� Sprites �������� sprite atlas � ���� ������ ��� �� ����� ������ �.�.
    // � ��������� ������ ���� ������, �� ������ ������������� �������� ����������
    // �������� �� �������� ��������� ������������������ �� ���� ���������� ����������
    // draw calls.
}