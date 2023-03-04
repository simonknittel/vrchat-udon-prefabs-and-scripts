
using UdonSharp;
using VRC.SDKBase;

namespace Notifications
{
	[UdonBehaviourSyncMode(BehaviourSyncMode.None)]
	public class PlayerHeadFollower : UdonSharpBehaviour
	{
		VRCPlayerApi localPlayer;

		void Start()
		{
			localPlayer = Networking.LocalPlayer;
		}

		void Update()
		{
			VRCPlayerApi.TrackingData trackingData = localPlayer.GetTrackingData(VRCPlayerApi.TrackingDataType.Head);
			this.transform.SetPositionAndRotation(trackingData.position, trackingData.rotation);
		}
	}
}
