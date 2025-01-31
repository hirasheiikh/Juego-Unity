using UnityEngine;

public class Enemy : MonoBehaviour
{
    public SpriteRenderer pinguinoSpin;
    public SpriteRenderer pinguinoWalk;
    public Sprite pinguinoMuerto;

    GameObject enemigo;
    private int _hp = 100;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_hp <= 0)
        {
            if (collision.gameObject.name == "Spin Attack")
            {
                pinguinoSpin.sprite = pinguinoMuerto;
            }
            else if (collision.gameObject.name == "Walk Attack")
            {
                pinguinoWalk.sprite = pinguinoMuerto;
            }
        }
        else
        {
            if (collision.gameObject.name == "Mono" && !GameManager.instance.monito.superman)
            {
                _hp -= 20;
            }
        }
    }
}