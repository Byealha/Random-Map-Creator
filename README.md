:pushpin: <b>게임 정보</b><br>
&nbsp;&nbsp;- 프로젝트 완성 일자: -<br>
&nbsp;&nbsp;- 장르: -<br>
&nbsp;&nbsp;- 플랫폼: PC<br>
&nbsp;&nbsp;- 개발 인원: 이준호 (1인 개발)<br><br>


:pushpin: <b>플레이 영상</b><br>
&nbsp;&nbsp;- -<br><br>


:pushpin: <b>기술 스택</b><br>
&nbsp;&nbsp;- Unity 6.3.4f1<br>
&nbsp;&nbsp;- Unity 2D<br>
&nbsp;&nbsp;- C#<br><br>


:pushpin: <b>주요 기술 구현</b><br>

● Coroutine<br>
&nbsp;&nbsp;- 로딩 / 페이드 / 연출 흐름을 시간 기반으로 제어<br><br>

● HashSet 기반 맵 중복 생성 방지<br>
&nbsp;&nbsp;- Vector2Int 좌표를 HashSet으로 관리하여 이미 생성된 위치에는 맵이 생성되지 않도록 설계<br><br>

● UnityEditor Auto Assign 기능<br>
&nbsp;&nbsp;- 인스펙터에서 버튼 한 번으로 필요한 컴포넌트를 자동으로 할당하는 기능 구현<br><br>

● event Action<br>
&nbsp;&nbsp;- 객체 간 직접 참조를 줄이고 이벤트 기반으로 통신하여 결합도를 낮추는 구조 설계<br><br>


:pushpin: <b>아키텍처 설계 핵심</b><br>

&nbsp;&nbsp;맵 생성 시 위치를 Vector2Int로 관리하고, 해당 좌표를 HashSet에 저장하여<br>
&nbsp;&nbsp;이미 생성된 위치에는 다시 생성되지 않도록 설계했습니다.<br><br>

&nbsp;&nbsp;예를 들어 (0,0) → (1,0) → (1,1) → (0,1) 순으로 맵이 생성된 이후<br>
&nbsp;&nbsp;다시 (0,0)으로 돌아오는 경우, HashSet을 통해 해당 위치가 이미 존재함을 확인하고<br>
&nbsp;&nbsp;다른 방향을 다시 탐색하도록 처리했습니다.<br><br>

&nbsp;&nbsp;이를 통해 기존에 Destroy로 해결하던 중복 생성 문제를<br>
&nbsp;&nbsp;데이터 기반으로 해결하도록 구조를 개선했습니다.<br><br>


:pushpin: <b>문제 해결 및 개선 과정</b><br>

● 기존 방식의 문제점<br>
&nbsp;&nbsp;- 맵이 겹치는 문제를 Destroy로 제거하는 방식으로 처리<br>
&nbsp;&nbsp;- 반복적인 Instantiate / Destroy 호출로 비효율적인 구조 발생<br><br>

● 개선 방식<br>
&nbsp;&nbsp;- HashSet을 활용하여 "생성 자체를 막는 구조"로 변경<br>
&nbsp;&nbsp;- 맵을 삭제하지 않고 재사용하는 방식으로 구조 개선<br><br>

● 결과<br>
&nbsp;&nbsp;- 불필요한 Destroy 호출 감소<br>
&nbsp;&nbsp;- 맵 생성 로직이 예측 가능하고 안정적인 구조로 개선<br><br>


:pushpin: <b>객체지향 설계 (SOLID 적용)</b><br>

&nbsp;&nbsp;해당 프로젝트를 진행하며 객체지향 5원칙(SOLID)을 인지하고,<br>
&nbsp;&nbsp;단순 구현을 넘어서 구조적인 설계를 적용하려고 시도했습니다.<br><br>

● SRP (단일 책임 원칙)<br>
&nbsp;&nbsp;- 맵 생성, 위치 관리, 연출 처리 등의 책임을 분리하여 각 스크립트가 하나의 역할만 담당하도록 설계<br><br>

● OCP (개방-폐쇄 원칙)<br>
&nbsp;&nbsp;- 맵 생성 방식 변경 시 기존 코드를 수정하기보다 확장 가능한 구조를 고려하여 설계<br><br>

● DIP (의존성 역전 원칙)<br>
&nbsp;&nbsp;- event Action을 활용하여 객체 간 직접 의존을 줄이고, 이벤트 기반으로 상호작용하도록 구성<br><br>

&nbsp;&nbsp;이를 통해 클래스 간 결합도를 낮추고, 유지보수와 확장성을 고려한 구조를 경험했습니다.<br><br>


:pushpin: <b>프로젝트를 통해 성장한 점</b><br>

● 오브젝트 풀링 개념 적용<br>
&nbsp;&nbsp;- Instantiate / Destroy 반복 대신, 필요한 오브젝트를 재사용하는 구조로 개선<br><br>

● UnityEditor 활용 능력 향상<br>
&nbsp;&nbsp;- 반복적인 수동 세팅을 줄이기 위한 자동화 기능 구현 경험<br><br>

● 데이터 기반 문제 해결 방식 이해<br>
&nbsp;&nbsp;- 좌표 데이터를 기준으로 문제를 해결하는 방식(HashSet 활용)을 경험<br><br>

● 구조적인 설계에 대한 인식 변화<br>
&nbsp;&nbsp;- 단순 기능 구현에서 벗어나, 유지보수와 확장을 고려한 설계를 고민하게 된 계기<br>
