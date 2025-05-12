
/*
Déclaration des variables.
*/

//Eléments de la fonctionalité GéoNames
const urlPays = 'http://api.geonames.org/countryInfoJSON?username=mathieusoleri';
const urlSexe = 'https://localhost:44338/api/sexe'; // URL pour les sexes
const urlSecu = 'https://localhost:44338/api/secu'; // URL pour les Régimes de sécurité sociales
const urlClient = 'https://localhost:44338/api/client'; // URL pour les Clients
const urlAssurance = 'https://localhost:44338/api/assurance'; // URL pour les Clients
const urlContrat = 'https://localhost:44338/api/contrat'; // URL pour les Contrats
const username = 'mathieusoleri'; // Remplacer par le username de inteligent document system


//Eléments de la page
ongletUtilisateur = document.getElementById("utilisateur");
champPays = document.getElementById("codePays");



//Encapsultion de l'utilisateur dans une variable
const user = JSON.parse(localStorage.getItem('user'));

pageUn = document.getElementById("conteneurAssurance1");
pageDeux = document.getElementById("conteneurAssurance2");
pageTrois = document.getElementById("conteneurAssurance3");

boutonPageUn = document.getElementById("boutonSuivantAssur1");
retourPageUn = document.getElementById("flecheRetour1");
boutonPageDeux = document.getElementById("boutonSuivantAssur2");
retourPageDeux = document.getElementById("flecheRetour2");
boutonPageTrois = document.getElementById("boutonEnvoyerAssur");



//Utiliser ce display pour l'affichage de base.
pageUn.style.display = "none";
pageDeux.style.display = "none";
pageTrois.style.display = "block";
//Affichage du nom et prénom de l'utilisateur présent dans le 'Local storage'
ongletUtilisateur.innerText = `${user.prenomInter} \n ${user.nomInter}`;
//Dissimulation du champ de texte "Identifiant Pays"
champPays.style.display = "none";

//exécution du peuplement de la page3
populatePageTrois();



//GESTION DE L'AFFICHAGE DES DIFFERENTES PAGES
/*boutonPageUn.addEventListener("click", envoiDataClient);*/
boutonPageUn.addEventListener("click", checkFormulaire);
retourPageUn.addEventListener("click", affichagePageUn);
/*boutonPageDeux.addEventListener("click", affichagePageTrois);*/
boutonPageDeux.addEventListener("click", checkFormulaireDeux);
retourPageDeux.addEventListener("click", affichagePageDeux);
boutonPageTrois.addEventListener("click", envoiDataKwSoft);


function affichagePageUn() {
    pageUn.style.display = "block";
    pageDeux.style.display = "none";
    pageTrois.style.display = "none";
    /*pageQuatre.style.display = "none";*/
}
function affichagePageDeux() {
    pageUn.style.display = "none";
    pageDeux.style.display = "block";
    pageTrois.style.display = "none";
    /*pageQuatre.style.display = "none";*/
}
function affichagePageTrois() {
    pageUn.style.display = "none";
    pageDeux.style.display = "none";
    pageTrois.style.display = "block";
    /*pageQuatre.style.display = "none";*/
}


/*
Check du formulaire page1.
*/
function checkFormulaire() {
    //Elements de la page 'Client'
    const sexe = document.getElementById("id_sexe");
    const regSecu = document.getElementById("id_regimeSecu");
    const nom = document.getElementById("nomCli");
    const prenom = document.getElementById("prenomCli");
    const identite = document.getElementById("numIdCli");
    const naissance = document.getElementById("dateNaissCli");
    const adresse1 = document.getElementById("add1Cli");
    const adresse2 = document.getElementById("add2Cli");
    const adresse3 = document.getElementById("add3Cli");
    const codePostal = document.getElementById("postalCode");
    const ville = document.getElementById("placeName");
    const countryCode = document.getElementById("countryCode");
    const Pays = document.getElementById("countryName");

    //check champ numéro identité client 
    if ((identite.value).length == 0) {
        alert("Le Champ 'Nom' est vide");
    }
    ////check champ nom
    //else if ((nom.value).length == 0) {
    //    alert("Le Champ 'Nom' est vide");
    //}
    ////check champ prénom
    //else if ((prenom.value).length == 0) {
    //    alert("Le Champ 'Prénom' est vide");
    //}
    ////check champ sexe
    //else if ((sexe.value) < 1 || (sexe.value) > 3) {
    //    alert("Veuillez renseigner le champ 'Sexe' ");
    //}
    ////check champ date de naissance
    //else if ((naissance.value).length == 0 ) {
    //    alert("Veuillez renseigner le champ 'Date de naissance' ");
    //}
    ////check champ sécurité sociale
    //else if ((regSecu.value) < 1 || (regSecu.value) > 4) {
    //    alert("Veuillez renseigner le champ 'Régime de sécurité sociale' ");
    //}
    ////check champ adresse ligne 1
    //else if ((adresse1.value).length == 0) {
    //    alert("Le Champ 'Adresse1' est vide");
    //}
    ////check champ Pays
    //else if ((Pays.value).length == 0) {
    //    alert("Le Champ 'Pays' est vide");
    //}
    ////check champ code postal
    //else if ((codePostal.value).length == 0) {
    //    alert("Le Champ 'Code postal' est vide");
    //}
    ////check champ ville
    //else if ((ville.value).length == 0) {
    //    alert("Le Champ 'Ville' est vide");
    //}
    else {
        envoiDataClient();
        affichagePageDeux();
    }
}

function checkFormulaireDeux()
{
    //Elements de la page 'Contrat'
    const assurance = document.getElementById("id_assu");

    //check champ numéro identité client 
    if ((assurance.value) < 1 || (assurance.value) > 5) {
        alert("Veuillez renseigner Le contrat d'assurance");
    }
    else {
        envoiDataContrat();
        affichagePageTrois();
        ////exécution du peuplement de la page3
        /*populatePageTrois();*/

    }
}

/*
    Peuplement des choix déroulants grâce à l'Api GéoNames.
*/

// Fonction pour remplir la liste déroulante des pays
async function populateCountryDropdown() {
    try {
        const response = await fetch(urlPays);
        const countries = await response.json();
        const pays = countries.geonames;

        const countryDropdown = document.getElementById('countryName');

        pays.forEach(country => {
            const option = document.createElement('option');
            option.value = country.countryCode; // Utilisez le code du pays comme valeur
            option.text = country.countryName; // Utilisez le nom du pays comme texte
            countryDropdown.appendChild(option);
        });
    } catch (error) {
        console.error('Erreur lors du chargement des pays:', error);
    }
}


// Fonction pour remplir la liste déroulante des villes
async function populateCityDropdown(countryCode, postalCode) {
    try {
        const response = await fetch(`http://api.geonames.org/postalCodeSearchJSON?postalcode=${postalCode}&country=${countryCode}&maxRows=500&username=${username}`);
        const cities = await response.json();
        const villes = cities.postalCodes;

        const cityDropdown = document.getElementById('placeName');
        cityDropdown.innerHTML = ''; // Vider la liste des villes précédentes
        const defaultOption = document.createElement('option');
        defaultOption.value = '';
        defaultOption.text = 'Sélectionnez une ville';
        cityDropdown.appendChild(defaultOption);

        villes.forEach(city => {
            const option = document.createElement('option');
            option.value = city.placeName; // Utilisez le nom de la ville comme valeur
            option.text = city.placeName; // Utilisez le nom de la ville comme texte
            cityDropdown.appendChild(option);
        });

    } catch (error) {
        console.error('Erreur lors du chargement des villes:', error);
    }
}

// Fonction pour vider la liste déroulante des villes
function clearCityDropdown() {
    const cityDropdown = document.getElementById('placeName');
    cityDropdown.innerHTML = ''; // Vider la liste des villes
    const defaultOption = document.createElement('option');
    defaultOption.value = '';
    defaultOption.text = 'Sélectionnez une ville';
    cityDropdown.appendChild(defaultOption);
}

// Ajouter un gestionnaire d'événements pour détecter le changement de sélection du pays
document.getElementById('countryName').addEventListener('change', () => {
    const selectedCountry = document.getElementById('countryName').value;
    document.getElementById('countryCode').value = selectedCountry; // Mettre à jour le champ countryCode
    document.getElementById('countryCode').text = selectedCountry; // Mettre à jour le champ countryCode

    if (selectedCountry) {
        document.getElementById('postalCode').addEventListener('input', () => {
            const postalCode = document.getElementById('postalCode').value;
            if (postalCode) {
                populateCityDropdown(selectedCountry, postalCode);
            } else {
                clearCityDropdown();
            }
        });
    } else {
        clearCityDropdown();
    }
});

/*
     Peuplement du choix déroulant sexe.
*/

// Fonction pour remplir la liste déroulante des sexes
async function populateSexeDropdown() {
    try {
        const response = await fetch(urlSexe);
        const sexes = await response.json();

        const sexeDropdown = document.getElementById('id_sexe');

        sexes.forEach(sexe => {
            const option = document.createElement('option');
            option.value = sexe.id_sexe; // On utilise l'id du sexe comme valeur
            option.text = sexe.nomSexe; // On Utilise nom du sexe comme texte
            sexeDropdown.appendChild(option);
        });

    } catch (error) {
        console.error('Erreur lors du chargement des sexes:', error);
    }
}

// Fonction pour remplir la liste déroulante des régimes de sécurité sociale
async function populateSecuDropdown() {
    try {
        const response = await fetch(urlSecu);
        const secus = await response.json();

        const secuDropdown = document.getElementById('id_regimeSecu');

        secus.forEach(secu => {
            const option = document.createElement('option');
            option.value = secu.id_regimeSecu; // On utilise l'id de l'agence comme valeur
            option.text = secu.nomRegimeSecu; // On utilise le nom de l'agence comme texte
            secuDropdown.appendChild(option);
        });

    } catch (error) {
        console.error('Erreur lors du chargement des sexes:', error);
    }
}

async function envoiDataClient() {
    //Elements de la page 'Client'
    const sexe = document.getElementById("id_sexe").value;
    const regSecu = document.getElementById("id_regimeSecu").value;
    const nom = document.getElementById("nomCli").value;
    const prenom = document.getElementById("prenomCli").value;
    const identite = document.getElementById("numIdCli").value;
    const naissance = document.getElementById("dateNaissCli").value;
    const depardement = document.getElementById("depNaissCli").value;
    const adresse1 = document.getElementById("add1Cli").value;
    const adresse2 = document.getElementById("add2Cli").value;
    const adresse3 = document.getElementById("add3Cli").value;
    const postalCode = document.getElementById("postalCode").value;
    const placeName = document.getElementById("placeName").value;
    const countryCode = document.getElementById("countryCode").value;
    const countryDropdown = document.getElementById("countryName");
    const countryName = countryDropdown.options[countryDropdown.selectedIndex].text;

    const clientData = {
        id_sexe: sexe,
        id_ville: 0,
        id_regimeSecu: regSecu,
        nomCli: nom,
        prenomCli: prenom,
        numIdCli: identite,
        dateNaissCli: naissance,
        depNaissCli: depardement,
        add1Cli: adresse1,
        add2Cli: adresse2,
        add3Cli: adresse3,
    };

    const objetClient = JSON.stringify({ Client: clientData, postalCode, placeName, countryCode, countryName });

    const response = await fetch(urlClient, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: objetClient
    });
    console.log(objetClient);
    if (response.ok) {
        const client = await response.json();
        localStorage.setItem('client', JSON.stringify(client));
        // Passer à la prochaine partie du formulaire
        alert('Client enregistré avec succès');
    } else {
        console.error('Erreur lors de l\'enregistrement du client');
        alert('Erreur lors de l\'enregistrement du client');
    }
}

async function envoiDataContrat() {
    //récupération des objets stockés dans le 'localstorage'
    const user = JSON.parse(localStorage.getItem('user'));
    const client = JSON.parse(localStorage.getItem('client'));

    //Elements de la page 'Client'
    const interlocuteur = user.id_inter;
    const idClient = client.id_Cli;
    const assurance = document.getElementById("id_assu").value;
    const dateContrat = new Date();
    const debutContrat = new Date();
    debutContrat.setMonth(debutContrat.getMonth() + 1);
    const finContrat = new Date(debutContrat);
    finContrat.setFullYear(finContrat.getFullYear() + 1);

    const contratData = {
        id_typContr: 1,
        id_inter: interlocuteur,
        id_Cli: idClient,
        id_Assu: assurance,
        dateContr: dateContrat,
        dateDebutContr: debutContrat,
        dateFinContr: finContrat
    };

    const objetContrat = JSON.stringify(contratData);

    const response = await fetch(urlContrat, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json' },
        body: objetContrat
    });
    console.log(objetContrat);
    if (response.ok) {
        const contrat = await response.json();
        localStorage.setItem('contrat', JSON.stringify(contrat));
        // Passer à la prochaine partie du formulaire
        alert('Contrat enregistré avec succès');
    } else {
        console.error('Erreur lors de l\'enregistrement du contrat');
        alert('Erreur lors de l\'enregistrement du contrat');
    }
}

async function envoiDataKwSoft() {
    ////récupération des objets stockés dans le 'localstorage'
    //const user = JSON.parse(localStorage.getItem('user'));
    //const client = JSON.parse(localStorage.getItem('client'));
    //const contrat = JSON.parse(localStorage.getItem('contrat'));

    ////Elements de la page 'Client'
    //var nomI = document.getElementById('nomInter').innerHTML;
    //var prenomI = document.getElementById('prenomInter').innerHTML;
    //var telI = document.getElementById('telInter').innerHTML;
    //var mailI = document.getElementById('mailInter').innerHTML;
    ////client
    //var nomC = document.getElementById('nomClient').innerHTML;
    //var prenomC = document.getElementById('prenomClient').innerHTML;
    //var add1C = document.getElementById('add1Client').innerHTML;
    //var add2C = document.getElementById('add2Client').innerHTML;
    //var add3C = document.getElementById('add3Client').innerHTML;
    //var codPostC = document.getElementById('codePostVille').innerHTML;
    //var villeC = document.getElementById('nomVille').innerHTML;
    //var paysC = document.getElementById('nomPays').innerHTML;
    ////contrat
    //var numCo = document.getElementById('id_Contr').innerHTML;
    //var typCo = document.getElementById('typContr').innerHTML;
    //var datCo = document.getElementById('dateContr').innerHTML;
    //var debCo = document.getElementById('dateDebutContr').innerHTML;
    ////échéances
    ////Peuplées grace à la fonction
    ////valeurs
    //var val1 = document.getElementById('valeurAssu1').innerHTML;
    //var val2 = document.getElementById('valeurAssu2').innerHTML;
    //var val3 = document.getElementById('valeurAssu3').innerHTML;
    //var val4 = document.getElementById('valeurAssu4').innerHTML;
    //var val5 = document.getElementById('valeurAssu5').innerHTML;
    //var val6 = document.getElementById('valeurAssu6').innerHTML;
    //var val7 = document.getElementById('valeurAssu7').innerHTML;
    //var val8 = document.getElementById('valeurAssu8').innerHTML;
    //var val9 = document.getElementById('valeurAssu9').innerHTML;
    //var val10 = document.getElementById('valeurAssu10').innerHTML;
    //var val11 = document.getElementById('valeurAssu11').innerHTML;
    //var val12 = document.getElementById('valeurAssu12').innerHTML;
    ////échéances
    //var eche1 = document.getElementById('eche1').innerHTML;
    //var eche2 = document.getElementById('eche2').innerHTML;
    //var eche3 = document.getElementById('eche3').innerHTML;
    //var eche4 = document.getElementById('eche4').innerHTML;
    //var eche5 = document.getElementById('eche5').innerHTML;
    //var eche6 = document.getElementById('eche6').innerHTML;
    //var eche7 = document.getElementById('eche7').innerHTML;
    //var eche8 = document.getElementById('eche8').innerHTML;
    //var eche9 = document.getElementById('eche9').innerHTML;
    //var eche10 = document.getElementById('eche10').innerHTML;
    //var eche11 = document.getElementById('eche11').innerHTML;
    //var eche12 = document.getElementById('eche12').innerHTML;

    //const interlocuteurData = {
    //    nomInter: nomI,
    //    prenomInter: prenomI,
    //    telInter: telI,
    //    mailInter: mailI
    //};
    //const clientData = {
    //    nomCli: nomC,
    //    prenomCli: prenomC,
    //    add1Cli: add1C,
    //    add2Cli: add2C,
    //    add3Cli: add3C,
    //    postalCode: codPostC,
    //    placeName: villeC,
    //    countryName: paysC
    //};
    //const contratData = {
    //    id_Contr: numCo,
    //    nomAssu: typCo,
    //    dateContr: datCo,
    //    dateDebutContr: debCo
    //};
    //const echeancesData = {
    //    valeurMois1: val1,
    //    dateEcheance1: eche1,
    //    valeurMois2: val2,
    //    dateEcheance2: eche2,
    //    valeurMois3: val3,
    //    dateEcheance3: eche3,
    //    valeurMois4: val4,
    //    dateEcheance4: eche4,
    //    valeurMois5: val5,
    //    dateEcheance5: eche5,
    //    valeurMois6: val6,
    //    dateEcheance6: eche6,
    //    valeurMois7: val7,
    //    dateEcheance7: eche7,
    //    valeurMois8: val8,
    //    dateEcheance8: eche8,
    //    valeurMois9: val9,
    //    dateEcheance9: eche9,
    //    valeurMois10: val10,
    //    dateEcheance10: eche10,
    //    valeurMois11: val11,
    //    dateEcheance11: eche11,
    //    valeurMois12: val12,
    //    dateEcheance12: eche12
    //};

    const objetxml = '<?xml version=\"1.1\" encoding=\"UTF-8\"?><K6><DES><DES_ID>DE</DES_ID><DES_TOP_CA>0</DES_TOP_CA><DES_TOP_CO>0</DES_TOP_CO><DES_TOP_EXO>0</DES_TOP_EXO><DES_PERIODE>Z</DES_PERIODE><DES_NUM_COMPTE>0824446</DES_NUM_COMPTE></DES> <MES><MES_ID>ME</MES_ID><MES_MESSAGE_14></MES_MESSAGE_14><MES_MESSAGE_15></MES_MESSAGE_15></MES></K6>';

    const urlKwSoft = 'https://contenthub-fr.test.omscloud.eu/mtext-integration-adapter/template//RELEVE_K6/Templates/RELEVE_K6.template/export?document-name=RELEVE1234567&mime-type=application%2Fpdf&user=user_ADV&passwordplain=demo';

    /*const objetKw = JSON.stringify({ Interlocuteur: interlocuteurData, Client: clientData, Contrat: contratData, Echeances: echeancesData });*/

    const formdata = new FormData();

    formdata.append("xml:DATA", objetxml);

    const requestOptions = {

        method: "POST",

        headers: { "Content-Type": "multipart/form.data; boundary=<calculated when request is sent>", "Accept": "*/*", "Host": "https://contenthub-fr.test.omscloud.eu/", "Accept-Encoding": "gzip, deflate, br", "Access-Control-Allow-Origin": "https://localhost:44338" },

        body: formdata,

        redirect: "follow"
        
    };

    fetch(urlKwSoft, requestOptions)

        .then(res => res.blob())
        .then(blob => {
            console.log(blob);

            const file = new File([blob], 'pdf Retour', { type: blob.type });

            console.log(file);
        })
}

async function populateAssuranceDropdown() {
    try {
        const response = await fetch(urlAssurance);
        const assurances = await response.json();

        const assuranceDropdown = document.getElementById('id_assu');

        assurances.forEach(assurance => {
            const option = document.createElement('option');
            option.value = assurance.id_assu; // On utilise l'id du contrat d'assurance comme valeur
            option.text = assurance.nomAssu; // On Utilise nom du contrat d'assurance comme texte
            assuranceDropdown.appendChild(option);
        });

    } catch (error) {
        console.error('Erreur lors du chargement des assurances:', error);
    }
}

function populatePageTrois() {
    //récupération des objets stockés dans le 'localstorage'
    const user = JSON.parse(localStorage.getItem('user'));
    const client = JSON.parse(localStorage.getItem('client'));
    const contrat = JSON.parse(localStorage.getItem('contrat'));

    //Peuplement des dates des échéances
    if (contrat && contrat.dateDebutContr) {
        // Convertir la date de début de contrat en objet Date
        const dateDebutContr = new Date(contrat.dateDebutContr);

        // Fonction pour formater la date en yyyy-mm-dd
        function formatDate(date) {
            const year = date.getFullYear();
            const month = String(date.getMonth() + 1).padStart(2, '0');
            const day = String(date.getDate()).padStart(2, '0');
            return `${year}-${month}-${day}`;
        }

        // Peupler les échéances
        for (let i = 0; i < 12; i++) {
            const echeanceDate = new Date(dateDebutContr);
            echeanceDate.setMonth(dateDebutContr.getMonth() + i);
            const echeanceId = `eche${i + 1}`;
            document.getElementById(echeanceId).innerHTML = formatDate(echeanceDate);
        }
    } else {
        console.log('Contrat or dateDebutContr not found in localStorage');
    }

    //récupération des éléments du DOM.
    //interlocuteur
    document.getElementById('nomInter').innerHTML = user.nomInter;
    document.getElementById('prenomInter').innerHTML = user.prenomInter;
    document.getElementById('telInter').innerHTML = user.telInter;
    document.getElementById('mailInter').innerHTML = user.mailInter;
    //client
    document.getElementById('nomClient').innerHTML = client.nomCli;
    document.getElementById('prenomClient').innerHTML = client.prenomCli;
    document.getElementById('add1Client').innerHTML = client.add1Cli;
    document.getElementById('add2Client').innerHTML = client.add2Cli;
    document.getElementById('add3Client').innerHTML = client.add3Cli;
    document.getElementById('codePostVille').innerHTML = client.postalCode;
    document.getElementById('nomVille').innerHTML = client.placeName;
    document.getElementById('nomPays').innerHTML = client.countryName;
    //contrat
    document.getElementById('id_Contr').innerHTML = contrat.id_Contr;
    document.getElementById('typContr').innerHTML = contrat.nomAssu;
    document.getElementById('dateContr').innerHTML = contrat.dateContr;
    document.getElementById('dateDebutContr').innerHTML = contrat.dateDebutContr;
    //échéances
    //Peuplées grace à la fonction
    //valeurs
    document.getElementById('valeurAssu1').innerHTML = contrat.valeurAssu;
    document.getElementById('valeurAssu2').innerHTML = contrat.valeurAssu;
    document.getElementById('valeurAssu3').innerHTML = contrat.valeurAssu;
    document.getElementById('valeurAssu4').innerHTML = contrat.valeurAssu;
    document.getElementById('valeurAssu5').innerHTML = contrat.valeurAssu;
    document.getElementById('valeurAssu6').innerHTML = contrat.valeurAssu;
    document.getElementById('valeurAssu7').innerHTML = contrat.valeurAssu;
    document.getElementById('valeurAssu8').innerHTML = contrat.valeurAssu;
    document.getElementById('valeurAssu9').innerHTML = contrat.valeurAssu;
    document.getElementById('valeurAssu10').innerHTML = contrat.valeurAssu;
    document.getElementById('valeurAssu11').innerHTML = contrat.valeurAssu;
    document.getElementById('valeurAssu12').innerHTML = contrat.valeurAssu;

    testAffichageValeur = document.getElementById('nomInter').innerHTML;

    console.log(testAffichageValeur);
   
}



// Appeler la fonction pour remplir la liste déroulante des pays au chargement de la page
document.addEventListener('DOMContentLoaded', populateCountryDropdown);
// Appeler la fonction pour remplir la liste déroulante des sexes au chargement de la page
document.addEventListener('DOMContentLoaded', populateSexeDropdown);
// Appeler la fonction pour remplir la liste déroulante des régimes de sécurité sociale au chargement de la page
document.addEventListener('DOMContentLoaded', populateSecuDropdown);
// Appeler la fonction pour remplir la liste déroulante des contrats d'assurance au chargement de la page
document.addEventListener('DOMContentLoaded', populateAssuranceDropdown);




/*
    Enciennes versions du code.
*/

//// Ajouter un gestionnaire d'événements pour détecter le changement de sélection du pays
//document.getElementById('countryName').addEventListener('change', () => {
//    const selectedCountry = document.getElementById('countryName').value;
//    if (selectedCountry) {
//        document.getElementById('postalCode').addEventListener('input', () => {
//            const postalCode = document.getElementById('postalCode').value;
//            if (postalCode) {
//                populateCityDropdown(selectedCountry, postalCode);
//            } else {
//                clearCityDropdown();
//            }
//        });
//    } else {
//        clearCityDropdown();
//    }
//});



///Peuplement de la page 3

////récupération des éléments du DOM.
////interlocuteur
//var nomInt = document.getElementById('nomInter');
//var prenomInt = document.getElementById('prenomInter');
//var telInt = document.getElementById('telInter');
//var mailInt = document.getElementById('mailInter');
////client
//var nomCli = document.getElementById('nomCli');
//var prenomCli = document.getElementById('prenomCli');
//var add1Cli = document.getElementById('add1Cli');
//var add2Cli = document.getElementById('add2Cli');
//var add3Cli = document.getElementById('add3Cli');
//var codePostVille = document.getElementById('codePostVille');
//var nomVille = document.getElementById('nomVille');
//var nomPays = document.getElementById('nomPays');
////contrat
//var id_Contr = document.getElementById('id_Contr');
//var typContr = document.getElementById('typContr');
//var dateContr = document.getElementById('dateContr');
//var dateDebutContr = document.getElementById('dateDebutContr');
////échéances
//var eche1 = document.getElementById('eche1');
//var eche2 = document.getElementById('eche2');
//var eche3 = document.getElementById('eche3');
//var eche4 = document.getElementById('eche4');
//var eche5 = document.getElementById('eche5');
//var eche6 = document.getElementById('eche6');
//var eche7 = document.getElementById('eche7');
//var eche8 = document.getElementById('eche8');
//var eche9 = document.getElementById('eche9');
//var eche10 = document.getElementById('eche10');
//var eche11 = document.getElementById('eche11');
//var eche12 = document.getElementById('eche12');
////valeurs
//var valeurAssu1 = document.getElementById('valeurAssu1');
//var valeurAssu2 = document.getElementById('valeurAssu2');
//var valeurAssu3 = document.getElementById('valeurAssu3');
//var valeurAssu4 = document.getElementById('valeurAssu4');
//var valeurAssu5 = document.getElementById('valeurAssu5');
//var valeurAssu6 = document.getElementById('valeurAssu6');
//var valeurAssu7 = document.getElementById('valeurAssu7');
//var valeurAssu8 = document.getElementById('valeurAssu8');
//var valeurAssu9 = document.getElementById('valeurAssu9');
//var valeurAssu10 = document.getElementById('valeurAssu10');
//var valeurAssu11 = document.getElementById('valeurAssu11');
//var valeurAssu12 = document.getElementById('valeurAssu12');
////Attribution des valeurs des objets du local storage aux espaces de la page 3
////Interlocuteur
//nomInt.innerHTML = user.nomInter;
//prenomInt.innerHTML = user.prenomInter;
//telInt.innerHTML = user.telInter;
//mailInt.innerHTML = user.mailInter;
////Client
//nomCli.innerHTML = user.nomInter;
//prenomCli.innerHTML = user.prenomInter;
//telInt.innerHTML = user.telInter;
//mailInt.innerHTML = user.mailInter;
//nomCli.innerHTML = user.nomInter;
//prenomCli.innerHTML = user.prenomInter;
//telInt.innerHTML = user.telInter;
//mailInt.innerHTML = user.mailInter;



//tentative initiale de fetch l'url KwSoft

//const response = await fetch(urlKwSoft, {
//    method: 'POST',
//    headers: { 'Content-Type': 'multipart/form.data; boundary=<calculated when request is sent>', "accept": '*/*'  },
//    body: objetKw,
//    //modification de l'en-tête
//    mode: 'no-cors'
//});
//console.log(objetKw);
//if (response.ok) {
//    /*const contrat = await response.json();*/
//    /*localStorage.setItem('contrat', JSON.stringify(contrat));*/
//    // Passer à la prochaine partie du formulaire
//    alert('Données transmises avec succès');
//} else {
//    console.error('Erreur lors de l\'enregistrement du contrat');
//    alert('Erreur lors de l\'enregistrement du contrat');
//}






///SAUVEGARDE DE LA REQUETE KW QUI FONCTIONNE ATTENTION AUX PARTIES EN COMMENTAIRE ET 'NO CORS' EST EN COMMENTAIRE AUSSI

//const objetxml = '<?xml version=\"1.1\" encoding=\"UTF-8\"?><K6><DES><DES_ID>DE</DES_ID><DES_TOP_CA>0</DES_TOP_CA><DES_TOP_CO>0</DES_TOP_CO><DES_TOP_EXO>0</DES_TOP_EXO><DES_PERIODE>Z</DES_PERIODE><DES_NUM_COMPTE>0824446</DES_NUM_COMPTE></DES> <MES><MES_ID>ME</MES_ID><MES_MESSAGE_14></MES_MESSAGE_14><MES_MESSAGE_15></MES_MESSAGE_15></MES></K6>';

//const urlKwSoft = 'https://contenthub-fr.test.omscloud.eu/mtext-integration-adapter/template//RELEVE_K6/Templates/RELEVE_K6.template/export?document-name=RELEVE1234567&mime-type=application%2Fpdf&user=user_ADV&passwordplain=demo';

///*const objetKw = JSON.stringify({ Interlocuteur: interlocuteurData, Client: clientData, Contrat: contratData, Echeances: echeancesData });*/

//const formdata = new FormData();

//formdata.append("xml:DATA", objetxml);

//const requestOptions = {

//    method: "POST",

//    body: formdata,

//    redirect: "follow",

//    /*        mode: 'no-cors',*/

//    //ajouts à partir du mail.

//    headers: { 'Content-Type': 'multipart/form.data; boundary=<calculated when request is sent>', 'Accept': '*/*', 'Host': 'https://contenthub-fr.test.omscloud.eu/', 'Accept-Encoding': 'gzip, deflate, br' }
//};

////const response = await fetch(urlKwSoft, requestOptions);
/////*console.log(objetKw);*/
////if (response.ok) {
////    /*const contrat = await response.json();*/
////    /*localStorage.setItem('contrat', JSON.stringify(contrat));*/
////    // Passer à la prochaine partie du formulaire
////    alert('Données transmises avec succès');
////} else {
////    console.error('Erreur lors de l\'enregistrement du contrat');
////    alert('Erreur lors de l\'enregistrement du contrat');
////}

//fetch(urlKwSoft, requestOptions)

//    .then(res => res.blob())
//    .then(blob => {
//        console.log(blob);

//        const file = new File([blob], 'pdf Retour', { type: blob.type });

//        console.log(file);
//    })

////.catch((err) => {
////    console.log("Erreur de BLOB !!!");
////});

////.then((response) => response.text())

////.then((result) => console.log(result))

////.catch((error) => console.error(error));