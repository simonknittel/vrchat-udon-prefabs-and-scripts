
using UdonSharp;
using UnityEngine;

namespace Notifications
{
	enum State
	{
		Inactive,
		InAnimation,
		Active,
		OutAnimation
	}

	[UdonBehaviourSyncMode(BehaviourSyncMode.None)]
	public class Controller : UdonSharpBehaviour
	{
		public UnityEngine.UI.Text Label;
		public UnityEngine.UI.Text Body;
		public UnityEngine.UI.Slider Slider;
		public Animator Animator;
		public float AnimationDuration;
		public float DefaultTimeVisible;
		public GameObject Notification;
		private State _state = State.Inactive;
		private float _elapsedTime = 0f;
		private float _timeVisible = 0f;

		public void Activate(string newLabel, string newBody, float timeVisible = 0)
		{
			_timeVisible = timeVisible == 0 ? DefaultTimeVisible : timeVisible;
			_elapsedTime = 0f;
			Label.text = newLabel;
			Body.text = newBody;
			Notification.SetActive(true);
			Animator.SetBool("isVisible", true);

			_state = State.InAnimation;
		}

		public void Disable()
		{
			_state = State.Inactive;

			Notification.SetActive(false);
		}

		void Update()
		{
			if (_state != State.InAnimation && _state != State.Active && _state != State.OutAnimation) return;

			_elapsedTime += Time.deltaTime;

			if (_elapsedTime <= AnimationDuration)
			{
			}
			else if (_elapsedTime <= AnimationDuration + _timeVisible)
			{
				float timeLeft = _timeVisible - _elapsedTime;
				float percentage = timeLeft / _timeVisible;
				Slider.SetValueWithoutNotify(Mathf.Clamp(percentage, 0, 1));
			}
			else if (_elapsedTime <= AnimationDuration + _timeVisible + AnimationDuration)
			{
				Animator.SetBool("isVisible", false);
			}
			else if (_elapsedTime >= AnimationDuration + _timeVisible + AnimationDuration)
			{
				Disable();
			}
		}
	}
}
