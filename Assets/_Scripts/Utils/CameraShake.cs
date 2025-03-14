using DG.Tweening;
using UnityEngine;

public class CameraShake : SingletonMonoBehavior<CameraShake>
{
    private Vector3 startPos;
    private Quaternion startRotation;
    [SerializeField]
    private float resetSpeed;

    private Tweener activeTween;
    void Start()
    {
        startPos = transform.position;
        startRotation = transform.rotation;
    }

    void Update()
    {
        if (activeTween == null || !activeTween.active) {
            transform.position = Vector3.Lerp(transform.position, startPos, resetSpeed * Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, startRotation, resetSpeed * Time.deltaTime);
        }
    }
    public void Shake(float duration, float strength)
    {
        Instance.OnShake(duration, strength);
    }

    private void OnShake(float duration, float strength)
    {
        activeTween = transform.DOShakePosition(duration, strength);
        transform.DOShakeRotation(duration, strength);
    }
}
