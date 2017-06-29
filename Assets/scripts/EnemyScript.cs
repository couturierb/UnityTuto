using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{
	private bool hasSpawn;
	private MoveScript moveScript;
	private WeaponScript[] weapons;
	private Collider2D collider2D;

	void Awake()
	{
		// Récupération de toutes les armes de l'ennemi
		weapons = GetComponentsInChildren<WeaponScript>();

		// Récupération du script de mouvement lié
		moveScript = GetComponent<MoveScript>();

		collider2D = GetComponent<Collider2D>();
	}

	void Start()
	{
		hasSpawn = false;

		// On désactive tout
		// -- collider
		collider2D.enabled = false;
		// -- Mouvement
		moveScript.enabled = false;
		Debug.Log (moveScript);
		// -- Tir
		foreach (WeaponScript weapon in weapons)
		{
			weapon.enabled = false;
		}
	}

	void Update()
	{
		if (hasSpawn == false) {
			if (GetComponent<Renderer>().IsVisibleFrom (Camera.main)) {
				Spawn ();
			}
		} else {
			foreach (WeaponScript weapon in weapons)
			{
				// On fait tirer toutes les armes automatiquement
				if (weapon != null && weapon.enabled && weapon.CanAttack)
				{
					weapon.Attack(true);

					SoundEffectsHelper.Instance.MakeEnemyShotSound();
				}
			}
	

			// 4 - L'ennemi n'a pas été détruit, il faut faire le ménage
			if (GetComponent<Renderer>().IsVisibleFrom(Camera.main) == false)
			{
				Destroy(gameObject);
			}
		}
	}

	// 3 - Activation
	private void Spawn()
	{
		hasSpawn = true;

		// On active tout
		// -- Collider
		collider2D.enabled = true;
		// -- Mouvement
		moveScript.enabled = true;
		// -- Tir
		foreach (WeaponScript weapon in weapons)
		{
			weapon.enabled = true;
		}
	}
}

