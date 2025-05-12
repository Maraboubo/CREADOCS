/*
Déclaration des variables.
*/
//Variables de stockage des Url de l'API Créadocs.
const url = 'https://localhost:44338/api/interlocuteur'; // URL pour les utilisateurs
const urlagence = 'https://localhost:44338/api/agence'; // URL pour les agences
const urltitre = 'https://localhost:44338/api/titre'; // URL pour les fonctions

//Variables de sélection des éléments du formulaire.
pageUn = document.getElementById("conteneurInscription1");
pageDeux = document.getElementById("conteneurInscription2");
pageTrois = document.getElementById("conteneurInscription3");
boutonPageUn = document.getElementById("boutonSuivantP1");
retourPageUn = document.getElementById("flecheRetour1");
boutonPageDeux = document.getElementById("boutonSuivantP2");
retourPageDeux = document.getElementById("flecheRetour2");
boutonPageTrois = document.getElementById("boutonSubmit");


//Variables des champs de remplissage du formulaire.
eMail = document.getElementById("mailInter");
motDePasse = document.getElementById("mdpInter");
nom = document.getElementById("nomInter");
prenom = document.getElementById("prenomInter");
login = document.getElementById("loginInter");
telephone = document.getElementById("telInter");


//Regles d'exclusion pour la vérification des champs.
var regex = /^[A-Za-z0-9_.@]+$/;
//regexChiffres selectionne les nombres.
var regexChiffres = /\d/;
var regexLettres = /[a-zA-Z]/;


//Display pour l'affichage de base.
pageUn.style.display = "block";
pageDeux.style.display = "none";
pageTrois.style.display = "none";


//Ecouteurs d'évenements sur les boutons du formaulaire.
//Page 1
boutonPageUn.addEventListener("click", checkEmail);
//Page 2
retourPageUn.addEventListener("click", affichagePageUn);
boutonPageDeux.addEventListener("click", checkMotDePasse);
//Page 3
retourPageDeux.addEventListener("click", affichagePageDeux);
boutonPageTrois.addEventListener("click", checkFormulaire);


//Affichage des differentes pages.
function affichagePageUn() {
    pageUn.style.display = "block";
    pageDeux.style.display = "none";
    pageTrois.style.display = "none";
}
function affichagePageDeux() {
    pageUn.style.display = "none";
    pageDeux.style.display = "block";
    pageTrois.style.display = "none";
}
function affichagePageTrois(){
    pageUn.style.display = "none";
    pageDeux.style.display = "none";
    pageTrois.style.display = "block";
}

/*
Vérification du champ mail.
*/
function checkEmail() {
    if ((eMail.value).length == 0) {
        alert("Le Champ de texte est vide");
    }
    //La m�thode includes() vérifie la présence des caractères mentionnés
    else if ((eMail.value).includes('@') == false || (eMail.value).includes('.') == false) {
        alert("L'adresse entree doit comprter un caractere '@' et au moins un point.");
    }
    //Les méthodes startsWith() et endsWith() vérifie la présence des caractères mentionnés en début et fin de ligne
    else if ((eMail.value).startsWith('@') == true || (eMail.value).startsWith('.') == true) {
        alert("Les caract�re '@' et 'point', ne doivent pas se trouver en d�but de l'adresse.");
    }
    else if ((eMail.value).endsWith('@') == true || (eMail.value).endsWith('.') == true) {
        alert("Les caract�re '@' et 'point', ne doivent pas se trouver en d�but de l'adresse.");
    }
    //La méthode indexOf() vérifie renvoie la position des caractères mentionnés
    else if ((eMail.value).indexOf('@') > (eMail.value).indexOf('.')) {
        alert("Le caractere 'point', doit se trouver apres le caractere '@'.");
    }
    //La méthode test() vérifie renvoie la présence des caractéres mentionnés dans la variable regex déclarée en début de script
    else if (regex.test(eMail.value) == false) {
        console.log(regex.test(eMail.value));
        alert("L'addresse ne doit comporter que des chiffres, des lettres, '@', '.', '_'.");
    }
    else {
        affichagePageDeux();
    }
}
/*
Vérification du champ du mot de passe.
*/
function validateMdp(input) {
    if (input.value.length == 0) {
    input.setCustomValidity("Votre mot de passe doit comporter au moins 1 caractère");
    }
    else if (input.value.length < 10) {
        input.setCustomValidity("Votre mot de passe doit comporter au moins 10 caractères");
    }
    else if ((regexChiffres.test(input.value) == false) || (regexLettres.test(input.value) == false)) {
        input.setCustomValidity("Le Mot de passe doit comporter au moins un chiffre et une lettre.");
    }
    else {
        input.setCustomValidity("");
    }
    input.reportValidity();
}
function checkMotDePasse() {

    if ((motDePasse.value).length == 0) {
        alert("Le Champ de texte est vide");
    }
    else if ((motDePasse.value).length < 10) {
        alert("Le Mot de passe doit comporter au moins 10 caractères.");
    }
    //La méthode test() vérifie renvoie la présence des caractères mentionnés dans la variable regex déclarée en début de script
    else if (regexChiffres.test(motDePasse.value) == false) {
        alert("Le Mot de passe doit comporter au moins un chiffre.");
    }
    else {
        affichagePageTrois();
    }
}
/*
vérification des champs du formulaire page3.
*/
function checkFormulaire() {
    //check champ nom
    if ((nom.value).length == 0) {
        alert("Le Champ 'Nom' est vide");
    }
    //check champ prénom
    else if ((prenom.value).length == 0) {
        alert("Le Champ 'Prénom' est vide");
    }
    //check champ login
    else if ((login.value).length == 0) {
        alert("Le Champ 'Identifiant' est vide");
    }
    //check champ numéro de téléphone
    else if ((telephone.value).length == 0) {
        alert("Le Champ 'Numéro de téléphone' est vide");
    }
    else {
        envoiJsonInterFormulaire();
        /*recuperationUser();*/
    }
}

// Fonction pour remplir la liste déroulante des agences
async function populateAgenceDropdown() {
    try {
        const response = await fetch(urlagence);
        const agences = await response.json();

        const agenceDropdown = document.getElementById('id_agence');

        agences.forEach(agence => {
            const option = document.createElement('option');
            option.value = agence.id_agence; // Utilisez l'id de l'agence comme valeur
            option.text = agence.nomAgence; // Utilisez le nom de l'agence comme texte
            agenceDropdown.appendChild(option);
        });

    } catch (error) {
        console.error('Erreur lors du chargement des agences:', error);
    }
}

// Fonction pour remplir la liste déroulante des fonctions des employés
async function populateTitreDropdown() {
    try {
        const response = await fetch(urltitre);
        const titres = await response.json();

        const titreDropdown = document.getElementById('id_titre');

        titres.forEach(titre => {
            const option = document.createElement('option');
            option.value = titre.id_titre; // Utilisez l'id de la fonction des employés comme valeur
            option.text = titre.nomTitre; // Utilisez le nom de la fonction des employés comme texte
            titreDropdown.appendChild(option);
        });

    } catch (error) {
        console.error('Erreur lors du chargement des titres:', error);
    }
}

function envoiJsonInterFormulaire() {
    var form = document.getElementById('inscription'); // Transfère les données du formulaire dans la variable 'form'.
    var donneesFormulaire = new FormData(form); // Récupère les données du formulaire
    // Convertit les données en objet JSON
    var interlocuteur = {};

    donneesFormulaire.forEach((value, key) => {
        interlocuteur[key] = value;
    });

    fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(interlocuteur)
    })
        .then((resp) => {
            if (!resp.ok) {
                throw new Error('Erreur de réseau :' + resp.statusText);
            }
            return resp.json();
        })
        .then(function (data) {
            console.log("Nouvel Interlocuteur:", data);
            localStorage.setItem('user', JSON.stringify(data)); // Stocker les informations de l'utilisateur
            window.location.href = 'AccueilCreadocs.html'; // Rediriger vers la page d'accueil
        })
        .catch(function (error) {
            console.error('Il y a eu un problème avec votre opération fetch :', error);
        });
}


//APPEL DES FONCTIONS POUR LE REMPLISSAGE DES CHOIX DEROULANTS.

// Appeler la fonction pour remplir la liste déroulante au chargement de la page
document.addEventListener('DOMContentLoaded', populateAgenceDropdown);
// Appeler la fonction pour remplir la liste déroulante au chargement de la page
document.addEventListener('DOMContentLoaded', populateTitreDropdown);