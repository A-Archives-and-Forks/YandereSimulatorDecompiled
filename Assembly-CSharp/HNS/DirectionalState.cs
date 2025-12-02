using UnityEngine;

namespace HNS
{
	public class DirectionalState
	{
		private bool[] _current = new bool[4];

		private bool[] _previous = new bool[4];

		private readonly float _threshold;

		public DirectionalState(float threshold)
		{
			_threshold = threshold;
		}

		public void Update(Vector2 input)
		{
			for (int i = 0; i < 4; i++)
			{
				_previous[i] = _current[i];
			}
			_current[0] = input.y > _threshold;
			_current[1] = input.y < 0f - _threshold;
			_current[2] = input.x < 0f - _threshold;
			_current[3] = input.x > _threshold;
		}

		public bool IsHeld(Direction direction)
		{
			return _current[(int)direction];
		}

		public bool WasPressed(Direction direction)
		{
			if (_current[(int)direction])
			{
				return !_previous[(int)direction];
			}
			return false;
		}

		public bool WasReleased(Direction direction)
		{
			if (!_current[(int)direction])
			{
				return _previous[(int)direction];
			}
			return false;
		}
	}
}
