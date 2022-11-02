document.getElementById("conf2").style.display = "none";
document.getElementById("conf3").style.display = "none";

// Ajoute un input du mot de passe
let nbInputPassword = 7;
function AddPasswordInput() {
    let body = document.getElementById("Password");
    let add = document.createElement("input");
    add.type = "text";
    add.maxLength = 1;
    add.id = nbInputPassword;
    add.className = "inputP";
    add.setAttribute("onchange", "updateValue(" + nbInputPassword + ")");
    body.append(add);

    nbInputPassword++;
}

function RemovePasswordInput() {
    if (nbInputPassword > 7) {
        let r = document.getElementById(nbInputPassword - 1);
        r.remove();
        nbInputPassword--;
    }
}

// Dicte la lettre écrite lors d'une modification du mot de passe
function updateValue(n) {
    let v = document.getElementById(n);
    let regexLettre = /^[a-zA-Z]+$/i;
    let regexChiffre = /^[0-9.#]+$/i;

    if (regexLettre.test(v.value) == true) {
        document.getElementById(v.value.toUpperCase()).play();
    }
    else if (regexChiffre.test(v.value) == true) {
        document.getElementById(convertN(v.value)).play();
    }
    else {
        // Remplacer les id des audios par 'zero' etc... et faire une conversion ici
        document.getElementById(v.value).play();
    }
}

// Fonction de convertion de nom ex 0 -> zero
function convertN(n) {
    switch (n) {
        case "1":
            return "un";
        case "2":
            return "deux";
        case "3":
            return "trois";
        case "4":
            return "quatre";
        case "5":
            return "cinq";
        case "6":
            return "six";
        case "7":
            return "sept";
        case "8":
            return "huit";
        case "9":
            return "neuf";
        case ".":
            return "point";
        case "#":
            return "diese";
        default:
            return "zero";
    }
}


function updateConfPassword1() {
    document.getElementById("etoile").play();
    document.getElementById("conf2").style.display = "block";
}
function updateConfPassword2() {
    document.getElementById("licorne").play();
    document.getElementById("conf3").style.display = "block";
}
function updateConfPassword3() {
}
