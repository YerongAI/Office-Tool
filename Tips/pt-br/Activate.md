# Sobre a Ativação

```txt
Se houver falhas ao ativar o Office com esta ferramenta, verifique a sua operação em primeiro lugar (veja as instruções abaixo).
Se o problema ainda existir, por favor, tente verificar o seu sistema operacional. Após a ativação bem-sucedida, tudo estará pronto.
```

## Conteúdo

---

1. Instalar/Alterar a Licença
2. Ativar a licença (ativar o Office)
3. Verificar o servidor KMS
4. Obter Status da Ativação
5. Limpar Ativação
6. Chaves de Licença de Volume genérico (GVLKs)

## Instalar Licença

---

Uma vez que uma licença é instalada, ela pode ser ativada com a chave correspondente.
Por exemplo: Se você quiser o seu Office 2016 Retail -> Office 2016 Volume, simplesmente instale a licença do Office 2016 Volume.
Após a instalação, a licença antiga não será substituída. Assim, podemos ter várias licenças para um software.

Se você quiser instalar seus arquivos de licença local, clique no botão [...].

`Nota: Se a versão baseada em C2R do Office estiver instalada no computador, o OTP tentará ler todas as licenças disponíveis e exibí-las na caixa suspensa.
Caso contrário, somente as licenças do tipo Volume internas serão exibidas.`

## Ativar Licença

---

### Ativação Online

`Certifique-se de que sua chave é válida e a versão está correta antes da ativação.`
Insira a chave, clique no botão [Instalar Chave] e clique em [Ativar]. O Office será ativado com êxito. Isso também pode ser feito no Office.
Após a ativação bem-sucedida, o Office permanecerá ativo.

### Ativação por telefone

`Certifique-se de que sua chave pode ser usada para a ativação por telefone e instale a chave.` No submenu do botão [Instalar Chave], clique em "Ver ID de Instalação".
Após obter o ID de confirmação, insira-o no campo apropriado e clique no submenu "Instalar o ID de confirmação".
Após a ativação bem-sucedida, o Office permanecerá ativo.

### Ativação KMS

Certifique-se de que possui versões licenciadas por volume do Office instaladas. Se você não souber se é uma versão volume, por favor, instale as licenças por volume correspondentes. Por exemplo, se pretende ativar o Office 2016, instale a licença por volume do Office 2016. Em seguida, você precisa inserir um endereço válido do servidor KMS. Não se esqueça de pressionar o botão [Definir endereço do servidor] '. Quando tudo estiver configurado corretamente (rede e servidor KMS), clique no botão [Ativar]. Ativado com sucesso? Aproveite!

## Verificar o Servidor KMS

---

Insira o endereço do servidor KMS e clique no submenu "Verificar o estado do KMS".

Geralmente, os seguintes resultados poderão ser obtidos:
Conectando à 192.168.123.1:1688 ... Bem-sucedido
Enviando solicitação de ativação (KMS V4) 1 de 1  -> 03612-00206-524-247319-03-1100-14393.0000-2802018

"Bem-sucedido" significa que você pode se conectar ao servidor. "Enviando solicitação de ativação" significa que o servidor está funcionando.

Resultados diferentes podem indicar um problema com o servidor KMS ou na rede.

## Obter Status da Ativação

---

Clique no botão [Informações da Ativação] para consultar as informações de licença para as chaves instaladas.

`Nota: O Office estará ativado somente quando o status da licença for  ---LICENSED---`

## Limpar Ativação

---

Clique no botão [Informações da Ativação] para consultar as informações de licença para as chaves instaladas.

Copie os últimos 5 caracteres da chave do produto instalado da licença desnecessária, cole-a na caixa Gerenciar Chaves e, em seguida, clique no submenu "Desinstalar Chave".

![Uninstall Office Product Key](https://server.coolhub.top/OfficeTool/images/en-us/UninstallKey.png)

### Limpar Status de Ativação (Todas)

No submenu Gerenciar Licenças você pode limpar as licenças.
Após limpar todas as licenças, você precisará reparar o Office na primeira vez que abrir um aplicativo do Office (o Office irá redefinir as licenças como padrão) ou você pode instalar a licença manualmente. Após isso você pode ativar o Office novamente.

No submenu Gerenciar Chaves você pode desinstalar todas as chaves.
Após desinstalar todas as chaves, todas as ativações serão limpas e você precisará reativar o Office.

O submenu "Limpar Ativação" executa todas as operações acima.

## Chaves de Licença de Volume genérico (GVLKs)

---

Certifique-se de que você tenha versões instaladas licenciadas por volume do Office antes de usar GVLKs.
Se você não souber se é uma versão de volume, instale as licenças de volume correspondentes antes de usar GVLKs.
Ativar o Office via KMS requer um endereço de servidor KMS, caso contrário, o Office não pode ser ativado.

Para mais informações, por favor, visite [GVLKs para o KMS e para a ativação baseada no Active Directory do Office 2019 e 2016](https://docs.microsoft.com/pt-br/DeployOffice/vlactivation/gvlks)

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

### Chave Office 365 Pro Plus Retail Grace Key

DRNV7-VGMM2-B3G9T-4BF84-VMFTK

Se você não sabe o que é, por favor, não use. Esta chave não pode ser usada para ativar o Office.
