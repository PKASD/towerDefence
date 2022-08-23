using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    public GameObject towerpref;
    public GameObject parentpref;

    public void SpawnTower(GameObject towerpref,Vector3 trans)
    {
            GameObject TowerObj = Instantiate(towerpref, trans, Quaternion.identity);
            TowerObj.transform.SetParent(parentpref.transform, true);//�θ� ������Ʈ�� ���� ������Ʈ�� ����
    }
    public void DelTower(Vector3 trans)
    {
        Destroy(this.gameObject);
    }
}
/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    public GameObject towerpref;
    public GameObject parentpref;

    public void SpawnTower(GameObject towerpref, Vector3 trans)
    {
        GameObject TowerObj = Instantiate(towerpref, trans, Quaternion.identity);
        TowerObj.transform.SetParent(parentpref.transform, true);//�θ� ������Ʈ�� ���� ������Ʈ�� ����
    }
    public void DelTower(Vector3 trans)
    {
        Destroy(this.gameObject);
    }
}
*/