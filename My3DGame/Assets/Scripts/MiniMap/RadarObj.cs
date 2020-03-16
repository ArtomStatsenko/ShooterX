using UnityEngine;
using UnityEngine.UI;


namespace StatsenkoAA
{
	public class RadarObj : MonoBehaviour
	{
		[SerializeField] private Image _ico;

        private void OnValidate()
        {
            _ico = Resources.Load<Image>("UI/Image (1)");
        }

        private void OnDisable()
		{
			Radar.RemoveRadarObject(gameObject);
		}

		private void OnEnable()
		{
			Radar.RegisterRadarObject(gameObject, _ico);
		}
	}
}