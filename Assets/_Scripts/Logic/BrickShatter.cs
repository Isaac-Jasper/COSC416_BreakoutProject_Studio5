using System.Collections;
using UnityEngine;

public class BrickShatter : MonoBehaviour
{
    [SerializeField]
    private float minExplosion, maxExplosion, explosionRadius, upwardsModifier, deathTimer;

    private void Start()
    {
        Explode();
    }

    private void Explode() {
        foreach (Transform t in transform) {
            Rigidbody rb = t.GetComponent<Rigidbody>();
            float randForce = Random.Range(minExplosion, maxExplosion);

            rb.AddExplosionForce(randForce, transform.position, explosionRadius, upwardsModifier, ForceMode.Impulse);
            StartCoroutine(DeathTimer(t));
        }
        StartCoroutine(DeathTimer(transform));
    }

    private IEnumerator DeathTimer (Transform t) {
        yield return new WaitForSeconds(deathTimer);
        Destroy(t.gameObject);
    }
}
