using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove_s : MonoBehaviour
{
    public float moveSpeed = 7f; // 이동 속도 변수

    CharacterController cc; // 캐릭터 컨트롤러 변수

    float gravity = -20f; // 중력 변수
    float yVelocity = 0; // 수직 속력 변수

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>(); // 캐릭터 컨트롤러 컴포넌트 받아오기
    }

    // Update is called once per frame
    void Update()
    {
        // 게임 상태 제어
        if (GameManager_s.gm.gs != GameManager_s.GameState.Run)
        {
            return;
        }

        // 사용자 입력 받기
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // 이동 방향 설정
        Vector3 dir = new Vector3(h, 0, v);
        dir = dir.normalized; // 단위 벡터 설정

        // 메인 카메라를 기준으로 방향 변환 (월드좌표 -> 로컬좌표, 기준 트랜스폼 == 메인카메라)
        dir = Camera.main.transform.TransformDirection(dir);

        // 이동 속도에 맞춰 이동하기
        transform.position += dir * moveSpeed * Time.deltaTime;

        // 캐릭터의 수직 속도에 중력 값 적용
        yVelocity += gravity * Time.deltaTime;
        dir.y = yVelocity;

        // 이동 속도에 맞춰 이동하기
        cc.Move(dir * moveSpeed * Time.deltaTime);
    }
}
