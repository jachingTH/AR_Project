# AR_Project
증강현실 프로그래밍 AR 게임 제작

핸드폰으로 주변 환경 인식 후 포탈 생성하여 게임 플레이

6/9 5:36
- 포탈 생성 후 레벨 보이기
  Main Camera & Level Camera 생성
  Level Camera = John Lemon 캐럭터를 따라다니는 카메라
  Main Camera = XR Origin 내에 있는 카메라
  John Lemon Level에 Level이라는 Layer를 추가함
  Main Camera의 Culling Mask에 Level을 없앰 => Main Camera가 더이상 Level 레이어를 가지고 있는 요소들을 렌더링 하지 않음
  Render Texture를 생성 -> Level Camera로 선택 => Level Camera가 렌더링 하는 영상이 Render Texture에 재생됨 + Material로 생성 + Plane에 Material 할당
