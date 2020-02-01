﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackBehaviour : MonoBehaviour
{
    private int level = 1;
    private float timeToLevelUp;
    private float timeFromLevelUp = 0;
    private float timeFromLastWaterDrop = 0;

    public Sprite[] levelSprites;
    public GameObject waterdropPrefab;

    public float waterdropSpawnSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        timeToLevelUp = Random.Range(1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        levelUp();
        dropWater();
    }

    void levelUp()
    {
        if(this.level < 3)
        {
            timeFromLevelUp += Time.deltaTime;
            if(timeFromLevelUp >= timeToLevelUp)
            {
                level++;
                timeFromLevelUp = 0;
                updateSprite();
            }
        }
    }

    void updateSprite()
    {
        this.GetComponent<SpriteRenderer>().sprite = this.levelSprites[this.level - 1];
    }

    void dropWater()
    {
        timeFromLastWaterDrop += Time.deltaTime;
        if(timeFromLastWaterDrop >= waterdropSpawnSpeed / level)
        {
            spawnWaterDrop();
            timeFromLastWaterDrop = 0;
        }
    }

    void spawnWaterDrop()
    {
        GameObject waterdrop = Instantiate(waterdropPrefab);
        waterdrop.transform.parent = this.transform;
        waterdrop.transform.position = this.transform.position;
    }
}
