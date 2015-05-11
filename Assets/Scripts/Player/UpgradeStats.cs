using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum UpgradeType { ShotDamage,MoveSpeed,ShotArc,ShotRange,ShotSpeed,NumShots,NumPickups }

public class UpgradeStats : MonoBehaviour {

	// Use this for initialization
	public int upgradeCost = 5;

	public UpgradeType types;
	public Texture ShotDamage,MoveSpeed,ShotArc,ShotRange,ShotSpeed,NumShots,NumPickups;

	public float shotDamageBonus=0f;
	public float moveSpeedBonus=0f;
	public float shotArcBonus=0f;
	public float shotRangeBonus=0f;
	public float shotSpeedBonus=0f;

	public float barSizeBonus=0f;
	public int numShotsBonus=0;
	public int numPickupsBonus=0;

	public Texture upgradeTexture;

	void Start () {

		switch(types){
			case UpgradeType.ShotDamage:
			upgradeTexture=ShotDamage;
			break;
			case UpgradeType.MoveSpeed:
			upgradeTexture=MoveSpeed;
			break;
			case UpgradeType.ShotArc:
			upgradeTexture=ShotArc;
			break;
			case UpgradeType.ShotRange:
			upgradeTexture=ShotRange;
			break;
			case UpgradeType.ShotSpeed:
			upgradeTexture=ShotSpeed;
			break;
			case UpgradeType.NumShots:
			upgradeTexture=NumShots;
			break;
			case UpgradeType.NumPickups:	
			upgradeTexture=NumPickups;
			break;
			           }

		GetComponent<MeshRenderer>().materials[0].SetTexture(0,upgradeTexture);
	}


}
