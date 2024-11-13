스킬에 필요한 요소 => scriptable object
* 데미지
* 쿨타입
* 스킬 오브젝트


사용 => 전략 패턴 or 템플릿 메서드

- 2개 이상의 스킬
    => Activate() 메서드로 동일한 사용

- 퀵슬롯에 넣어서 사용

Player Attack
    Skill[] => 이 중, 하나를 골라서 쓰는 느낌
        SkillSO
        void Activate()

SkillObject : 템플릿 메서드
-> 실제 행동할 스킬 오브젝트

Skill Power Slash
