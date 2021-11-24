using System;

namespace EficazFramework.Attributes.UIEditor.EditingState
{

    /// <summary>
    /// TBA: Working only with EfSearchBox in WPF
    /// </summary>
    /// <remarks></remarks>
    [AttributeUsage(AttributeTargets.Property)]
    public class EnabledOnlyInStateAttribute : Attribute
    {
        public EnabledOnlyInStateAttribute(EficazFramework.Enums.CRUD.eState State)
        {
            _state = State;
        }

        private EficazFramework.Enums.CRUD.eState _state;

        public EficazFramework.Enums.CRUD.eState ScreenState
        {
            get
            {
                return _state;
            }

            set
            {
                _state = value;
            }
        }
    }
}