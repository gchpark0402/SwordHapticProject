using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyScript : MonoBehaviour
{
    [SerializeField]
    private GameObject hitEffectPrefab;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Sword"))
        {
            StartCoroutine(HitEffect(collision));
        }
    }

    IEnumerator HitEffect(Collision collision)
    {
        GameObject hitEffect = Instantiate(hitEffectPrefab, collision.GetContact(0).point, Quaternion.identity);
        hitEffect.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        audioSource.Play();
        yield return new WaitForSeconds(1);
        Destroy(hitEffect);

    }
}
