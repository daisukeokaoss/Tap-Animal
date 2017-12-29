using UnityEngine;

public class GameManagementSingleton{
	private static GameManagementSingleton mInstance;

	private GameManagementSingleton()
	{
		Debug.Log("Create and GameManagementSingleton class");
	}

	public static GameManagementSingleton Instance
	{
		get{
			if (mInstance == null)
				mInstance = new GameManagementSingleton ();

			return mInstance;
		}
	}

	private int CoinPoint = 0;

	public void SetCoinPoint(int point){
		this.CoinPoint = point;
		if (MaxCoinPoint < this.CoinPoint) {
			MaxCoinPoint = this.CoinPoint;
		}
	}

	public int GetCoinPoint()
	{
		return this.CoinPoint;
	}

	public void IncreaseCoinPoint(int inc)
	{
		this.CoinPoint += inc;
		if (MaxCoinPoint < this.CoinPoint) {
			MaxCoinPoint = this.CoinPoint;
		}
	}

	public void DecreaseCoinPoint(int dec)
	{
		this.CoinPoint -= dec;
	}


	public float CurrentTime = 0;

	public float GameDuration = 600;

	public int MaxCoinPoint = 0;

}
