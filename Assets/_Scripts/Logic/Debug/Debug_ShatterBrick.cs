using UnityEngine;

public class Debug_ShatterBrick : MonoBehaviour
{
    [SerializeField] private GameObject[] brickShatter;
    [SerializeField] private Vector3 position;
    public void ShatterBrick() {
        int rand = Random.Range(0,brickShatter.Length);
        Instantiate(brickShatter[rand], position, brickShatter[rand].transform.rotation);
    }
}
