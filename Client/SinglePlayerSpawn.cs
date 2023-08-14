using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinglePlayerSpawn : MonoBehaviour {

	
	public GameObject player;

	public Vector3 center, size;

	void Start () {
		if (GameManager.Instance.multiplayer == false)
        {
			SpawnPlayer();
        }
	}

	public void SpawnPlayer()
    {
		Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));

		player = Instantiate(player, pos, Quaternion.identity);
	}
	
	void OnDrawGizmos()
    {
		Gizmos.color = new Color(1.0f, 0f, 0f);
		Gizmos.DrawWireCube(center, size);
    }
}
