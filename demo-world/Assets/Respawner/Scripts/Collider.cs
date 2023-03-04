
using UdonSharp;
using VRC.SDKBase;

namespace Respawner
{

	[UdonBehaviourSyncMode(BehaviourSyncMode.None)]
	public class Collider : UdonSharpBehaviour
	{
		public Controller Controller;

		public override void OnPlayerTriggerEnter(VRCPlayerApi player)
		{
			if (player != Networking.LocalPlayer) return;
			Controller.ColliderHit();
		}
	}
}
