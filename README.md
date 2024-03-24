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
- ❗<b>GameObject는 모든 시간에 하나의 State만 가지고 있음</b>
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


## 📢 Recent Update
**⚙ (2024-03-24)**
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


## 🧾 Update History
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
