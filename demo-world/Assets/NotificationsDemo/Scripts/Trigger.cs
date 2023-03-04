
using UdonSharp;

[UdonBehaviourSyncMode(BehaviourSyncMode.None)]
public class Trigger : UdonSharpBehaviour
{
	public Notifications.Controller NotificationsController;

	public override void Interact()
	{
		NotificationsController.Activate("Notification Demo", "Notification which lasts 10 seconds.", 10f);
	}
}
