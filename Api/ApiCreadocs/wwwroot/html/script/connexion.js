// JavaScript source code
console.log("script.")
/*UtilConnect = document.getElementById('texteOngletUtilConnect');*/

var formulaire = document.getElementById('connexion')
    formulaire.addEventListener('submit', async function (event) {
    event.preventDefault();

    const email = document.getElementById('Email').value;
    const password = document.getElementById('Password').value;

    const response = await fetch('https://localhost:44338/api/interlocuteur/login', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({ email, password })
    });

    if (response.ok) {
        const user = await response.json();
        console.log(user);

        localStorage.setItem('user', JSON.stringify(user)); // Stocker les informations de l'utilisateur
        window.location.href = 'AccueilCreadocs.html'; // Rediriger vers la page d'accueil
    } else {
        alert('Login failed');
    }
});
