using System;


namespace Ju.GundamWars
{

    public class Wrapper<T> : BindableBase
    {

        public Wrapper(Func<T> getter, Action<T> setter)
        {
            this.getter = getter;
            this.setter = setter;
        }


        private readonly Func<T> getter = null!;
        private readonly Action<T> setter = null!;

        // Item だと Binding で不都合が生じる
        public T Item1
        {
            get => getter();
            set
            {
                setter(value);
                OnPropertyChanged();
            }
        }

    }

    public class Wrapper<T1, T2> : BindableBase
    {

        public Wrapper(Func<T1> getter1, Action<T1> setter1, Func<T2> getter2, Action<T2> setter2)
        {
            this.getter1 = getter1;
            this.setter1 = setter1;
            this.getter2 = getter2;
            this.setter2 = setter2;
        }


        private readonly Func<T1> getter1 = null!;
        private readonly Action<T1> setter1 = null!;
        private readonly Func<T2> getter2 = null!;
        private readonly Action<T2> setter2 = null!;

        public T1 Item1
        {
            get => getter1();
            set
            {
                setter1(value);
                OnPropertyChanged();
            }
        }
        public T2 Item2
        {
            get => getter2();
            set
            {
                setter2(value);
                OnPropertyChanged();
            }
        }

    }

}
