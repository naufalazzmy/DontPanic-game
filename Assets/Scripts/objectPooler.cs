using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectPooler : MonoBehaviour
{

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    #region Singleton
    public static objectPooler Instance;
    private void Awake() {
        Instance = this;
    }
    #endregion

    public List<Pool> pools;
    public Dictionary<string, Queue<GameObject>> poolDict;

    private void Start() {
        poolDict = new Dictionary<string, Queue<GameObject>>();

        foreach(Pool pool in pools) {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for(int i=0; i<pool.size; i++) {
                GameObject obj = Instantiate(pool.prefab);

                // change color sprite
                int z = Random.RandomRange(0, 5);
                if(z == 0) {
                    obj.GetComponent<SpriteRenderer>().color = new Color(0.42f, 1, 0.38f);  // green
                }else if(z == 1) {
                    obj.GetComponent<SpriteRenderer>().color = new Color(0.92f, 0.49f, 0.991f); // purple
                } else if (z == 2) {
                    obj.GetComponent<SpriteRenderer>().color = new Color(0.58f, 0.62f, 1); // blue
                } else if (z == 3) {
                    obj.GetComponent<SpriteRenderer>().color = new Color(1, 0.97f, 0.47f); // yellow
                } else {
                    obj.GetComponent<SpriteRenderer>().color = Color.white; 
                }
                z = 0;

                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDict.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation) {

        if (!poolDict.ContainsKey(tag)) {
            Debug.LogWarning("Pool dengan tag " + tag + " tidak ada");
            return null;
        }

        GameObject objectToSpawn = poolDict[tag].Dequeue();

        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        IPooledObject pooledObj = objectToSpawn.GetComponent<IPooledObject>();
        if(pooledObj != null) {
            pooledObj.OnObjectSpawn();
        }

        poolDict[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
