using UnityEngine;

public class KillZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            if (AudioManager.instance != null) AudioManager.instance.PlaySound(AudioManager.instance.deathClip);
            GameManager.Instance.KillBall();
        }
    }
}
