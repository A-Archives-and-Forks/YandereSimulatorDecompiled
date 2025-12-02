namespace HNS
{
	public class ButtonState
	{
		private bool _current;

		private bool _previous;

		public bool IsHeld => _current;

		public bool WasPressed
		{
			get
			{
				if (_current)
				{
					return !_previous;
				}
				return false;
			}
		}

		public bool WasReleased
		{
			get
			{
				if (!_current)
				{
					return _previous;
				}
				return false;
			}
		}

		public void Update(bool rawState)
		{
			_previous = _current;
			_current = rawState;
		}
	}
}
