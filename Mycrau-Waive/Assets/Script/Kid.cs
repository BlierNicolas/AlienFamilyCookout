using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kid : System.Object {
	private int id;
	private int status;


	public Kid(int id, int status) {
		Id = id;
		Status = status;
	}

	public int Id {
		get {return id;}
		set {id = value;}
	}
	public int Status {
		get { return status; }
		set { 
			if ((value < -2) || (value > 4)) {
				status = 0;
			} else {
				status = value;
			}
		}
	}
}
