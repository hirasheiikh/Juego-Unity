using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image barraHp;

    // Update is called once per frame
    void Update()
    {
        Monito m = GameManager.instance.monito;
        barraHp.fillAmount = (m.hp/m.max_hp);
    }
}
