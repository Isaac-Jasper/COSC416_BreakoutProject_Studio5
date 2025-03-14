using UnityEngine;

public class Debug_ShatterBrick : MonoBehaviour
{
    [SerializeField] private GameObject[] brickShatter;
    [SerializeField] private Vector3 position;
    [SerializeField] private float blockDestroyShakeDuration, blockDestroyShakeStrength;
    [SerializeField] bool debug;
    public void ShatterBrick() {
        if (!debug) return;
        
        CameraShake.Instance.Shake(blockDestroyShakeDuration, blockDestroyShakeStrength);
        int rand = Random.Range(0,brickShatter.Length);
        Instantiate(brickShatter[rand], position, brickShatter[rand].transform.rotation);
    }
}
