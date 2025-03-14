using System.Collections;
using UnityEngine;
using _Scripts.Utils;

public class Brick : MonoBehaviour
{
    private Coroutine destroyRoutine = null;
    private HotSwapColor colorComponent;

    private void Awake()
    {
        // Get or add the HotSwapColor component
        colorComponent = GetComponent<HotSwapColor>();
        if (colorComponent == null)
        {
            colorComponent = gameObject.AddComponent<HotSwapColor>();
        }
        
        // Set a random color
        AssignRandomColor();
    }

    private void AssignRandomColor()
    {
        // Check if we have the color manager
        if (BrickColourManager.Instance != null)
        {
            Color randomColor = BrickColourManager.Instance.GetRandomColor();
            colorComponent.SetColor(randomColor);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (destroyRoutine != null) return;
        if (!other.gameObject.CompareTag("Ball")) return;
        destroyRoutine = StartCoroutine(DestroyWithDelay());
    }

    private IEnumerator DestroyWithDelay()
{
    GameManager.Instance.PlayBrickShatter(transform.position, colorComponent.Color);
    yield return new WaitForSeconds(0.1f);
    GameManager.Instance.OnBrickDestroyed(transform.position);
    Destroy(gameObject);
}
}