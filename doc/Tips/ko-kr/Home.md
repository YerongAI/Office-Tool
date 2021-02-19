## 안녕하세요. Office Tool Plus를 사용해주셔서 감사합니다

---

Office Tool Plus는 기능 많고 실용적인 Office 배포 도구입니다.

Office Tool Plus는 [Office 배포 툴](https://aka.ms/ODT)과 [OSPP](https://docs.microsoft.com/en-us/DeployOffice/vlactivation/tools-to-manage-volume-activation-of-office)를 기반으로 개발됩니다. 더 편리한 Office 배포 기능을 제공하고 내장된 Thunder 언진으로 더 빠른 다운로드할 수 있습니다. 그리고 다양한 내장된 툴과 단축키로 손쉽게 Office 정품인정과 관리도 할 수 있습니다.

[공식 블로그](https://www.coolhub.top/)

[비디오 매뉴얼](https://space.bilibili.com/23627347)

[QQ 구룹](https://otp.landian.vip/zh-cn/#about)

[위챗 공식 계정(위챗 구룹에 가입 가능)](https://otp.landian.vip/grouplink/wechat.html)

### Office Tool Plus 단축키

---

- <kbd>Esc</kbd>: 홈으로 돌아가기
- <kbd>F1</kbd>: 도움말 표시
- <kbd>F5</kbd>: 새로고침/환경설정 초기화
- <kbd>Ctrl + 1</kbd>: 배포 페이지 가기
- <kbd>Ctrl + 2</kbd>: 정품인정 페이지 가기
- <kbd>Ctrl + 3</kbd>: 툴 박스 페이지 가기
- <kbd>Ctrl + N</kbd>: 알림 페이지 표시
- <kbd>Ctrl + T</kbd>: 설정 페이지 표시
- <kbd>Ctrl + B</kbd>: 소개 페이지 표시
- <kbd>Ctrl + P</kbd>: 명령창 표시/숨기

Tip: 마우스 이전/이후 버튼으로 페이지 전환할 수 있습니다.

### Office Tool Plus 명령 (Ctrl + P로 호출)

---

명령으로 원하는 작업을 완성할 수 있고 배치 설정도 할 수 있습니다. `대소문자 구분하지 않고 명령이 입력 순서대로 실행됩니다.` 경로중에서 공백이 있으면 경로를 ""안으로 넣고 실행하세요.

**/setImage [Path]** 수동으로 백경 이미지 지정, Path: 백경 이미지 경로(JPG/PNG 형식만 지원, 로컬경로와 HTTP경로 지원)

**/clImage** 현재 백경 이미지 치우기

**/addProduct [ProductIDs]** 하나 이상의 제품을 추가, ProductID: 제품 ID, 예: O365ProPlusRetail,O365ProPlusRetail,VisioProRetail 등

**/addLang [LanguageIDs]** 하나 이상의 언어 패키지를 추가, LanguageID: 언어 패키지 ID, 예: zh-cn이나 zh-cn,en-us 등, ja-jp_proof를 사용해서 ja-jp 언어 교정 도구(전체 언어 패키지 아님)를 추가하기

**/setApps [AppID]** `설치할` 응용프로그램을 설정, 영문 콤마로 각각 응용프로그램을 분리하세요. 예: Word,Excel,PowerPoint, 미 설정된 응용프로그램을 설치하지 않을겁니다

**/setExApps [AppID]** `설치하지 않는` 응용프로그램을 설정, 사용 방법은 /setApps와 동일합니다

**/deployArch [index]** 시스템 구조를 설정, 0은 32비트, 1은 64비트

**/deployChl [index]** 채널을 설정, 0은 리스트중의 1번, 예: 0은 Office 2019 엔터프라이즈 장기 채널, 3은 현재 채널

**/deployMode [index]** 배포 모드를 설정, 0은 리스트중의 1번, 예: 0은 다운로다하는 동시에 설치 진행하기, 5은 환경설정만 설정하기

**/deployModule [index]** 설치 모듈을 설정, 0은 Office 배포 툴, 1은 Office Tool Plus

**/setSources [Path]** Office 설치할 때 Office 설치 파일을 가져올 경로를 설정, 미 설정되면 Office CDN를 사용하고 다운로드 모든에서는 이 옵션은 Office 설치 파일을 저장할 경로로 사용됩니다

**/setVersion [Version]** Office 다운로드/설치할 때 사용할 Office 버전을 설정, 예: 16.0.12527.2027

**/refresh** 배포 페이지의 모든 데이터 새로고침

**/loadChannels** 배포 페이지에서 추가적인 채널을 로드

**/loadXML [Path]** 하나의 XML 파일을 로드, 로컬과 HTTP 경로를 지원

**/startDeploy** 배포 시작

**/installiSlide** Install iSlide.

**/getKey [ProductID]** Get the product key, return GVLK for volume products, normal key for other products. Example product id: ProPlus2019Volume

**/osppILByID [ProductID]** 지정된 제풍의 Office 라이선스를 설치, ProductID: 제품 ID, 예: MondoVolume

**/osppinpkey:[value]** 지정된 Office 키를 설정, 예: /osppinpkey: XXXXX-XXXXX-XXXXX-XXXXX-XXXXX

**/osppunpkey:[value]** 지정된 Office 키를 제거, 예: /osppunpkey: XXXXX

**/osppsethst:[value]** KMS 호스트 주소 설정, 예: /osppsethst:kms.example.com

**/osppsetprt:[value]** KMS 호스트 포트 설정, 예: /osppsetprt:1688

**/osppact** Office 클라이언트 제품 정품인정하기

기타 OSPP 마라미터 사용 방법이 비슷하며 명령어 앞에 ospp 문자를 넣으면 될겁니다. OSPP 매뉴얼이 참조하려면 [마이크로소프트 공식 매뉴얼](https://docs.microsoft.com/ko-kr/deployoffice/vlactivation/tools-to-manage-volume-activation-of-office)에서 확인하세요.
