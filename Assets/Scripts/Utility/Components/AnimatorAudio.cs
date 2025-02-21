using System;
using System.Collections.Generic;
using UnityEngine;

namespace BlueGravityView
{
    public class AnimatorAudio : MonoBehaviour
    {
        public Transform audiosParent;

        Dictionary<string, Action> _audioMap = new();

        [ContextMenu("Refresh")]
        private void Refresh()
        {
            for (int i = 0; i < audiosParent.childCount; i++)
            {
                var source = audiosParent.GetChild(i).GetComponent<AudioSource>();
                if (source == null) continue;
                _audioMap.Add(source.name, source.Play);
            }
        }

        private void Start() => Refresh();
        public void PlayAudio(string name) => _audioMap.GetValueOrDefault(name)?.Invoke();
    }
}