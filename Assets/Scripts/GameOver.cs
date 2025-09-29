using UnityEngine;

public class GameOver : MonoBehaviour
{
    private Camera cam;
    public float buffer = 1f;
    private GameOverManager manager;

    void Start()
    {
        cam = Camera.main;
        manager = FindObjectOfType<GameOverManager>();
    }

    void Update()
    {
        float bottomEdge = cam.transform.position.y - cam.orthographicSize;

        if (transform.position.y < bottomEdge - buffer)
        {
            manager.ShowGameOver();
            gameObject.SetActive(false); // hide the player
        }
    }
}

