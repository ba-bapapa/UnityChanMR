using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateChar : MonoBehaviour
{
    public GameObject UnityTyanPrefab;
    public GameObject MagicSquare_Particle;
    public GameObject SwordPrefab;
    public AudioClip SummonsAudio;

    private GameObject MainCamera;
    private GameObject DeletePrefab;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        MainCamera = GameObject.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CreatePrefabCall(int PrefabNumber)
    {
        if(PrefabNumber == 0)
        {
            Create_Prefab(1, "LongSword(Clone)");
        }
        else if(PrefabNumber == 1)
        {
            Create_Prefab(3, "unitychan(Clone)");
        }
    }

    //プレファブ作成
    private void Create_Prefab(int CameraDistance, string PrefabCloneName)
    {
        //カメラの正面から3メートル先取得
        Vector3 MainCamera_Forward = MainCamera.transform.position + MainCamera.transform.forward * CameraDistance;
        DeletePrefab = GameObject.Find(PrefabCloneName);

        //プレファブが存在するか
        if (DeletePrefab)
        {
            Destroy(DeletePrefab);//削除
        }

        //Unityちゃん作成
        if(CameraDistance == 3)
        {
            MainCamera_Forward.y = 0; //高さを0に
            Instantiate(MagicSquare_Particle, MainCamera_Forward, Quaternion.Euler(0, 0, 0));
            audioSource.PlayOneShot(SummonsAudio);
            DeletePrefab = Instantiate(UnityTyanPrefab, MainCamera_Forward, Quaternion.identity);
        }
        //剣作成
        else if(CameraDistance == 1)
        {
            //プレハブを指定位置に生成
            DeletePrefab = Instantiate(SwordPrefab, MainCamera_Forward, Quaternion.identity);
        }

        //向き変更
        Vector3 targetPos = MainCamera.transform.position;
        targetPos.y = DeletePrefab.transform.position.y;
        DeletePrefab.transform.LookAt(targetPos);
    }
}