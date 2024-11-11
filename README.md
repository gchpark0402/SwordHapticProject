# SwordHapticProject
옵티트랙과 오큘러스를 사용하여 사용자의 움직임을 추적하고, 가상 현실에서의 충돌과 관련한 현실세계에서의 피드백을 전달하는 장치를 사용하여 사용자에게 반발력을 제공하는 프로젝트입니다.
   

---
## 구조


### Software
1. SerialPortScript를 통해 컴퓨터와 연결한 아두이노 serial port 통신/인식, singleton 패턴을 사용해 인스턴스 생성, 유지
   * Optitrack :　Optitrack 회사에서 제공하는 Unity integration과 Optitrack software(Motive)와 연결
      * 사용자에게 Optitrack 장비(광학 반사 마커)를 장착시켜 움직임을 tracking
   * Oculus : xr interaction toolkit을 사용해 oculus 연결
      * Oculus 컨트롤러와 제작한 hardware를 연결
2. 현실감을 위해 게임에서 플레이어가 들고 있는 칼과 현실 hardware간의 길이 조절
3. SwordScript를 통해 게임 내의 칼이 오브젝트와 충돌 중이라면 SerialPortScript 신호 함수 호출 & 칼이 오브젝트와 충돌이 끝났다면 SerialPortScript 정지신호 함수 호출
4. SerialPortScript에서 신호와 정지 신호를 호출시 아두이노에게 각각 다른 char를 전달하여 신호 시작과 정지를 구별
5. 아두이노를 통해 신호에 따라 솔레노이드 가동/ 정지
     * 칼이 오브젝트와 충돌하였다면 솔레노이드를 가동하여 칼을 고정시키고 반발력을 제공함 & 오브젝트와의 충돌이 끝났다면 솔레노이드 가동을 중지하여 다시 칼이 자유롭게 움직이게 함

cf. Optitrack을 사용할 때에는 Optitrack software(motive)와 연결한 컴퓨터와 아두이노와 연결한 컴퓨터가 달랐기 때문에 photon server를 사용하여 연결하였습니다.

https://github.com/gchpark0402/Photon_Arduino

### Hardware

* 장비 착용시 Optitrack marker나 Oculus를 착용하여 사용자의 움직임을 tracking
* 칼의 움직임을 tracking 장비를 통해 가상 현실에 전달하고 칼이 물체와 닿았다면 아두이노를 통해 신호를 받고, 솔레노이드를 가동
* 평소에는 줄자처럼 자유롭게 움직였지만 솔레노이드가 가동하면 물레바퀴에 제동이 걸려 칼이 움직이지 못함
* 솔레노이드가 작동함과 동시에 물레바퀴에 제동이 걸려 실이 팽팽해지고 사용자에게 반발력을 제공하여 마치 물체와 부딪힌 것과 같은 느낌을 제공함

  
![hardware구조](https://github.com/user-attachments/assets/8dcbe207-9d5f-46a9-a0c7-7d74c2931b71)
