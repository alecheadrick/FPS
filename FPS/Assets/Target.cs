using UnityEngine;

public class Target : MonoBehaviour {

	#region Variables
	public float health = 50f;
	public GameObject explosion;
	#endregion

	#region Methods
	public void TakeDamage (float amount)
	{
		health -= amount;
		if (health <= 0f) {
			die();
		}
	}

	void die()
	{
		GameObject newExplosion = (GameObject)Instantiate(explosion);
		newExplosion.transform.position = this.transform.position;
		Object.Destroy(newExplosion, 4.0f);
		Object.Destroy(this.gameObject);
	}
#endregion
}
