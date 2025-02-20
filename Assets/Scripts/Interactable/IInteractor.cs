using UnityEngine;
using Utility;

namespace Interactable
{
    public interface IInteractor
    {
        Vector3 Position { get; }
        float Range { get; }
        Observable<IInteractable> NearestInteracble { get; }

        public void UpdateInteractable()
        {
            var nearest = IInteractable.GetNearest(Position, Range);
            NearestInteracble.Value = nearest;
        }
    }
}