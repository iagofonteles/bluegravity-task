using UnityEngine;
using Utility;

namespace Interactable
{
    public interface IInteractor
    {
        Vector3 Position { get; }
        float Range { get; }
        Observable<IInteractable> NearestInteracble { get; }

        public void TryInteract(object interactor = null) 
            => NearestInteracble.Value?.Interact(interactor ?? this);

        public void UpdateInteractable()
        {
            var nearest = IInteractable.GetNearest(Position, Range);
            if (NearestInteracble.Value == nearest) return;
            NearestInteracble.Value?.InteractorsInRange.Remove(this);
            NearestInteracble.Value = nearest;
            NearestInteracble.Value?.InteractorsInRange.Add(this);
        }
    }
}