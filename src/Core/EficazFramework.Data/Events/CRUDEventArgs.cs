using System;

namespace EficazFramework.Events
{
    public class CRUDEventArgs<T> : EventArgs where T : class
    {
        public CRUDEventArgs(Enums.CRUD.eAction action, Enums.CRUD.eState state = Enums.CRUD.eState.Processando, T entry = null)
        {
            Action = action;
            if (entry != null)
                CurrentEntry = entry;
            if ((int)state > -1)
                State = state;
        }

        public Enums.CRUD.eAction Action { get; private set; }
        public EficazFramework.Enums.CRUD.eState State { get; private set; }
        public T CurrentEntry { get; private set; }
        public EficazFramework.Collections.StringCollection ValidationErrors { get; private set; } = new EficazFramework.Collections.StringCollection();

        private bool _cancel;
        public bool Cancel
        {
            get
            {
                return _cancel;
            }

            set
            {
                _cancel = value;
            }
        }

        private object _tag;
        public object Tag
        {
            get
            {
                return _tag;
            }

            set
            {
                _tag = value;
            }
        }
    }

    public delegate void CRUDEventHandler<T>(object sender, CRUDEventArgs<T> e) where T : class;
}