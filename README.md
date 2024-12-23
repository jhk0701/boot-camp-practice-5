# [스탠다드] 꾸준실습 5

## 작업
Q1 확장 문제 : 
- [직선](./Assets/Scripts/RangedAttacks/LinearAttack.cs)으로 진행하는 공격
- 포물선으로 움직이는 공격
- 원형으로 퍼지는 공격

Q2 확장 문제 : 스킬 만들어보기
- 템플릿 메소드 패턴을 이용하여 SkillObject를 작성한다.
- 이때, 스킬의 구체적인 행위들은 SkillObject 내의 추상 메서드 Act()를 통해서 작동한다.
    스킬들은 SkillObject를 상속받아 Act() 메서드의 구체적인 내용을 구현한다.
- 이제 플레이어는 ScriptableObject로 만들어진 스킬 SO 중 원하는 것을 선택하여
    SkillObject를 생성하고 Act() 메서드만 호출하면 사용할 수 있다.
