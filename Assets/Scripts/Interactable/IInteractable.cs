using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utility;

namespace Interactable
{
    public interface IInteractable
    {
        public static readonly HashSet<IInteractable> Active = new();

        public static IInteractable GetNearest(Vector3 position, float rangeAdd)
            => Active
                .Select(i => (i, prox: GetProximity(i, position, rangeAdd)))
                .OrderBy(p => p.prox).FirstOrDefault(p => p.prox <= 0).i;

        static float GetProximity(IInteractable i, Vector3 pos, float rangeAdd)
        {
            var prox = (pos - i.Position).sqrMagnitude;
            prox -= rangeAdd * rangeAdd;
            prox -= i.Range * i.Range;
            return prox;
        }

        Vector3 Position { get; }
        float Range { get; }
        void Interact(IInteractor interactor);
        ObservableList<IInteractor> InteractorsInRange { get; }
    }
}