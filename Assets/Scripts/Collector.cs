using UnityEngine;

public class Collector : MonoBehaviour
{
    private string ENEMY_TAG = "Enemy";
    private string PLAYER_TAG = "Player";
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag(ENEMY_TAG))
            Destroy(col.gameObject);
        if (col.CompareTag(PLAYER_TAG))
        {
            Destroy(col.gameObject);
            Time.timeScale = 0;
            Player._canvas.gameObject.SetActive(true);
        }
    }
}
