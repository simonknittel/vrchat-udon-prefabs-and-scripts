
using UdonSharp;
using UnityEngine;
using VRC.SDKBase;

namespace Respawner
{
	[UdonBehaviourSyncMode(BehaviourSyncMode.None)]
	public class Controller : UdonSharpBehaviour
	{
		public Transform RespawnPointTransform;

		public void ColliderHit()
		{
			Networking.LocalPlayer.TeleportTo(RespawnPointTransform.position, RespawnPointTransform.rotation);
		}
	}
}
