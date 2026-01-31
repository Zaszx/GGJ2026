using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HeavyAttackLoading : MonoBehaviour
    {
        private Image _fill;

        private void Awake()
        {
            _fill = GetComponent<Image>();
        }

        public float GetProgress()
        {
            return _fill.fillAmount;
        }
        public void SetProgress(float value)
        {
            _fill.fillAmount = Mathf.Clamp01(value);
        }

        public void ResetBar()
        {
            _fill.fillAmount = 0f;
        }

        public void Complete()
        {
            _fill.fillAmount = 1f;
        }
    }
}