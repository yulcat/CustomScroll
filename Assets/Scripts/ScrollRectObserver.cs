using System.Collections.Generic;
using UnityEngine;

namespace RectTest
{
    public class ScrollRectObserver : MonoBehaviour
    {
        [SerializeField] float _threshold = 0.1f;
        readonly List<ObservedScrollRect> _subjects = new();
        bool _moving = false;

        void Awake()
        {
            ObservedScrollRect.OnAdd += HandleOnAdd;
            ObservedScrollRect.OnRemove += HandleOnRemove;
        }

        void OnDestroy()
        {
            ObservedScrollRect.OnAdd -= HandleOnAdd;
            ObservedScrollRect.OnRemove -= HandleOnRemove;
        }

        void LateUpdate()
        {
            var moving = false;
            foreach (var subject in _subjects)
            {
                moving |= subject.velocity.sqrMagnitude > _threshold;
            }

            if (_moving == moving)
                return;

            Debug.Log($"Moving State Changed : {moving}");
            _moving = moving;
        }

        void HandleOnAdd(ObservedScrollRect scrollRect)
        {
            _subjects.Add(scrollRect);
        }

        void HandleOnRemove(ObservedScrollRect scrollRect)
        {
            _subjects.Remove(scrollRect);
        }
    }
}