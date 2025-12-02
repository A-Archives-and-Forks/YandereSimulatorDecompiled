namespace HNS
{
	public interface IState
	{
		EnemyState State { get; }

		void Start();

		void Update(float deltaTime);

		void FixedUpdate(float fixedDeltaTime);

		void LateUpdate(float deltaTime);

		void Exit();
	}
}
