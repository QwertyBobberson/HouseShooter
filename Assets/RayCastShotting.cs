using System;
using UnityEngine;

public class RayCastShotting : MonoBehaviour
{
    [SerializeField] int Damage;
    [SerializeField] int Range;
    [SerializeField] Camera FPSCam;
	[SerializeField] double FireRate;
	[SerializeField] GameObject BulletHitEffect;
	[SerializeField] GameObject Bleed;
	[SerializeField] GameObject GunTip;
	[SerializeField] GameObject HitWall;
	private LineRenderer GunShot;
	private double TimeSinceLastShot = 0;

	private void Start()
	{
		GunShot = this.GetComponent<LineRenderer>();
		GunShot.enabled = false;
	}

	void Update ()
    {
		GunShot.SetPosition(0, GunTip.transform.position);
		if (Input.GetButton("Fire1"))
        {
			if (TimeSinceLastShot >= FireRate)
			{
				Shoot();
				TimeSinceLastShot = 0;
			}
        }

		TimeSinceLastShot += Time.deltaTime;

	}
    void Shoot()
    {
		
		GameObject GunFlashAnimation = GameObject.Instantiate(BulletHitEffect, GunTip.transform.position, GunTip.transform.rotation);
		GunFlashAnimation.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
		GunFlashAnimation.transform.parent = GunTip.transform;
		ParticleSystem GunFlash = GunFlashAnimation.GetComponent<ParticleSystem>();
		GunFlash.Play();
		Destroy(GunFlashAnimation, .05f);
		RaycastHit hit;
		if (Physics.Raycast(FPSCam.transform.position, FPSCam.transform.forward, out hit, Range))
		{
			GunShot.SetPosition(1, hit.point);
			GunShot.enabled = true;
			Invoke("ResetLine", Time.deltaTime);
			ZombieHealth ZombieHealth = hit.transform.GetComponent<ZombieHealth>();
			if (ZombieHealth != null)
			{
				ZombieHealth.TakeDamage(Damage);
				GameObject Bleeding = GameObject.Instantiate(Bleed, hit.point, hit.transform.rotation);
				Bleeding.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
				Bleeding.transform.parent = hit.transform;
				ParticleSystem BleedingEffect = GunFlashAnimation.GetComponent<ParticleSystem>();
				BleedingEffect.Play();
				Destroy(Bleeding, 0.3f);
			}
			else if (hit.transform.GetComponent<RayCastShotting>() == null)
			{
				GameObject HitWallEffect = GameObject.Instantiate(HitWall, hit.point, hit.transform.rotation);
				HitWallEffect.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
				HitWallEffect.transform.parent = hit.transform;
				ParticleSystem HitWallParticle = HitWallEffect.GetComponent<ParticleSystem>();
				HitWallParticle.Play();
				Destroy(HitWallEffect, 0.25f);
			}
		}
		else
		{
			GunShot.SetPosition(1, FPSCam.transform.forward * Range);
			GunShot.enabled = true;
		}
	}

	private void ResetLine()
	{
		GunShot.enabled = false;
	}
}
