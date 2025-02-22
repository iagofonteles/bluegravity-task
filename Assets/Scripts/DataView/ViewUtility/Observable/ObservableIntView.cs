namespace ViewUtility
{
    public class ObservableIntView : ObservableViewT<int>
    {
        public void Add(int value) => Data.Value += value;
        public void Subtract(int value) => Data.Value -= value;
        public void Multiply(int value) => Data.Value *= value;
        public void Divide(int value) => Data.Value /= value;
    }
}