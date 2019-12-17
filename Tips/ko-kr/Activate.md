# 정품인정

```txt
이 툴으로 정품인정 실패하면 조작(아래와 같은 조작 가이드)을 확인하세요.
문제가 계속 나오면 운영체제를 확인하세요.
성공적으로 정품인정 완료되면 바로 시작할 수 있습니다.
```

## 내용

---

1. 라이선스 설치/전환
2. 라이선스 정품인정(Office 정품인정)
3. KMS 서버 확인
4. 정품인정 상태 조회
5. Office 정품인정 관리
6. 볼륨 라이선스 키 생성(GVLKs)

## 라이선스 설치

---

라이선스를 설치하면 해당하는 키로 정품인정할 수 있습니다.
예를들어: Office 2016 Retail를 Office 2016 Volume로 전환하면 그냥 Office 2016 Volume키를 설치하면 바로 됩니다.
설치완료된 후 이전의 키가 겹쳐쓰기 되지 않아서 한 소프트웨어에서 다 라인선스를 보존할 수 있습니다.

로컬 라이선스 파일을 설치하려면 [...]버튼을 클릭하세요.

`주의: C2R기반 버전의 Office일 경우 Office Tool Plus가 모든 유효한 라이선스를 읽어서 표시합니다. 아니면 붙박이 키만 표시합니다.`

## 라이선스 정품인정

---

`주의: Office 365 정품인정하는 방법은 Office 365 계정을 등록할 수 밖에 없습니다.`

### 온라인 정품인정

`정품인정하기 전에 키의 유효성과 버전의 정확성을 확인하세요.`
키를 입력해서 [키 설치]와 [정품인정] 키를 순서대로 클릭하면 Office가 성공적으로 정품인정될겁니다. 이 조치도 Office에서 진행할 수 있습니다. 정품인정되면 Office가 정품인정 성공 상태로 유지합니다.

### 전화 정품인정

`사용하는 키가 전화 정품인정 지원되는지 확인 후` 키를 설치하세요. [키 설치]의 서브메뉴 [설치 아이디 보기]를 클릭하세요. 확인 아이디를 하고 인력(블랙 제외)한 후 서브메뉴 [확인 아이디 설치]를 클릭하세요.
정품인정되면 Office가 정품인정 성공 상태로 유지합니다.

### KMS 정품인정

볼륨 버전의 Office를 설치되는지 먼저 확인하세요. 볼륨 버전 일지 모르면 해당하는 키를 설치하세요. 예를들어: Office 2016를 정품인정하려면 바로 Office 2016 Volume 라이선스를 설치하세요. 그 다음에 유효한 KMS 서버 주소를 입력해야합니다. `[서버 주소 설정] 버튼 꼭 클릭해야합니다.` 환경 설정이 제대로 완성하고 네트워크와 KMS 서버가 정성 작동하면 [정품인정]버튼을 누르면 될 겁니다. 성공했어요? 바로 즐겨보세요.

어떻게 KMS 서버 주소를 구할 수 있냐고요? ㅋㅋ...글쎄...구글에서 검색해보세요.

## KMS 서버 확인

---

KMS 서버 주서를 입력해서 서브메뉴 [KMS 상태 조회]를 클릭하세요.

보통은 아래와 같은 반환값(명력어를 통역하지 않음)을 표시될 겁니다.
Connecting to 192.168.123.1:1688 ... successful
Sending activation request (KMS V4) 1 of 1  -> 03612-00206-524-247319-03-1100-14393.0000-2802018

[성공]은 서버에 접속 가능한 의미입니다.
[정품인정 요청 보내 중]은 서버가 자동하는 중의 의미입니다.

외의 메시지를 나타나지 않으면 KMS서버나 네트워크를 확인 해야합니다.

## 정품인정 상태 조회

---

[정품인정 정보 표시]버튼을 누르고 설치된 키의 라이선스 정보를 저회합니다.

`주의: 라이선스 상태는 ---LICENSED--- 있어야 정품인정이 성공으로 판단할 수 있습니다.`

## Office 정품인정 관리

---

### Office 제품 키 제거

[정품인정 정보 표시]버튼을 누르고 설치된 키의 라이선스 정보를 저회합니다.

제거하려는 제품 키의 마지막 5자리의 문자를 복사하고 키 관리 입력 박스에서 붙여넣어서 서브메뉴 [키 제거]를 클릭하세요.

![Office 제품 키 제거(중국어 캡쳐)](https://server.coolhub.top/OfficeTool/images/en-us/UninstallKey.png)

### 모든 Office 제품 키 제거

키 관리의 서브메뉴에서 모든 키를 제거할 수 있습니다.
모든 키를 제거하면 정품인정 정보도 같이 없애져서 다시 정품인정을 진행해야합니다.

### 모든 Office 라이선스 지우기

라이선스 관리의 서브메뉴에서 라이선스를 지울수 있습니다.
모든 라이선스를 지우면 Office 앱을 첫번째 시작할 때 Office복원해야합니다.(Office가 기본 라이선스로 초기화합니다.)
사용자가 수동적으로 라이선스를 설치할 수 있습니다. 설치 후 다시 정품인정을 진행해야합니다.

**서브메뉴 [정품인정 지우기]는 외의 모든 조작을 실행한다는 의미입니다.**

## 볼륨 라이선스 키 생성

---

GVLKs를 사용 전에 볼륨 라이선스 버전의 Office를 설치되는지 먼저 확인하세요.
볼륨 버전 일지 모르면 GVLKs를 사용 전에 해당하는 볼륨 라이선스를 설치하세요.
KMS로 정품인정하려면 KMS 서버 주소가 필요해야합니다. 없으면 정품인정할 수 없습니다.

참고로 추가정보를 읽어보세요. [Office 2019 alc Office 2016의 KMS 및 Active Directory 기반 정품 인증을 위한 GVLK](https://docs.microsoft.com/ko-kr/DeployOffice/vlactivation/gvlks)

```txt
Office 2019 GVLKs

Office Pro Plus 2019	NMMKJ-6RK4F-KMJVX-8D9MJ-6MWKP
Office Standard 2019	6NWWJ-YQWMR-QKGCB-6TMB3-9D9HK
Project Pro 2019		B4NPR-3FKK7-T2MBV-FRQ4W-PKD2B
Project Std 2019		C4F7P-NCP8C-6CQPT-MQHV9-JXD2M
Visio Pro 2019		9BGNQ-K37YR-RQHF2-38RQ3-7VCBB
Visio Std 2019		7TQNQ-K3YQQ-3PFH7-CCPPM-X4VQ2
Access 2019		9N9PT-27V4Y-VJ2PD-YXFMF-YTFQT
Excel 2019		TMJWT-YYNMB-3BKTF-644FC-RVXBD
Outlook 2019		7HD7K-N4PVK-BHBCQ-YWQRW-XW4VK
PowerPoint 2019		RRNCX-C64HY-W2MM7-MCH9G-TJHMQ
Publisher 2019		G2KWX-3NW6P-PY93R-JXK2T-C9Y9V
Skype for Business	NCJ33-JHBBY-HTK98-MYCV8-HMKHJ
Word 2019		PBX3G-NWMT6-Q7XBW-PYJGG-WXD33

Office 2016 GVLKs

Office Pro Plus 2016	XQNVK-8JYDB-WJ9W3-YJ8YR-WFG99
Office Standard 2016	JNRGM-WHDWX-FJJG3-K47QV-DRTFM
Office Mondo 2016	HFTND-W9MK4-8B7MJ-B6C4G-XQBR2
Project Pro 2016		WGT24-HCNMF-FQ7XH-6M8K7-DRTW9
Project Std 2016		D8NRQ-JTYM3-7J2DX-646CT-6836M
Visio Pro 2016		69WXN-MBYV6-22PQG-3WGHK-RM6XC
Visio Std 2016		NY48V-PPYYH-3F4PX-XJRKJ-W4423
Access 2016		GNH9Y-D2J4T-FJHGG-QRVH7-QPFDW
Excel 2016		9C2PK-NWTVB-JMPW8-BFT28-7FTBF
OneNote 2016		DR92N-9HTF2-97XKM-XW2WJ-XW3J6
Outlook 2016		R69KK-NTPKF-7M3Q4-QYBHW-6MT9B
PowerPoint 2016		J7MQP-HNJ4Y-WJ7YM-PFYGF-BY6C6
Publisher 2016		F47MM-N3XJP-TQXJ9-BP99D-8K837
Skype for Business	869NQ-FJ69K-466HW-QYCP2-DDBV6
Word 2016		WXY84-JN2Q9-RBCCQ-3Q3J3-3PFJ6
```

### Office 365 Pro Plus Retail Grace 키

DRNV7-VGMM2-B3G9T-4BF84-VMFTK

그 걸 모르면 쓰지 마세요. 그 걸로 Office 정품인정할 수 없습니다.
