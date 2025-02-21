using UnityEngine;
using Utility;

namespace BlueGravity
{
    public class AudioSettings : IJsonGameSave
    {
        [SerializeField] private Observable<float> masterVolume = new(1);
        [SerializeField] private Observable<float> sfxVolume = new(1);
        [SerializeField] private Observable<float> bgmVolume = new(1);

        public Observable<float> MasterVolume => masterVolume;
        public Observable<float> SfxVolume => sfxVolume;
        public Observable<float> BgmVolume => bgmVolume;
    }
}