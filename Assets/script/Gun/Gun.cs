using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] public float damage = 10f;
    [SerializeField] public float range = 100f;

    [SerializeField] public Transform fpscam;

    private anime_health target;
    [SerializeField] public ParticleSystem MuzzleFlash;
    [SerializeField] GameObject impactEffect;
    [SerializeField] float ImpactForce;
    [SerializeField] Animator AnimationController;

    // Total ammo
    [SerializeField] int ammo_count = 100;
    [SerializeField] int magzean = 25;
    [SerializeField] int Ammo_in_gun = 25;
    //length of the animation
    [SerializeField] Animation reload;

    [SerializeField] AudioClip fire;
    [SerializeField] AudioClip reload_sound;
    [SerializeField] AudioSource AudioSource;
 
    private bool StateofReload = false;
    // Start is called before the first frame update
    void Start()
    {
        AnimationController = GetComponent<Animator>();
    }



    // Update is called once per frame
    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (magzean != Ammo_in_gun && ammo_count > 0)
            {
                AnimationController.Play("reload");
                AudioSource.PlayOneShot(reload_sound);
                StartCoroutine(reload_the_gun(2.5f));
            }

        }
        if (Input.GetButtonDown("Fire1"))
        {
            
            if (!StateofReload)
            {
                if (Ammo_in_gun == 0 && ammo_count > 0)
                {
                AnimationController.Play("reload");
                AudioSource.PlayOneShot(reload_sound);
                StartCoroutine(reload_the_gun(2.5f));
                return;
                }
                if(Ammo_in_gun > 0)
                {
                    AudioSource.PlayOneShot(fire);
                    Shoot();
                    AnimationController.Play("fire");
                }
                
            }

        }
        

        AnimationController.SetBool("isreload", false);
        AnimationController.SetBool("isfire", false);
    }



    void Shoot()
    {
        MuzzleFlash.Play();
        RaycastHit hit;
        Ammo_in_gun--;
        if (Physics.Raycast(fpscam.position, fpscam.forward, out hit, range))
        {

            target = hit.transform.GetComponent<anime_health>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * ImpactForce);
            }
            Debug.Log(hit.transform.gameObject.layer);
            if (hit.transform.gameObject.layer == LayerMask.NameToLayer("Ground"))
            {
                GameObject Ref = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(Ref, 7f);
            }
            //    AnimationController.SetBool("isfire",true);



        }
    }

    IEnumerator reload_the_gun(float waitTime)
    {
        StateofReload = true;
        yield return new WaitForSeconds(waitTime);
        reloadWork();
        StateofReload = false;
    }
    void reloadWork()
    {
        if (Ammo_in_gun == 0)
        {
            if (ammo_count < magzean)
            {
                Ammo_in_gun = ammo_count;
                ammo_count = 0;
            }
            else
            {
                Ammo_in_gun = magzean;
                ammo_count -= magzean;
            }
        }
        else
        {
            int need_ammo = magzean - Ammo_in_gun;
            Ammo_in_gun += need_ammo;
            ammo_count -= need_ammo;
        }
    }
}
