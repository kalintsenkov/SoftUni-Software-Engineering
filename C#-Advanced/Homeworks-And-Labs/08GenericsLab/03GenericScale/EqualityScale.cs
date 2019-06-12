namespace GenericScale
{
    using System;

    public class EqualityScale<T>
    {
        private T left;
        private T right;

        public EqualityScale(T left, T right)
        {
            this.left = left;
            this.right = right;
        }

        public bool AreEqual()
        {
            return this.left.Equals(this.right);
        }
    }
}
