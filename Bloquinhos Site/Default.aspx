<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Bloquinhos_Site._Default"
    MasterPageFile="~/MasterPage.Master" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <span class="h1">Pysi Bloquinhos </span>
    <div class="fakehr">
    </div>
    <p>
        Pysi Bloquinhos é um jogo de velocidade e raciocínio. Engana-se quem joga a primeira
        vez, pensando ser fácil.
    </p>
    <p>
        O jogo a cada nível sorteia uma cor para ser clicada, e você precisa encontrar os
        símbolos da mesma cor na grade à esquerda. O problema é que a cada fase que se passa,
        mais rápido o jogo fica.</p>

        <p>A versão online do jogo é grátis, se quiser jogar de modo online clique na figura abaixo.</p>

    <a href="jogueonline.aspx" target="_blank">
        <img src="img/bloquinhos.png" alt="Bloquinhos Desktop" 
        style="height: 414px; width: 593px" /></a>
    <br />
    <br />
    Você também pode comprar a versão instalável por apenas R$ 5,00* e ter vantagens 
    como tabela de recordes, multi-idioma, atualizações gratúitas e independência da 
    internet.<br />
    <br />
    Para saber mais sobre a versão instalável ou comprá-la, <a href="comprar.aspx">clique aqui</a>.
</asp:Content>
