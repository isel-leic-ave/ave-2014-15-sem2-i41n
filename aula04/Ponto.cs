using System;

public class Ponto {

	// readonly <=> Java final
	public readonly int _x, _y;

	public Ponto(int x, int y)
	{
		this._x = x;
		this._y = y;
	}

	public double GetModule() {	 
		return Math.Sqrt((double)_x*_x + _y*_y);
	}

	public void Print(){
		Console.WriteLine("Point (x = {0}, y = {1})", _x, _y);
	}

}