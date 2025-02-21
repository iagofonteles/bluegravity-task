using System;
using Utility;

namespace BlueGravity
{
    [Serializable]
    public class MoneyBag : Observable<int>, IJsonGameSave { }
}