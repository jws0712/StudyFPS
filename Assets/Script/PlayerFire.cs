using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    public GameObject firePostion;

    public GameObject bombFactory;

    public float throwPower = 15f;

    public GameObject bulletEffect;

    ParticleSystem ps;

    public int weaponPower = 5;

    Animator anim;

    public GameObject[] eff_Flash;

    void Start()
    {
        ps = bulletEffect.GetComponent<ParticleSystem>();

        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.gm.gState != GameManager.GameState.Run)
        {
            return;
        }
        if (Input.GetMouseButtonDown(1))
        {
            GameObject bomb = Instantiate(bombFactory);
            bomb.transform.position = firePostion.transform.position;

            Rigidbody rb = bomb.GetComponent<Rigidbody>();

            rb.AddForce(Camera.main.transform.forward * throwPower, ForceMode.Impulse);
        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            RaycastHit hitInfo = new RaycastHit();

            StartCoroutine(ShootEffectOn(0.05f));

            if(anim.GetFloat("MoveMotion") == 0)
            {
                anim.SetTrigger("Attack");
            }

            if(Physics.Raycast(ray, out hitInfo))
            {
                if(hitInfo.transform.gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    EnemyFSM eFSM = hitInfo.transform.GetComponent<EnemyFSM>();
                    eFSM.HitEnemy(weaponPower);
                }
                else
                {
                    bulletEffect.transform.position = hitInfo.point;

                    bulletEffect.transform.forward = hitInfo.normal;

                    ps.Play();
                }
                
            }
        }
        IEnumerator ShootEffectOn(float duration)
        {
            int num = Random.Range(0, eff_Flash.Length);

            eff_Flash[num].SetActive(true);

            yield return new WaitForSeconds(duration);

            eff_Flash[num].SetActive(false);
        }

    }
}
