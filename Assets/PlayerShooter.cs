using UnityEngine;
using System.Collections;

public class PlayerShooter : Shooter {
	public WeaponType weaponType;

	public override void Start(){
		base.Start ();
		equipWeapon (WeaponType.Pistol);
	}

	public override void Fire(){
		switch (weaponType) {
		case WeaponType.Pistol:
			base.Fire ();
			break;

		case WeaponType.Shotgun:
			FireShotgun();
			break;

		case WeaponType.MachineGun:
			FireMachineGun();
			break;
		}
	}

	public void equipWeapon(WeaponType type){
		weaponType = type;

		switch (type) {
		case WeaponType.Pistol:
			attackSpeed = 0.08f;
			break;
			
		case WeaponType.Shotgun:
			attackSpeed = 0.18f;
			break;

		case WeaponType.MachineGun:
			attackSpeed = 0.12f;
			break;
		}
	}

	private void FireShotgun(){
		Vector3 pos = transform.position + (transform.up * 0.7f);
		Instantiate (bullet, pos + (transform.right * 0.3f), Quaternion.Euler (transform.rotation.eulerAngles + new Vector3(0,0,-5)));
		Instantiate (bullet, pos + (transform.right * -0.3f), Quaternion.Euler (transform.rotation.eulerAngles + new Vector3(0,0,5)));
		Instantiate (bullet, pos + (transform.up * 0.2f), Quaternion.Euler (transform.rotation.eulerAngles));
	}

	private void FireMachineGun(){
		Invoke ("FireMachineGunBullet", 0);
		Invoke ("FireMachineGunBullet", 0.04f);
		Invoke ("FireMachineGunBullet", 0.08f);
	}

	private void FireMachineGunBullet(){
		Vector3 pos = transform.position + (transform.right * Random.Range (-0.2f, 0.2f)) + (transform.up * Random.Range (0f, 1f));
		Quaternion rot = Quaternion.Euler (transform.rotation.eulerAngles + new Vector3 (0, 0, Random.Range (-12f, 12f)));
		Instantiate (bullet, pos, rot);
	}
}
