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

    private void Start()
    {
        // set start value for example
        laserGunModel.GetComponent<Gun>().SetLaserRange(50f);
        laserGunModel.GetComponent<Gun>().SetLaserPower(25f);
        laserGunModel.GetComponent<Gun>().Rotate(Vector3.zero);
    }

    // Изменение коэффицента поглащения отражающих объектов можно выполнять из окна
    // инспектора. "Земля" и сама лазерная пушка отражают луч без поглащения, т.к.
    // коэффицент поглащения имеют только объекты со скриптом Target

    // Из текста задания следует, что сцена должна быть уже готовой. Это позволяет
    // "запечь свет" для статических объектов, создать lightmap и увеличить
    // производителность за счет отрисовки меньшего колиества теней.

    // При необходимости можно создавать и размещать объекты по сцене (лазерную
    // пушку, отражающие поверхности и элементы UI) из этого скрипта, однако в таком случае
    // тени будут создаваться в реалтайме. В папке Prefabs для этого подготовлены
    // соответствующие префабы.

    // В папку Sprites добавлен sprite atlas в моем случае это не имеет смысла т.к.
    // я использую только один спрайт, но случае использования большего количества
    // спрайтов он позволит увеличить производительность за счет уменьшения количества
    // draw calls.
}
