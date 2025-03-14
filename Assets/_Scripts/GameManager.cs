using UnityEngine;
using _Scripts.Utils;

public class GameManager : SingletonMonoBehavior<GameManager>
{
    [SerializeField] private int maxLives = 3;
    [SerializeField] private Ball ball;
    [SerializeField] private Transform bricksContainer;
    [SerializeField] private GameObject[] brickShatter;
    [SerializeField] private float blockDestroyShakeDuration, blockDestroyShakeStrength;

    private int currentBrickCount;
    private int totalBrickCount;

    private void OnEnable()
    {
        InputHandler.Instance.OnFire.AddListener(FireBall);
        ball.ResetBall();
        totalBrickCount = bricksContainer.childCount;
        currentBrickCount = bricksContainer.childCount;
    }

    private void OnDisable()
    {
        InputHandler.Instance.OnFire.RemoveListener(FireBall);
    }

    private void FireBall()
    {
        ball.FireBall();
    }

    public void PlayBrickShatter(Vector3 position, Color brickColor)
{
    CameraShake.Instance.Shake(blockDestroyShakeDuration, blockDestroyShakeStrength);
    int rand = Random.Range(0, brickShatter.Length);
    GameObject shatterInstance = Instantiate(brickShatter[rand], position, brickShatter[rand].transform.rotation);
    
    // Apply the brick color to all shatter pieces
    foreach (Transform piece in shatterInstance.transform)
    {
        HotSwapColor colorComponent = piece.GetComponent<HotSwapColor>();
        if (colorComponent != null)
        {
            colorComponent.SetColor(brickColor);
        }
    }
}
    public void OnBrickDestroyed(Vector3 position)
    {   
        // fire audio here
        // implement particle effect here
        // add camera shake here
        currentBrickCount--;
        Debug.Log($"Destroyed Brick at {position}, {currentBrickCount}/{totalBrickCount} remaining");
        if(currentBrickCount == 0) SceneHandler.Instance.LoadNextScene();
    }

    public void KillBall()
    {
        maxLives--;
        // update lives on HUD here
        // game over UI if maxLives < 0, then exit to main menu after delay
        ball.ResetBall();
    }
}
