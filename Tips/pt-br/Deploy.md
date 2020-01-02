# Sobre a implantação

Aqui você pode gerenciar os produtos do Office e os pacotes de idiomas instalados no momento. Se você não tem o Office instalado, poderá fazer uma nova instalação.

Você pode consultar o número da versão e a data de lançamento em cada canal no submenu Verificar Versão. Depois disso, você pode especificar a versão no momento do download ou da instalação. Se não for especificado, a versão mais recente será selecionada por padrão.

## Conteúdo

---

1. Módulo de Instalação
2. Configuração do Canal
3. Nova Instalação
4. Adicionar ou remover Produtos/Pacotes de Idioma
5. ID do produto Office 365
6. Arquivos de Instalação
7. Download dos arquivos de instalação
8. Configuração do Office

## Módulo de Instalação

---

A Ferramenta de Implantação do Office é uma ferramenta oficial da Microsoft para implantar o Office e o Office Tool Plus suporta quase todos os parâmetros de configurações.
O Office Tool Plus é um pequeno módulo que desenvolvemos para instalar o Office. Sua funcionalidade não é tão poderosa quanto a ferramenta oficial, mas também permite que o Office seja instalado sem problemas.

[Visão Geral da Ferramenta de Implantação do Office](https://aka.ms/ODT)

[Opções de configuração da Ferramenta de Implantação do Office](https://docs.microsoft.com/pt-br/DeployOffice/configuration-options-for-the-office-2016-deployment-tool)

[Ferramenta de Personalização do Office](https://config.office.com/deploymentsettings)

**Se você deseja instalar o Office 2019 volume no Windows 7, por favor, altere para o módulo Office Tool Plus!**

`Nota: Se você tiver problemas na instalação usando a Ferramenta de Implantação do Office, tente o módulo do Office Tool Plus!`

## Configuração do Canal

---

`O Office, Visio, Project 2019 [volume] só suportam o canal Office 2019 Perpetual Enterprise Channel e não podem ser adicionados com outros produtos (como o Office 365). '
Se você quiser instalar o Visio enquanto tiver o Office 365 instalado, escolha o Visio 2016 Retail/Volume ou o Visio 2019 Retail (o projeto é o mesmo).

Para o Office 2016/2019 [Retail]/365 você pode escolher outros canais (exceto Office 2019 Perpetual Enterprise Channel). Recomendamos usar o canal Monthly Channel.
Para quem não se importa com novos recursos mensais, poderá escolher o canal Semi-Annual Channel.
**Se você está enfrentando problemas com o canal Targeted/Insider/Dogfood Channel, procure uma solução.**

## Nova Instalação

---

Antes de começar, recomendamos que você leia a seção Configuração do Canal.

Clique no botão [+ Adicionar produto] e selecione qual deseja. Para o Office/Visio, você pode desmarcar aplicativos indesejados.
**Groove significa OneDrive for Business, Lync significa Skype for Business.**

Clique no botão [+ Adicionar pacote de idioma] e selecione o seu idioma. Se você não especificar um pacote de idiomas, o Office Tool Plus irá selecionar o idioma do sistema por padrão (Se não for adaptado, o idioma principal será [en-US]-English (US)).

Em seguida, clique no botão [Implantar o Office] para iniciar.

`Nota: Se você adicionou pacotes de idiomas manualmente, adicione ao menos um pacote de idioma do tipo [Completo]. '

## Adicionar ou remover Produtos/Pacotes de idiomas

---

Se o Office já estiver instalado no computador, você poderá adicionar ou remover produtos/pacotes de idioma com o Office Tool Plus.

### Adicionar Produtos/Pacotes de idiomas

Clique no botão [+ Adicionar produto] e selecione qual deseja.

`Nota: Para evitar problemas, não adicione um pacote de produto/idioma instalado.'

### Alterar Produtos

Se você tem um produto instalado com vários aplicativos, como o Office 365, incluindo Word, PowerPoint, Excel, Outlook e etc. e deseja desinstalar um aplicativo, selecione o produto em primeiro lugar, em seguida, desmarque os aplicativos indesejados e finalmente, clique no botão [Implantar o Office].

### Remover Produtos/Pacotes de Idioma

Marque os pacotes de produtos/idiomas que você deseja desinstalar na lista e clique no submenu "Desinstalar os produtos/idiomas selecionados" no botão [Implanatar o Office] para iniciar.

`Nota: Mantenha ao menos um pacote de idioma do tipo [Completo], caso contrário, todo o Office será desinstalado!

## ID do produto Office 365

---

```txt
Office 365 ProPlus		O365ProPlusRetail
Office 365 Enterprise E3		O365ProPlusRetail
Office 365 Enterprise E4		O365ProPlusRetail
Office 365 Enterprise E5		O365ProPlusRetail
Office 365 Midsize		O365ProPlusRetail
Office 365 Business		O365BusinessRetail
Office 365 Business Premium	O365BusinessRetail
Office Small Business Premium	O365SmallBusPremRetail
Office 365 Home		O365HomePremRetail
Office 365 Personal		O365HomePremRetail
```

Para mais informações, visite o site [IDs de produtos compatíveis com a Ferramenta de Implantação do Office para clique para executar](https://docs.microsoft.com/pt-br/office365/troubleshoot/administration/product-ids-supported-office-deployment-click-to-run)

## Arquivos de Instalação

---

Os arquivos de instalação são o pacote de instalação do Office. O Office Tool Plus pode fazer o download dos arquivos de instalação do Office dos servidores da Microsoft e criar imagens ISO. Após baixar os arquivos de instalação você pode usar a Instalação Offline ou compartilhar com outras pessoas para economizar largura de banda e reduzir o tempo.

Clique no submenu "Download" em 'Gerenciar arquivos de instalação' para iniciar. Você pode configurá-lo ou usar as configurações padrão do Office Tool Plus e em seguida, clicar no botão [Iniciar] para fazer o download.

![Download Installation Files](https://server.coolhub.top/OfficeTool/images/en-us/DownloadPanel.png)

### Mais Informações

[Visão geral dos canais de atualização do Office 365 ProPlus](https://docs.microsoft.com/pt-br/DeployOffice/overview-of-update-channels-for-office-365-proplus)

[Histórico de atualização do Office 365 ProPlus](https://docs.microsoft.com/pt-br/officeupdates/update-history-office365-proplus-by-date)

[Canal de atualização para o Office 2019](https://docs.microsoft.com/pt-br/DeployOffice/office2019/update#update-channel-for-office-2019)

## Download dos arquivos de instalação

---

Além de baixar os arquivos de instalação usando a Ferramenta de Implantação do Office, o Office Tool Plus também inclui o Thunder, que permite aos usuários baixarem rapidamente os arquivos de instalação do Office. Eles não possuem nenhuma diferença nas funções básicas,  mas apenas o Thunder suporta a barra de progresso do download, definir limites de velocidade e definir o proxy. Se houver um problema com o download no Thunder, tente alternar o mecanismo para a Ferramenta de Implantação do Office.

### Configuração do limite de velocidade do Thunder

Para definir o limite de velocidade do download ao usar o Thunder, clique na velocidade de download e em seguida, defina o limite de velocidade no menu pop-up. Para cancelar o limite de velocidade, insira 0.

## Configuração do Office

---

`No lado direito da página Gerenciar você pode acessar o painel de Configuração do Office.
O Office Tool Plus oferece suporte à modificação do canal de atualização do Office e também oferece suporte à modificação do proprietário exibido no Office. Depois de editado, clique em [Salvar] para aplicar as configurações.

Além disso, se você tiver um problema com o Office, você pode tentar corrigir o Office neste painel.

**Nota: Se você clicar em [Recarregar], a lista de produtos e pacotes de idioma selecionados à esquerda será recarregada e algumas configurações serão redefinidas para o padrão.**
