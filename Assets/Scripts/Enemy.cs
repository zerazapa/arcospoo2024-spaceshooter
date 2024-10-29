﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy Properties")]
    public float health = 100;
    public float shotCounter;
    public float minTimeBetweenShots = 0.2f;
    public float maxTimeBetweenShots = 3f;

    [Header("Audio Source")]
    public AudioSource audioSource;
    public AudioClip shootSound;
    [Range(0, 1)]
    public float shootSoundVolume = 0.5f;

    public GameObject EnemyLaser;
    public GameObject HitFX;

    public virtual void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    void Update()
    {
        CountDownToShoot();
    }

    private void CountDownToShoot()
    {
        shotCounter -= Time.deltaTime;
        if ( shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        GameObject laser = Instantiate(EnemyLaser);
        if (laser != null)
        {
            laser.transform.position = transform.position;
            laser.transform.rotation = Quaternion.identity;
            laser.SetActive(true);
            audioSource.PlayOneShot(shootSound, shootSoundVolume);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.gameObject.GetComponent<DamageDealer>();

        if ( damageDealer)
        {
            TakeDamage(damageDealer.GetDamage());

            damageDealer.Hit();
        }
    }

    private void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            GameObject explosionFX = Instantiate(HitFX);
            if (explosionFX)
            {
                explosionFX.transform.position = transform.position;
                explosionFX.transform.rotation = Quaternion.identity;
                explosionFX.SetActive(true);
            }
            gameObject.SetActive(false);
        }
    }
}
