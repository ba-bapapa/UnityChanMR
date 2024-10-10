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

    //�v���t�@�u�쐬
    private void Create_Prefab(int CameraDistance, string PrefabCloneName)
    {
        //�J�����̐��ʂ���3���[�g����擾
        Vector3 MainCamera_Forward = MainCamera.transform.position + MainCamera.transform.forward * CameraDistance;
        DeletePrefab = GameObject.Find(PrefabCloneName);

        //�v���t�@�u�����݂��邩
        if (DeletePrefab)
        {
            Destroy(DeletePrefab);//�폜
        }

        //Unity�����쐬
        if(CameraDistance == 3)
        {
            MainCamera_Forward.y = 0; //������0��
            Instantiate(MagicSquare_Particle, MainCamera_Forward, Quaternion.Euler(0, 0, 0));
            audioSource.PlayOneShot(SummonsAudio);
            DeletePrefab = Instantiate(UnityTyanPrefab, MainCamera_Forward, Quaternion.identity);
        }
        //���쐬
        else if(CameraDistance == 1)
        {
            //�v���n�u���w��ʒu�ɐ���
            DeletePrefab = Instantiate(SwordPrefab, MainCamera_Forward, Quaternion.identity);
        }

        //�����ύX
        Vector3 targetPos = MainCamera.transform.position;
        targetPos.y = DeletePrefab.transform.position.y;
        DeletePrefab.transform.LookAt(targetPos);
    }
}