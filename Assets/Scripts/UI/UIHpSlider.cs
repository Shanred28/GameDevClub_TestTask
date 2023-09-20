using UnityEngine;
using UnityEngine.UI;

public class UIHpSlider : MonoBehaviour
{
    [SerializeField] private Destructible destructible;
    private Slider slider;

    private void Start()
    {
        slider = GetComponent<Slider>();
        slider.maxValue = destructible.MaxHitPoints;
        slider.value = destructible.MaxHitPoints;
        destructible.ChangeHp.AddListener(UpdateHP);
    }

    private void OnDestroy()
    {
        destructible.ChangeHp.RemoveListener(UpdateHP);
    }

    private void UpdateHP()
    { 
         slider.value =  destructible.CurrentHitPoints;
    }
}
