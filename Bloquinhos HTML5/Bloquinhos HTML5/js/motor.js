var cores = new Array("red", "blue", "yellow", "green");
var nivel = 1;
var pontos = 0;
var restantes = 64;
var limiteTempo = 4000;
var tempoAtual = 0;
var vidas = 3;
var proximaVida = 10000;
var corEscolhida = "";


function corAleatoria() {
    return cores[Math.floor(Math.random() * 4)].toString();
}

function atualizaPainel() {
    document.getElementById("nivel").textContent = "Nivel: " + nivel;
    document.getElementById("pontos").textContent = "Pontos: " + pontos;
    document.getElementById("vidas").textContent = "Vidas: " + vidas;
    document.getElementById("restantes").textContent = "Blocos restantes: " + restantes;
    document.getElementById("proximavida").textContent = "Próxima vida: " + proximaVida;
}

function inicio() {
    var corpo = document.getElementById("corpo");

    //inicia os objetos
    for (var i = 1; i <= 64; i++) {
        var bloco = document.createElement("div");
        bloco.id = "bloco" + i;
        bloco.className = "bloco";
        bloco.style.backgroundColor = corAleatoria();
        corpo.appendChild(bloco);

        if (i % 8 == 0)
            corpo.innerHTML += "<br/>";
    }

    //adiciona o evento click
    for (var j = 1; j <= 64; j++) {
        var obj = document.getElementById("bloco" + j);
        obj.addEventListener("click", ligada, false);
    }

    corEscolhida = corAleatoria();
    document.getElementById("corEscolhida").style.backgroundColor = corEscolhida;

    setInterval(timer, 100);
    atualizaPainel();
}

function timer() {

    tempoAtual += 100;

    if (limiteTempo < tempoAtual) {

        atualizaPainel();

        for (var i = 1; i <= 64; i++) {
            var bloco = document.getElementById("bloco" + i);
            if (bloco.style.backgroundColor != "black")
                bloco.style.backgroundColor = corAleatoria();
        }

        tempoAtual = 0;
    }
}


//on click numa div de jogo
function ligada(e) {
    var sender = (e && e.target) || (window.event && window.event.srcElement);

    if (sender.style.backgroundColor == corEscolhida) {
        sender.style.backgroundColor = "black";
        restantes--;
        pontos += (50 * nivel);
    }
    else {
        alert("Você errou!");
        vidas--;
        pontos -= (80 * nivel);
    }
    atualizaPainel();

    if (pontos >= proximaVida) {
        vidas++;
        proximaVida += (pontos * 0.15) + 10000
    }

    if (restantes == 0) {
        if (limiteTempo > 2000)
            limiteTempo -= 300;
        else if (limiteTempo > 1000)
            limiteTempo -= 200;
        else
            limiteTempo -= 100;

        if (_limiteTempo < 300)
            _limiteTempo = 300;

        restantes = 64;
        nivel++;


    }

    if (vidas == 0) terminaJogo();

    atualizaPainel();
}

function terminaJogo() {
    alert("Você perdeu!\nInicie um novo jogo.");
    for (var i = 1; i <= 64; i++) {
        var bloco = document.getElementById("bloco" + i);
        bloco.style.backgroundColor = "black";
    }
}

function novoJogo() {
    alert("Implementar");
}