using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Monito monito;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);



    }
}
