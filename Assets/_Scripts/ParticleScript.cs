using UnityEngine;

public class ParticleScript : MonoBehaviour{
    public ParticleSystem sparkParticle;

    void OnCollisionEnter(Collision collision){
        if(collision.gameObject.CompareTag("Environment")||collision.gameObject.CompareTag("Paddle")){
            ContactPoint contact = collision.contacts[0];
            ParticleSystem spark = Instantiate(sparkParticle, contact.point, Quaternion.LookRotation(contact.normal));
            
            spark.Play();
            
            Destroy(spark.gameObject, spark.main.duration + spark.main.startLifetime.constantMax);
        }
    }
}
