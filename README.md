# ⚔ Unity RPG Course
<p align=center><img src = "https://github.com/MinSungJe/Unity2DRPG/assets/101497652/facd6f4c-f5df-4921-8bc1-f4b9a3ef6c16" width="100%" height="70%"></p>

>⛳ Practice for Unity with making 2D RPG Game
>>**🗡 Reference** : [ **The Ultimate Guide to Creating an RPG Game in Unity** 
 ](https://www.udemy.com/course/2d-rpg-alexdev/) by [Alex Dev](https://www.udemy.com/user/alex-13394/)
>> <details>
>><summary><b>🗡 More Information about References</b></summary>
>>
>> 
>>  
>> 
>></details>

## ✍️ NotePad
<details>
<summary><b>🤔 상속이란?</b></summary>

- 부모 class를 바탕으로 자식 class를 만들어내는 기법
- ❗<b>왜 씀? : 코드 관리가 편해지고, 특정 코드의 재사용이 용이함</b>
</details>
<details>
<summary><b>🤔 State가 뭐임?</b></summary>

- GameObject의 상태
- ❗<b>FSM(Finite State Machine) 모델 : GameObject는 모든 시간에 하나의 State만 가지고 있음</b>
- Update()를 가지고 있어 해당 State 중 할 행동을 결정 가능
- 특정 조건이 충족되면 StateMachine의 ChangeState()를 이용해 다른 State로 전환됨
- 들어오는 조건이나 나가는 조건은 State의 Update()에서 정의됨  
(실시간으로 State가 전환돼야하니 당연)
- 들어올때 한번 실행되는 Enter(), 나갈때 한번 실행되는 Exit(), 실시간으로 실행되는 Update()로 구성
- GameObject Script에선 모든 말단 State를 선언해 둠
</details>
<details>
<summary><b>🤔 StateMachine?</b></summary>

- GameObject의 State를 관리하는 역할
- 기능 : Initialize(), ChangeState()
</details>
<details>
<summary><b>🤔 새로운 State를 추가해보자</b></summary>

- ❗<b>다음 step에 맞춰 추가하면 됨</b>
    1. C# script 생성 후 메인 State 상속
    2. generator 생성
    3. Enter(), Exit(), Update() override
    4. 해당 State를 갖는 Gameobject의 Script로 가서 변수와 Awake()를 통해 State 정의
    5. Animator에서 연결(Animation 생성, bool 추가, transition 조건 추가)
</details>
<details>
<summary><b>🤔 Animation이 끝나면 State를 바꾸고 싶어</b></summary>

- 기존 방법 : Animation의 시간이 종료되면 State 바꾸기(stateTimer 이용)
- 문제점 : 모든 Animation의 시간을 측정해야 함 -> 20단 콤보같은거 구현하려면 고생 꽤나할거임
- ❗<b>대체 방법 : Animator에서 Animation 끝부분에 Callback 함수 부르기</b>
    1. 부모 State에서 triggerCalled 정의
    2. 부모 State의 Enter()에서 triggerCalled = false
    3. 종료하고 싶은 State의 Update()에서 triggerCalled가 true일 시 ChangeState
    4. GameObject의 스크립트에 triggerCalled를 true로 바꾸는 함수 추가
    5. <b>Animator는 GameObject의 자식이므로 Animator를 위한 새 스크립트 생성(AnimationTrigger)</b>
    6. Animator의 스크립트에서 부모의 triggerCalled = true 함수 불러오는 함수 생성
    7. Animator의 add Event 기능을 이용해 Animator의 함수를 Animation 끝단에 불러오기

</details>
<details>
<summary><b>🤔 Coroutine이 뭐임?</b></summary>

- 필요에 따라 일시정지 할 수 있는 함수
- StartCoroutine(IEnumerator 반환 함수, 함수에 전달할 인자)로 호출 가능
- IEnumerator 반환 함수 안에 yield를 이용한 WaitForSeconds() 이용
- 참고: IEnumerator란 작업을 분할하여 수행하는 함수라고 생각하면 편하다 (실은 인터페이스)

</details>


## 📢 Recent Update
**⚙ (2024-03-28)**
> **Tile Map Collider**
>- Tile Map Collider 추가
>- Composite Collider 추가
>- 맵 변경


## 🧾 Update History
<details>
<summary><b>⚙ (2024-03-27)</b></summary>

> **Tile Palette**
>- Tile Palette 추가
>- Palette 내부에 Tile Assets 추가

</details>

<details>
<summary><b>⚙ (2024-03-26)</b></summary>

> **Combo Attacks**
>- Primary Attack State 안에 comboCounter, lastTimeAttack, comboWindow 선언
>- Sub Animator를 이용해 comboCounter를 조건으로 Animation 변경
>- 공격 후 시간이 지나면 comboCounter가 0으로 변경됨
>
> **Finalize Attack State**
>- 공격 도중 이동할 수 없도록 하기 위해 stateTimer 설정
>- 콤보 도중 이동할 수 없도록 player에게 isBusy 변수 추가(나중에 많이 활용될 예정)
>- 코루틴 함수인 BusyFor 추가
>- 공격이 player의 Velocity를 약간 변경시킴
>
> **Attack's direction**
>- 공격 중간에 공격방향 변경 가능(AttackDir 이용)

</details>

<details>
<summary><b>⚙ (2024-03-25)</b></summary>

> **Primary Attack State**
>- Primary Attack State 추가
>- Attack 1~3 Animation 생성
>   - Enter : GroundedState에서 좌클릭
>   - Exit : Animator의 add Event 기능 이용, triggerCalled = true
>- Animator의 add Event 기능을 이용한 State 변경 구현

</details>

<details>
<summary><b>⚙ (2024-03-24)</b></summary>

> **Wall Slide State**
>- Wall Slide State 추가
>- WallSlide Animation 생성
>- Wall을 감지하는 IsWallDetected() 추가
>   - Enter : AirState에서 IsWallDetected()
>   - Exit : 반대 방향 키를 누름 -> IdleState  
>   혹은 IsGroundDetected() -> IdleState
>- 여러 버그 수정
>
> **Wall Jump State**
>- Wall Jump State 추가
>   - Enter : WallSlide State에서 Space키 입력
>   - Exit : stateTimer 이용, 0.4초 이후 -> AirState  
>   혹은 IsGroundDetected() -> IdleState
>- stateTimer를 이용해 Wall Jump에 머무르는 시간 설정
>- 여러 버그 수정

</details>

<details>
<summary><b>⚙ (2024-03-23)</b></summary>

> **Creating Dash State**
>- Dash State 추가
>- stateTimer를 이용해 Dash State에 머무르는 시간 설정
>- PlayerGroundedState에서 Shift 입력 받음
>
> **Improving Dash State**
>- PlyaerGroundedState -> Player 스크립트로 Shift 입력부 변경
>- 이를 통해 모든 상황에서 Dash 가능
>- facingDir이 아닌 DashDir로 대쉬 방향 변경
>- DashCooldown 추가
</details>

<details>
<summary><b>⚙ (2024-03-21)</b></summary>

> **Collision Check**
>- Gizmos, Physics2D.Raycast를 이용해 Ground(LayerMask) 충돌 체크
>- Player 내에 isGroundDetected() 추가
>- GroundedState <-> AirState 간 전환 조건 변경
>
> **Flip**
>- Rotation(0, 180, 0)을 이용해 Player 좌우반전
>- Player 내에 Flip(), FlipController() 추가
</details>


<details>
<summary><b>⚙ (2024-03-20)</b></summary>

> **Movement with State Machine**
>- IdleState <-> MoveState 간 change조건 변경
>- MoveState의 Update에서 실제 캐릭터 이동
>
> **Jump with State Machine**
>- SuperState인 GroundedState 추가
>- GroundedState에 Jump입력 추가
>- 상속 현황 : State > GroundedState > IdleState, JumpState
>- ❗ Player의 State 선언부에 맨 마지막 자식 State들을 선언한다
</details>

<details>
<summary><b>⚙ (2024-03-19)</b></summary>

> **Setup Animator with State Machine**
>- State Machine과 Animator 연결
</details>

<details>
<summary><b>⚙ (2024-03-17)</b></summary>

> # ✏ Start Course
> **Creating Finite State Machine**
>- State Machine 기본 구조 생성
</details>
