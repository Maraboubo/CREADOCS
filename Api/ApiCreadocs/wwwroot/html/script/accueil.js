console.log("it runs")
OngletConnexion = document.getElementById('texteOngletUtilConnect');
BoutonSeDeconnecter = document.getElementById('boutonDeconnexion');
DivUtilisateur = document.getElementById('boutonUtilConnect');
BoutonConnexion = document.getElementById('boutonConnexion');
BoutonInscription = document.getElementById('boutonInscription');
//Boutons en lien vers les interfaces.
BoutonAssurance = document.getElementById('interfaceUn');
BoutonSim = document.getElementById('interfaceDeux');
BoutonCarteBancaire = document.getElementById('interfaceTrois');
BoutonMutuelle = document.getElementById('interfaceQuatre');


document.addEventListener('DOMContentLoaded', ChargementUtilisateur);
function ChargementUtilisateur()
{
    const user = JSON.parse(localStorage.getItem('user'));
    if (user) {
        OngletConnexion.innerText = `${user.prenomInter} \n ${user.nomInter}`;
        DivUtilisateur.style.display = 'block';
        BoutonSeDeconnecter.style.display = 'block';
        BoutonConnexion.style.display = 'none';
        BoutonInscription.style.display = 'none';

        BoutonAssurance.href = 'AssuranceCreadocs.html';
        BoutonSim.href = 'AssuranceCreadocs.html';
        BoutonCarteBancaire.href = 'AssuranceCreadocs.html';
        BoutonMutuelle.href = 'AssuranceCreadocs.html';
    }
    else
    {
        DivUtilisateur.style.display = 'none';
        BoutonSeDeconnecter.style.display = 'none';
        BoutonConnexion.style.display = 'block';
        BoutonInscription.style.display = 'block';

        BoutonAssurance.href = 'ConnexionCreadocs.html';
        BoutonSim.href = 'ConnexionCreadocs.html';
        BoutonCarteBancaire.href = 'ConnexionCreadocs.html';
        BoutonMutuelle.href = 'ConnexionCreadocs.html';
    }
}

BoutonSeDeconnecter.addEventListener('click', Deconnexion);
function Deconnexion()
{
    localStorage.removeItem('user'); // Effacer le stockage local
    window.location.reload(); // Recharger la page pour appliquer les modifications
}