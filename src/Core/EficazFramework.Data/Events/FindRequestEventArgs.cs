
namespace EficazFrameworkCore.Events
{
    public sealed class FindRequestEventArgs
    {
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

        private object _data = null;
        public object Data
        {
            get
            {
                return _data;
            }

            set
            {
                _data = value;
                _read = true;
            }
        }

        private bool _read = false;
        public bool Completed
        {
            get
            {
                return _read;
            }
        }

        public string Literal { get; private set; } = null;

        private System.Threading.CancellationToken _cancellationToken;

        public System.Threading.CancellationToken CancellationToken
        {
            get
            {
                return _cancellationToken;
            }
        }

        public FindRequestEventArgs(string literal, System.Threading.CancellationToken cancellationToken = default)
        {
            Literal = literal;
            _cancellationToken = cancellationToken;
        }
    }

    public delegate void FindRequestEventHandler(object sender, FindRequestEventArgs e);
}