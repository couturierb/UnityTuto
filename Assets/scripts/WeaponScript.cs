using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour {

	//--------------------------------
	// 1 - Designer variables
	//--------------------------------

	/// <summary>
	/// Prefab du projectile
	/// </summary>
	public GameObject shotPrefab;

	/// <summary>
	/// Temps de rechargement entre deux tirs
	/// </summary>
	public float shootingRate = 0.25f;

	//--------------------------------
	// 2 - Rechargement
	//--------------------------------

	private float shootCooldown;

	void Start()
	{
		shootCooldown = 0f;
	}

	void Update()
	{
		if (shootCooldown > 0)
		{
			shootCooldown -= Time.deltaTime;
		}
	}

	//--------------------------------
	// 3 - Tirer depuis un autre script
	//--------------------------------

	/// <summary>
	/// Création d'un projectile si possible
	/// </summary>
	public void Attack(bool isEnemy)
	{
		if (CanAttack)
		{
			shootCooldown = shootingRate;

			// Création d'un objet copie du prefab
			GameObject shotGameObject = Instantiate(shotPrefab);

			// Position
			shotGameObject.transform.position = transform.position;

			// Propriétés du script
			ShootScript shot = shotGameObject.GetComponent<ShootScript>();
			if (shot != null)
			{
				shot.isEnemyShot = isEnemy;
			}

			// On saisit la direction pour le mouvement
			MoveScript move = shotGameObject.GetComponent<MoveScript>();
			if (move != null)
			{
				move.direction = this.transform.right; // ici la droite sera le devant de notre objet
			}
		}
	}

	/// <summary>
	/// L'arme est chargée ?
	/// </summary>
	public bool CanAttack
	{
		get
		{
			return shootCooldown <= 0f;
		}
	}

}
