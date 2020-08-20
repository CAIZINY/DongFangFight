/*! \cond PRIVATE */
using UnityEngine;

namespace DarkTonic.PoolBoss.Examples
{
	public class PB_Instructions : MonoBehaviour
	{
		public Transform robotKylePrefab;

		private Vector3 spawnPos = new Vector3(-150, 0, 150);

		void OnGUI()
		{
			GUI.Label(new Rect(10, 10, 760, 90), "Click the button below to spawn 10 Robot Kyles at a time until you have 50. There are 50 in the pool, so they will spawn instantly with no impact on performance! You can watch them become active under the Pool Boss game object. If you try to spawn more than 50, Pool Boss will refuse and log an error in the Console. There is an option to 'Allow Instantiate More' that you can turn on though. Select the Pool Boss game object for more information and functions on the pool items at runtime. You can enable the 'PoolMiniBoss' Game Object to add its Sphere items to Pool Boss, and they will be removed when you disable it.");
			if (GUI.Button(new Rect(10, 100, 100, 30), "Spawn 10"))
			{
				for (var i = 0; i < 10; i++)
				{
					PoolBoss.SpawnInPool(robotKylePrefab, spawnPos, robotKylePrefab.rotation);
					spawnPos += new Vector3(40, 0, 0);
				}

				spawnPos.y = 0;
				spawnPos.z -= 100;
				spawnPos.x = -150;
			}

			if (GUI.Button(new Rect(10, 140, 100, 30), "Despawn All"))
			{
				PoolBoss.DespawnAllOfPrefab(robotKylePrefab);
				spawnPos = new Vector3(-150, 0, 150);
			}
		}

	}
}
/*! \endcond */