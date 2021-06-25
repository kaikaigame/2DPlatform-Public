using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class DestructibleLayer : MonoBehaviour
{
    //public GameObject obj;
    public float offsetX;
    public float offsetY;

    private Tilemap destructibleTilemap;
    private Rigidbody2D rb2d;

    private Vector3 pos1;
    private Vector3 pos2;
    private Vector3 pos3;
    private Vector3 pos4;
    private Vector3 pos5;
    private Vector3 pos6;
    private Vector3 pos7;
    private Vector3 pos8;


    void Start()
    {
        destructibleTilemap = GetComponent<Tilemap>();
        rb2d = GetComponent<Rigidbody2D>();
        //rb2d.useFullKinematicContacts = true;
    }

    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            //该包围盒上最近的点
            //如果该点在包围盒内，则将返回未修改的点位置
            Vector3 hitPos = other.gameObject.GetComponent<Collider2D>().
                bounds.ClosestPoint(other.transform.position);

            pos1 = new Vector3(hitPos.x + offsetX, hitPos.y, 0f);
            pos2 = new Vector3(hitPos.x - offsetX, hitPos.y, 0f);
            pos3 = new Vector3(hitPos.x, hitPos.y + offsetY, 0f);
            pos4 = new Vector3(hitPos.x, hitPos.y - offsetY, 0f);
            pos5 = new Vector3(hitPos.x + offsetX, hitPos.y + offsetY, 0f);
            pos6 = new Vector3(hitPos.x + offsetX, hitPos.y - offsetY, 0f);
            pos7 = new Vector3(hitPos.x - offsetX, hitPos.y + offsetY, 0f);
            pos8 = new Vector3(hitPos.x - offsetX, hitPos.y - offsetY, 0f);

            //使用整数的3D向量和点表示形式 Vector3Int
            //将世界位置转换为单元格位置 WorldToCell
            Vector3Int position = destructibleTilemap.WorldToCell(pos1);
            //根据给定的瓦片地图中某个单元格的XYZ坐标，设置瓦片 SetTile
            //瓦片摧毁
            destructibleTilemap.SetTile(position, null);

            position = destructibleTilemap.WorldToCell(pos2);
            destructibleTilemap.SetTile(position, null);

            position = destructibleTilemap.WorldToCell(pos3);
            destructibleTilemap.SetTile(position, null);

            position = destructibleTilemap.WorldToCell(pos4);
            destructibleTilemap.SetTile(position, null);

            position = destructibleTilemap.WorldToCell(pos5);
            destructibleTilemap.SetTile(position, null);

            position = destructibleTilemap.WorldToCell(pos6);
            destructibleTilemap.SetTile(position, null);

            position = destructibleTilemap.WorldToCell(pos7);
            destructibleTilemap.SetTile(position, null);

            position = destructibleTilemap.WorldToCell(pos8);
            destructibleTilemap.SetTile(position, null);

            //摧毁子弹
            Destroy(other.gameObject);
        }
    }

}
